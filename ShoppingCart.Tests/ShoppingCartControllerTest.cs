using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Controllers;
using ShoppingCart.DataModels;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShoppingCart.Tests
{
    /// <summary>
    /// Test class for <see cref="ShoppingCartController"/>
    /// </summary>
    public class ShoppingCartControllerTest
    {
        private readonly ShoppingCartController _controller;
        private readonly IShoppingCartService _service;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ShoppingCartControllerTest()
        {
            _service = new ShoppingCartServiceFake();
            _controller = new ShoppingCartController(_service);
        }

        #region GetItems Tests

        [Fact]
        public void GetItems_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetItems();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetItems_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetItems().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<ShoppingItem>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        #endregion

        #region GetItemById Tests

        [Fact]
        public void GetItemById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetItemById(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetItemById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.GetItemById(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetItemById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.GetItemById(testGuid).Result as OkObjectResult;

            // Assert
            Assert.IsType<ShoppingItem>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as ShoppingItem).Id);
        }

        #endregion

        #region AddItem Tests

        [Fact]
        public void AddItem_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ShoppingItem testItem = new ShoppingItem()
            {
                Name = "Guinness Original 6 Pack",
                Manufacturer = "Guinness",
                Price = 12.00M
            };

            // Act
            var createdResponse = _controller.AddItem(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void AddItem_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new ShoppingItem()
            {
                Name = "Guinness Original 6 Pack",
                Manufacturer = "Guinness",
                Price = 12.00M
            };

            // Act
            var createdResponse = _controller.AddItem(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as ShoppingItem;

            // Assert
            Assert.IsType<ShoppingItem>(item);
            Assert.Equal("Guinness Original 6 Pack", item.Name);
        }

        #endregion

        #region RemoveItem Tests

        [Fact]
        public void RemoveItem_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = _controller.RemoveItem(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void RemoveItem_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResponse = _controller.RemoveItem(existingGuid);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void RemoveItem_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResponse = _controller.RemoveItem(existingGuid);

            // Assert
            Assert.Equal(2, _service.GetAllItems().Count());
        }

        #endregion

    }
}
