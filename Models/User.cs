using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CVProjekt1._0.Models
{
    public class User : IdentityUser
    {
        [Key]
        public string? UserId { get; set; }
        public virtual IEnumerable<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();
        public virtual ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public virtual Resume Resume { get; set; }
    }
}
