using CVProjekt1._0.Models;

namespace CVProjekt1._0.ViewModels
{
    public class HomePageViewModel
    {
        public List<Resume> SelectedResumes { get; set; }
        public Project LatestProject { get; set; }
        public List<User> Users { get; set; }
    }
}
