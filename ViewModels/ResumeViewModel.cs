using CVProjekt1._0.Models;

namespace CVProjekt1._0.ViewModels
{
    public class ResumeViewModel
    {
        public string ShortenedDescription { get; set; }
        public List<Skill> Skills { get; set; }
        public User User { get; set; }
    }
}
