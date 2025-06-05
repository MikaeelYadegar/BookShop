using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DiscountService
{
    public interface IDiscountCodeService
    {
        Task<string> CreateDiscountCodeAsync(int precentage);
    }
}
