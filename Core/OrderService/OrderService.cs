using Core.OrderService.Model;
using DatAccess.Models;
using DatAccess.Repositories.BasketRepo;
using DatAccess.Repositories.BookRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OrderService
{
    public class OrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBookRepository _bookRepository;
        public OrderService(IBasketRepository basketRepository, IBookRepository bookRepository)
        {
            _basketRepository = basketRepository;
            _bookRepository = bookRepository;
        }
        public async Task<bool>AddToBasket(int bookId,int Qty,int userId)
        {
            var basket=new Basket();
            basket=await _basketRepository.GetAll(a=>a.UserId == userId &&a.Status==DatAccess.Enums.Status.Create)
                .FirstOrDefaultAsync();
            if(basket==null)
            {
                basket = new Basket()
                {
                    UserId = userId,
                    Created = DateTime.Now,
                    Status = DatAccess.Enums.Status.Create,
                    Address="",
                    Mobile="",
                    Payed=DateTime.Now,


                };
                await _basketRepository.Add(basket);
            }

                var book= await _bookRepository.GetByID(bookId);
                var basketItem = new BasketItems()
                {
                    BasketId = basket.Id,
                    Qty = Qty,
                    BookId = book.Id,
                    Created= DateTime.Now,
                    Price = book.Price*Qty,
                };
                await _basketRepository.AddBasketItem(basketItem);

            
            return true;
        }
        public async Task<List<BasketItems>>GetUserBasket(int userId)
        {
            var baskets= await _basketRepository.GetAllBasketItems(a=>a.Basket.UserId == userId
            && a.Basket.Status==DatAccess.Enums.Status.Create)
                .Include(a=>a.Basket)
                .Include(a=>a.Book).AsNoTracking().ToListAsync();
            return baskets;
        }

        public async Task<bool>RemoveItemBasket(int Id)
        {
            var baskets = await _basketRepository.GetAllBasketItems(a => a.Id == Id).FirstOrDefaultAsync();
            await _basketRepository.DeleteBasketItem(baskets);
            return true;
        }
        public async Task<bool> Pay(string mobile,string address,int userId)
        {
            var basket=await _basketRepository.GetAll(a=>a.UserId == userId && a.Status==DatAccess.Enums.Status.Create).FirstOrDefaultAsync();
            if (basket == null)
                return false;
            basket.Mobile=mobile;
            basket.Address=address;
            basket.Payed=DateTime.Now;
            basket.Status = DatAccess.Enums.Status.Final;
            await _basketRepository.Update(basket);
            return true;
        }
        public async Task<List<Basket>> GetUserOrders(int userId)
        {
            var baskets = await _basketRepository.GetAll(a => a.UserId == userId&& a.Status !=DatAccess.Enums.Status.Create)
    
                .Include(a => a.BasketItems)
                .ThenInclude(a => a.Book).AsNoTracking().ToListAsync();
            return baskets;
        }
        public async Task<List<AdminOrderDto>> GetAllOrders()
        {
            var baskets = await _basketRepository.GetAll(a => a.Status != DatAccess.Enums.Status.Create)
                .Include(a => a.User)
                .Include(a => a.BasketItems)
                .ThenInclude(a => a.Book)
                .Select(s => new AdminOrderDto()
                {
                    Address = s.Address,
                    Mobile = s.Mobile,
                    Id = s.Id,
                    Status = s.Status,
                    Payed = s.Payed,
                    UserId = s.UserId,
                    UserName = s.User.UserName,
                    Items = s.BasketItems.Select(c => c.Book.Title).ToList()
                })
                .AsNoTracking().ToListAsync();
            return baskets;
        }
        public async Task<AdminOrderDto> GetOrderWithId(int id)
        {
            var baskets = await _basketRepository.GetAll(a => a.Id==id)
                .Include(a => a.User)
                .Include(a => a.BasketItems)
                .ThenInclude(a => a.Book)
                .Select(s => new AdminOrderDto()
                {
                    Address = s.Address,
                    Mobile = s.Mobile,
                    Id = s.Id,
                    Status = s.Status,
                    Payed = s.Payed,
                    UserId = s.UserId,
                    UserName = s.User.UserName,
                    Items = s.BasketItems.Select(c => c.Book.Title).ToList()
                })
                .AsNoTracking().FirstOrDefaultAsync();
            return baskets;
        }

        public async Task<bool> SetStatus(int Id,bool State)
        {
            var basket = await _basketRepository.GetAll(a => a.Id == Id).FirstOrDefaultAsync();
            if(State)
            {
                basket.Status=DatAccess.Enums.Status.Accepted;
            }
            else
            {
                basket.Status = DatAccess.Enums.Status.Rejected;
            }
            await _basketRepository.Update(basket);
            return true;
        }

    }
}
