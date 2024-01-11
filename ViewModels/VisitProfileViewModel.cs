using CVProjekt1._0.Models;

namespace CVProjekt1._0.ViewModels
{
    public class VisitProfileViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ProfilePicture { get; set; }
        public Resume Resume { get; set; }
        public List<string> ProjectDescriptions { get; set; }
        public List<string> ProjectTitle { get; set; }
        public string Message { get; set; }
        public List<ProjectDetailsViewModel> Projects { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
