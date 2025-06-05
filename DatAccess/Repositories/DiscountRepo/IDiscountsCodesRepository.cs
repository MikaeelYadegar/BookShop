using DatAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Repositories.DiscountRepo
{
    public interface IDiscountsCodesRepository
    {
        Task AddAsync(DiscountCode code);
        Task SaveChangeAsync();
    }
}
