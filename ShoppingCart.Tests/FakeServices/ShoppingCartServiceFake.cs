using ShoppingCart.DataModels;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Tests
{
    /// <summary>
    /// Fake ShoppinCartService for Testing Purposes
    /// </summary>
    public class ShoppingCartServiceFake : IShoppingCartService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<ShoppingItem> _shoppingCart;

        /// <summary>
        /// Default Constructor, populates in memory list for testing
        /// </summary>
        public ShoppingCartServiceFake()
        {
            _shoppingCart = new List<ShoppingItem>()
            {
                new ShoppingItem() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", Manufacturer="Orange Tree", Price = 5.00M },
                new ShoppingItem() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Milk", Manufacturer="Cow", Price = 4.00M },
                new ShoppingItem() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen Pizza", Manufacturer="Uncle Mickey", Price = 12.00M }
            };
        }

        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return _shoppingCart;
        }

        /// <summary>
        /// Adds Item to list
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public ShoppingItem AddItem(ShoppingItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            _shoppingCart.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// Gets an item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShoppingItem GetItemById(Guid id)
        {
            return _shoppingCart.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Removes an Item
        /// </summary>
        /// <param name="id"></param>
        public void RemoveItem(Guid id)
        {
            var existing = _shoppingCart.First(a => a.Id == id);
            _shoppingCart.Remove(existing);
        }
    }
}
