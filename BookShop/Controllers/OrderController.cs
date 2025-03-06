using BookShop.Models;
using Core.OrderService;
using DatAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
   
        public async Task<IActionResult>AddToBasket([FromBody]AddBasketDto model)
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                return Ok(new { res = false, msg = "لطف لاگین یا ثبت نام کنید" });
            }
            var result=await _orderService.AddToBasket(model.bookId,model.qty,Convert.ToInt32(userId));
            return Ok(new {res=true});
        }
    }
}
