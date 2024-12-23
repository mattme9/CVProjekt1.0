﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CVProjekt1._0.Models
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string? UserId { get; set; } //Främmande nyckel
        public string? Description { get; set; }
        public string? Skill { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }

        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}

