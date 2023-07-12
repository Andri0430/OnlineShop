using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly OnlineShopContext _onlineShopContext;

        public Product(OnlineShopContext onlineShopContext)
        {
            _onlineShopContext = onlineShopContext;
        }
    }
}