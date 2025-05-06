using Core.ChatBoxService;
using DatAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminBookShop.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }
        public async Task<IActionResult> Index(string userId)
        {
            var adminId = "admin";
            var message = await _chatService.GetChatAsync(adminId, userId);
            ViewBag.receiverId = userId;
            return View(message);
        }
        [HttpPost]
        public async Task<IActionResult> Send(string receiverId, string message)
        {
            var adminId = "admin";
            var chatMessage = new MessageChat
            {
                SenderId = adminId,
                ReciverId = receiverId,
                Message = message,
                Timestamp= DateTime.Now
            };
            await _chatService.SendMessageAsync(chatMessage);
            return RedirectToAction("Index", new { userId = receiverId });
        }
        public async Task<IActionResult>Users()
        {
            var adminId = "admin";  
            var users=await _chatService.GetChatUserIdAsync(adminId);
            return View(users);
        }
    }
}
