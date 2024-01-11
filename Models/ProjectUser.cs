using CVProjekt1._0.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVProjekt1._0.Models
{
    public class ProjectUser
    {
        public int ProjectId { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

        [ForeignKey(nameof(User.Id))]
        public virtual User User { get; set; }
    }

}
