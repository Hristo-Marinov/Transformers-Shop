using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransformersShop.Controllers;
using TransformersShop.Models;
using TransformersShop.Entity;
using Xunit;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YourNamespace.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace TransformersShop.Tests
{
    public class Tests
    {
        private readonly AppDbContext _context;
        private readonly ProductsController _controller;

        private readonly Mock<ILogger<HomeController>> _mockLogger;
        private readonly HomeController homeController;

        private readonly Mock<ILogger<AdminController>> mock;
        private readonly AdminController admin;

        private readonly ErrorController Controller;


        public Tests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(options);
            _controller = new ProductsController(_context);

            _mockLogger = new Mock<ILogger<HomeController>>();
            homeController = new HomeController(_mockLogger.Object);

            Controller = new ErrorController();
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenProductDoesNotExist()
        {
            var result = await _controller.Details(0);
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public void Error_ReturnsViewResult_WithErrorViewModel()
        {
            var result = homeController.Privacy();
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]
        [InlineData(405)]
        [InlineData(500)]
        public void HttpStatusCodeHandler_ReturnsViewResult_WithCorrectViewAndMessage(int statusCode)
        {
            var result = Controller.HttpStatusCodeHandler(statusCode);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);

            switch (statusCode)
            {
                case 401:
                    Assert.Equal("Unauthorized access.", viewResult.ViewData["ErrorMessage"]);
                    break;
                case 404:
                    Assert.Equal("The resource you requested could not be found.", viewResult.ViewData["ErrorMessage"]);
                    break;
                case 405:
                    Assert.Equal("The HTTP method used is not allowed for this resource.", viewResult.ViewData["ErrorMessage"]);
                    break;
                default:
                    Assert.Equal("An unexpected error occurred. Please try again later.", viewResult.ViewData["ErrorMessage"]);
                    break;
            }
        }

        [Fact]
        public void Error_ReturnsViewResult_WithCorrectMessage()
        {
            var result = Controller.Error();
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", viewResult.ViewName);
            Assert.Equal("An unexpected error occurred. Please try again later.", viewResult.ViewData["ErrorMessage"]);
        }
    }
}

