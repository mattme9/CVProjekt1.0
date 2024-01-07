using CVProjekt1._0.Models;

namespace CVProjekt1._0.ViewModels
{
    public class VisitProfileViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public Resume Resume { get; set; }
        public List<Project> Projects { get; set; }
        public string Message { get; set; }
        
    }
}
