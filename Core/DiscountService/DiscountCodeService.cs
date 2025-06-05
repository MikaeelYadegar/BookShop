using DatAccess.Models;
using DatAccess.Repositories.DiscountRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DiscountService
{
    public class DiscountCodeService:IDiscountCodeService
    {
        private readonly IDiscountsCodesRepository _discountcoderepository;
        private readonly Random _random = new();
        public DiscountCodeService(IDiscountsCodesRepository discountsCodesRepository)
        {
            _discountcoderepository = discountsCodesRepository;
        }

        public async Task<string> CreateDiscountCodeAsync(int precentage)
        {
            var code = $"OFF{precentage}-{GenerateRandomeCode()}";
            var discount = new DiscountCode
            {
                Code = code,
                Percentage = precentage,
                CreatedAt = DateTime.Now,
                ExpierAt = DateTime.Now.AddDays(3),
                IsUsed = false
            };
            await _discountcoderepository.AddAsync(discount);
            await _discountcoderepository.SaveChangeAsync();
            return code;
        }
        private string GenerateRandomeCode()
        {
            const string chars = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            return new string(Enumerable.Repeat(chars,5)
                .Select(s => s[_random.Next(chars.Length)]).ToArray());
        }
    }
}
