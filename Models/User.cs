using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CVProjekt1._0.Models
{
    public class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string ? Address { get; set; }
        public string ? City { get; set; }
        public string ? Country { get; set; }
        public string ? PostalCode { get; set; }
        public string? ProfilePicturePath { get; set; }
        public bool isPrivate { get; set; }
        public virtual IEnumerable<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();
        public virtual ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public virtual Resume Resume { get; set; }
    }
}
