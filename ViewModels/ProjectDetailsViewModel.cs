using CVProjekt1._0.Models;

namespace CVProjekt1._0.ViewModels
{
    public class ProjectDetailsViewModel
    {
        //ViewModel för att visa ett projekts beskrivning och tillhörande information samt redigera den
        public int ProjectId { get; set; }

        public string? Title { get; set; }
        
        public string? Description { get; set; }

        public User? User { get; set; }
    }
}
