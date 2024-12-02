using System.ComponentModel.DataAnnotations;

namespace WebApp.DTO
{
    public class NoteDTO
    {
        public NoteDTO()
        {
        }

        public Guid SelectedSpeciesId { get; set; } = Guid.Empty;
        
        public Guid SelectedAnimalId { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "Note description required")]
        public string NoteText { get; set; } = string.Empty;
    }
}
