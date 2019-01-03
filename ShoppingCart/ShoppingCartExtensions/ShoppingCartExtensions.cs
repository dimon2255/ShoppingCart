using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.ShoppingCartExtensions
{
    /// <summary>
    /// Extension methods for ShoppingCartService
    /// </summary>
    public static class ShoppingCartExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddShoppingCartService(this IServiceCollection services)
        {
            return services.AddScoped<IShoppingCartService, ShoppingCartService>();
        }
    }
}
