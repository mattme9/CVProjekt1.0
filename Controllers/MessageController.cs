using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CVProjekt1._0.Controllers
{
    public class MessageController : Controller
    {
        private readonly CVContext _context;
        private readonly UserManager<User> _userManager;

        public MessageController(CVContext context, UserManager<User> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }
        public IActionResult Inbox()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;

            // Get unread messages for the current user with included Sender data
            var unreadMessages = _context.Messages
                .Include(m => m.Sender)
                .Where(m => m.ReceiverId == currentUser.Id && !m.IsRead)
                .ToList();

            // Pass the count of unread messages to the view
            ViewData["UnreadMessageCount"] = unreadMessages.Count;

            // Retrieve all messages for display with included Sender data
            var messages = _context.Messages
                .Include(m => m.Sender)
                .Where(m => m.ReceiverId == currentUser.Id)
                .ToList();

            return View(messages);
        }

        public async Task<IActionResult> SendMessage(string message, string id, bool isAnonymous)
        {
            var receiver = await _userManager.FindByNameAsync(id);
            User sender = null;

            if (!isAnonymous)
            {
                sender = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            
            var newMessage = new Message
            {
                Sender = sender,
                Receiver = receiver,
                MessageText = message,
                IsRead = false,
                DateSent = DateTime.Now,
                IsAnonymous = isAnonymous
            };

            TempData["SuccessMessage"] = "Your message was sent successfully.";
            receiver.ReceivedMessages.Add(newMessage);
            _context.Add(newMessage);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult MarkAsRead(int messageId)
        {
            var message = _context.Messages.Find(messageId);

            if (message != null)
            {
                // Mark the message as read
                message.IsRead = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Inbox");
        }
    }
}
