using CVProjekt1._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVProjekt1._0.Models
{
    public class Education
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EducationId { get; set; }
        [Required]
        public int ResumeId { get; set; } //Främmande nyckel
        [Required]
        public string EducationType { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public virtual Resume Resume { get; set; }
    }
}
