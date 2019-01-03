using ShoppingCart.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    /// <summary>
    /// Defines Shopping Cart Service
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Finds <see cref="ShoppingItem"/> by Id
        /// </summary>
        /// <param name="Id">Id of the Item to return</param>
        /// <returns>Returns found Item or null, if not found</returns>
        ShoppingItem GetItemById(Guid Id);

        /// <summary>
        /// Gets all Items
        /// </summary>
        /// <returns>Returns <see cref="IEnumerable{ShoppingItem}"/></returns>
        IEnumerable<ShoppingItem> GetAllItems();

        /// <summary>
        /// Removes Item by Id
        /// </summary>
        /// <param name="Id">Id of the item to remove</param>
        /// <returns>Task</returns>
        void RemoveItem(Guid Id);

        /// <summary>
        /// Adds an Item to Cart
        /// </summary>
        /// <param name="newItem">Item to add to the Shopping Cart</param>
        /// <returns></returns>
        ShoppingItem AddItem(ShoppingItem newItem);

    }
}
