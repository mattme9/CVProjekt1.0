namespace CVProjekt1._0.ViewModels
{
    public class ResumeViewModel
    {
        public string Description { get; set; }
        public List<string> Educations { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Experiences { get; set; }
        public List<SkillViewModel> SkillDetails { get; set; }
        public List<ExperienceViewModel> ExperienceDetails { get; set; }
    }

    
    public class SkillViewModel
    {
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
    }

 
    public class ExperienceViewModel
    {
        public string ExperienceDescription { get; set; }
    }
}
