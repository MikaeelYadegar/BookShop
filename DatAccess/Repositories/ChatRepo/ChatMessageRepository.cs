using DatAccess.Data;
using DatAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Repositories.ChatRepo
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private BookDbContext _context;
        public ChatMessageRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(MessageChat message)
        {
            _context.MessageChats.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> GetChatUserIdAsync(string adminId)
        {
            return await _context.MessageChats
                .Where(m=>m.SenderId == adminId||m.ReciverId==adminId)
                .Select(m=>m.SenderId==adminId ? m.ReciverId:m.SenderId)
                .Distinct()
                .ToListAsync();
                
        }

        public async Task<List<MessageChat>> GetMessageAsync(string user1, string user2)
        {
            return await _context.MessageChats
       .Where(m => (m.SenderId == user1 && m.ReciverId == user2) ||
                    m.SenderId == user2 && m.ReciverId == user1)
       .OrderBy(m => m.Timestamp)
       .ToListAsync();
        }
    }
}
