using BookShop.Models;
using Core.AuthoreService;
using Core.ChatBoxService;
using Core.OrderService;
using DatAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
        public async Task<IActionResult> Edit(int id,string newMessage)
        {
            if (string.IsNullOrEmpty(newMessage))
                return BadRequest("Is Null");
            await _chatService.EditMessageAsync(id, newMessage);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult>GetMessageText(int id)
        {
            var message=await _chatService.GetMessageByIdAsync(id);
            if(message==null)
                return NotFound();
            return Json(new {text=message.Message});
        }
        public class EditMessageDto
        {
            public int MessageId { get; set;}
            public string NewText { get; set; }
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
