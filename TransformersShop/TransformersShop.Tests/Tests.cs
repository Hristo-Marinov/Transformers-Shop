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

        public Tests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(options);
            _controller = new ProductsController(_context);

            _mockLogger = new Mock<ILogger<HomeController>>();
            homeController = new HomeController(_mockLogger.Object);
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenProductDoesNotExist()
        {
            var result = await _controller.Details(1);
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public void Error_ReturnsViewResult_WithErrorViewModel()
        {
            var result = homeController.Privacy();
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
