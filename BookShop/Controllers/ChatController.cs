using BookShop.Models;
using Core.ChatBoxService;
using Core.OrderService;
using DatAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }
        [Authorize]
        public async Task <IActionResult>Index()
        {
            var userId = User.Identity.Name;
            var adminId = "admin";
            var message=await _chatService.GetChatAsync(userId,adminId);
            ViewBag.receiverId = adminId;
            return View(message);
        }
        [HttpPost]
        
        public async Task<IActionResult>Send(string receiverId, string message)
        {
            var userId = User.Identity.Name;
            var chatMessage = new MessageChat
            {
                SenderId = userId,
                ReciverId = receiverId,
                Message = message,
                Timestamp=DateTime.Now
            };
            await _chatService.SendMessageAsync(chatMessage);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditMessage(int id,string newText)
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _chatService.EditMessageAsync(id, newText,userId);
            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult>DeleteMessage(int id)
        {
            var userId=User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _chatService.DeleteMessageAsync(id, userId);
            if (!result)
                return Forbid();
            return RedirectToAction("Index");
        }

    }
}
