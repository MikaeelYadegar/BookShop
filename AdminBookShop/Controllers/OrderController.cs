using Core.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace AdminBookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        public OrderController( OrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var data=await _orderService.GetAllOrders();
            return View(data);
        }
    }
}
