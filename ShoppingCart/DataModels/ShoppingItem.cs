using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.DataModels
{
    public class ShoppingItem
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the item
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Price of the Item
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Manufacturer of the Item
        /// </summary>
        public string Manufacturer { get; set; }
    }
}
