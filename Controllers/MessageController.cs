using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> SendMessage(string message, string id)
        {
            User sender = null;
            if(User.Identity.Name != null)
            {
                sender = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            var receiver = await _userManager.FindByNameAsync(id);
            var newMessage = new Message
            {
                Sender =  sender,
                Receiver = receiver,
                MessageText = message,
                IsRead = false,
                DateSent = DateTime.Now
            };
            Console.WriteLine(receiver);
            receiver.ReceivedMessages.Add(newMessage);
            _context.Add(newMessage);
            _context.SaveChanges();
            return RedirectToAction("VisitProfile");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
