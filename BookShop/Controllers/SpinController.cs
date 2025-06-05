using Core.DiscountService;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinController : Controller
    {
        private readonly IDiscountCodeService _discountCodeService;
        public SpinController(IDiscountCodeService discountCodeService)
        {
            _discountCodeService = discountCodeService; 
        }
        [HttpPost("spin")]
        public async Task< IActionResult> Spin([FromBody] SpinResultDto dto)
        {
            var precentage=ExtractPrecentage(dto.ResultText);
            if (precentage == 0)
                return Ok(new { message = "شانس دوباره" });
            var code=await _discountCodeService.CreateDiscountCodeAsync(precentage);
            return Ok(new { message = $"تبریک کد تخفیف شما:{code}", code });
        }
        private int ExtractPrecentage(string text)
        {
            if (text.Contains("5%")) return 20;
            if (text.Contains("10%")) return 10;
            if (text.Contains("20%")) return 5;
            if (text.Contains("30%")) return 30;
            return 0;
        }
        public class SpinResultDto
        {
            public string ResultText { get; set;}
        }
    }
}
