using AdminBookShop.Models;
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

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _orderService.GetOrderWithId(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> SetStatusCommand([FromBody] StatusDto model)
        {
            var data = await _orderService.SetStatus(model.Id,model.State);
            return Ok(new { res = data });
        }
    }
}
