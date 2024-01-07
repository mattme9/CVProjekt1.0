using CVProjekt1._0.Models;

namespace CVProjekt1._0.ViewModels
{
    public class ResumeViewModel
    {
        public string Description { get; set; }
        public string Skill { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }

        public List<string> Educations { get; set; }
        
        public List<string> Experiences { get; set; }
    
        public string ShortenedDescription { get; set; }
         public List<Skill> Skills { get; set; }
        public User User { get; set; }

        public Education EducationDetail { get; set; }
        public Experience ExperienceDetail { get; set; }
        public Skill SkillDetail { get; set; }
    }

    
  

}
