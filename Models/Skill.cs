using CVProjekt1._0.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVProjekt1._0.Models
{
    public class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        public int ResumeId { get; set; } //Främmande nyckel
        [Required]
        public string SkillName { get; set; }
        [Required]
        public string SkillDescription { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public virtual Resume Resume { get; set; }
    }
}