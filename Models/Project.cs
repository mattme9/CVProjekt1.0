using CVProjekt1._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVProjekt1._0.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? CreatorId { get; set; }

        public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

        [ForeignKey(nameof(CreatorId))]
        public virtual User User { get; set; }
    }
}

