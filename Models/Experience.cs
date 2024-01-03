using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVProjekt1._0.Models
{
    public class Experience
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExperienceId { get; set; }

        [Required]
        public int ResumeId { get; set; } //Främmande nyckel
        [Required]
        public string ExperienceDescription { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public virtual Resume Resume { get; set; }
    }
}
