using DatAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Repositories.BasketRepo
{
    public interface IBasketRepository
    {
        IQueryable<Basket> GetAll(Expression<Func<Basket, bool>> where = null);
        Task<Basket> GetByID(int id);
        Task Add(Basket basket);

        Task Update(Basket basket);
        Task Delete(Basket basket);
        Task Delete(int id);

        IQueryable<BasketItems> GetAllBasketItems(Expression<Func<BasketItems, bool>> where = null);
        Task AddBasketItem(BasketItems item);
        Task DeleteBasketItem(BasketItems item);

    }
}
