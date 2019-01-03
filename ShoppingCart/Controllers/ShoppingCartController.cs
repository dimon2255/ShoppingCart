using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataModels;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _service;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service"></param>
        public ShoppingCartController(IShoppingCartService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets a list of Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<ShoppingItem>> GetItems()
        {
            return Ok(_service.GetAllItems());
        }

        /// <summary>
        /// Gets an Item from service by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ShoppingItem> GetItemById(Guid Id)
        {
            var item = _service.GetItemById(Id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// Adds an Item to data store
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddItem(ShoppingItem itemToAdd)
        {
            var item = _service.AddItem(itemToAdd);

            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        /// <summary>
        /// Removes Item from the List
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult RemoveItem(Guid Id)
        {
            var existingItem = _service.GetItemById(Id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.RemoveItem(Id);
            return Ok();
        }
    }
}
