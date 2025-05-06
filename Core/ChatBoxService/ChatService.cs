using DatAccess.Models;
using DatAccess.Repositories.ChatRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ChatBoxService
{
    public class ChatService
    {
        private readonly IChatMessageRepository _messageRepository;
        public ChatService(IChatMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public Task<List<MessageChat>>GetChatAsync(string user1,string user2)
        {
            return _messageRepository.GetMessageAsync(user1,user2);
        }
        public Task SendMessageAsync(MessageChat message)
        {
            return _messageRepository.AddMessageAsync(message);
        }   
        public async Task<List<string>>GetChatUserIdAsync(string adminId)
        {
            return await _messageRepository.GetChatUserIdAsync(adminId);
        }
    }
}
