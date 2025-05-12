using DatAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Repositories.ChatRepo
{
    public interface IChatMessageRepository
    {
        Task<List<MessageChat>> GetMessageAsync(string user1, string user2);
        Task AddMessageAsync(MessageChat message);
        Task<List<string>> GetChatUserIdAsync(string adminId);
        Task EditMessageAsync(int messageId, string newText, string userId);
        Task DeleteMessageAsync(MessageChat message);
        Task UpdateMessageAsync(MessageChat message);
        Task<MessageChat> GetMessageByIdAsync(int id);
    }
}
