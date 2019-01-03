using ShoppingCart.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<ShoppingItem> _items;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ShoppingCartService()
        {
            _items = new List<ShoppingItem>();
        }

        /// <summary>
        /// Finds <see cref="ShoppingItem"/> by Id
        /// </summary>
        /// <param name="Id">Id of the Item to return</param>
        /// <returns>Returns found Item or null, if not found</returns>
        public ShoppingItem GetItemById(Guid Id)
        {
            return _items?.Find(item => item.Id == Id);
        }

        /// <summary>
        /// Gets all Items
        /// </summary>
        /// <returns>Returns <see cref="IEnumerable{ShoppingItem}"/></returns>
        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return _items;
        }

        /// <summary>
        /// Removes Item by Id
        /// </summary>
        /// <param name="Id">Id of the item to remove</param>
        /// <returns>Task</returns>
        public void RemoveItem(Guid Id)
        {
            _items.Remove(_items.Find(item => item.Id == Id));
        }

        /// <summary>
        /// Adds an Item to Cart
        /// </summary>
        /// <param name="newItem">Item to add to the Shopping Cart</param>
        /// <returns></returns>
        public ShoppingItem AddItem(ShoppingItem newItem)
        {
            _items.Add(newItem);
            return newItem;
        }
    }
}
