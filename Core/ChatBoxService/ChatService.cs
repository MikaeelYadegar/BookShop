using DatAccess.Models;
using DatAccess.Repositories.ChatRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public async Task EditMessageAsync(int messageId,string newMessage)
        {
            await _messageRepository.EditMessageAsync(messageId,newMessage);

            
        }
         public async Task<bool> DeleteMessageAsync(int messageId,string currentuserId)
        {
            var message = await _messageRepository.GetMessageByIdAsync(messageId);
            if (message == null || message.SenderId == currentuserId)
                return false;
            await _messageRepository.DeleteMessageAsync(message);
            return true;
        }
        public async Task <MessageChat>GetMessageByIdAsync(int messageId)
        {
            return await _messageRepository.GetMessageByIdAsync(messageId);
        }
    }
}
