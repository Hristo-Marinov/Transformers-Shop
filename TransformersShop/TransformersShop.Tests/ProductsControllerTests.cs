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

namespace TransformersShop.Tests
{
    public class ProductsControllerTests
    {
        private readonly AppDbContext _context;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(options);
            _controller = new ProductsController(_context);
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenProductDoesNotExist()
        {
            var result = await _controller.Details(1);
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Details_ReturnsViewResult_WithProductViewModel()
        {
            var product = new Product { Id = 1, Name = "Test Product", Category = new Category { Id = 1, Name = "Test Category" }, Ratings = new List<Rating>() };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var result = await _controller.Details(product.Id);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ProductViewModel>(viewResult.Model);
            Assert.Equal(product.Name, model.Name);
        }

        [Fact]
        public async Task SubmitRating_ReturnsBadRequest_WhenUserNotFound()
        {
            var result = await _controller.SubmitRating(1, 5, "Great product!");

            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task SubmitRating_ReturnsRedirectToAction_WhenRatingIsSubmitted()
        {
            var product = new Product { Id = 1, Name = "Test Product", Category = new Category { Id = 1, Name = "Test Category" }, Ratings = new List<Rating>() };
            var user = new ApplicationUser { Id = "1", UserName = "testuser" };

            _context.Products.Add(product);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var result = await _controller.SubmitRating(product.Id, 5, "Great product!");

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task SubmitRating_CancelsTask_WhenCancellationTokenIsTriggered()
        {
            using (var cts = new CancellationTokenSource(500))
            {
                CancellationToken token = cts.Token;

                var product = new Product { Id = 1, Name = "Test Product", Category = new Category { Id = 1, Name = "Test Category" }, Ratings = new List<Rating>() };
                var user = new ApplicationUser { Id = "1", UserName = "testuser" };

                _context.Products.Add(product);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                try
                {
                    await _controller.SubmitRating(product.Id, 5, "Great product!");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Operation was canceled.");
                }

                Assert.Empty(_context.Ratings.ToList());
            }
        }
    }
}
