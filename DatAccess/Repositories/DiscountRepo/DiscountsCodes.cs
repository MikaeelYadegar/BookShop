using DatAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatAccess.Models;

namespace DatAccess.Repositories.DiscountRepo
{
    public class DiscountsCodes : IDiscountsCodesRepository
    {
        private readonly BookDbContext _context;
        public DiscountsCodes(BookDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DiscountCode code)
        {
            await _context.DiscountCodes.AddAsync(code);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
