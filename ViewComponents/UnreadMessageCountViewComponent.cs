using Microsoft.AspNetCore.Mvc;
using CVProjekt1._0.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CVProjekt1._0.Components
{
    public class UnreadMessageCountViewComponent : ViewComponent
    {
        private readonly CVContext _context;
        private readonly UserManager<User> _userManager;

        public UnreadMessageCountViewComponent(CVContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser != null)
            {
                var unreadMessagesCount = _context.Messages.Count(m => m.ReceiverId == currentUser.Id && !m.IsRead);
                return View("/Views/Shared/Components/UnreadMessageCount/Default.cshtml", unreadMessagesCount);
            }

            return View("/Views/Shared/Components/UnreadMessageCount/Default.cshtml", 0);
        }



    }
}
