using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL.Models;
using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using WebApp.DTO;
using System.Text.Json;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class EmployeeDashboardNotesModel : PageModel
    {
        private readonly ISpeciesService _speciesService;
        private readonly IAnimalService _animalService;
        private readonly INoteService _noteService;

        public List<SpeciesNameDTO> SpeciesList { get; set; }

        public List<AnimalNameDTO> AnimalList { get; set; }

        public List<Note> NoteList { get; set; }

        [BindProperty]
        public NoteDTO Note { get; set; }
        

        public EmployeeDashboardNotesModel(ISpeciesService speciesService, IAnimalService animalService, INoteService noteService)
        {
            _speciesService = speciesService;
            _animalService = animalService;
            _noteService = noteService;
            SpeciesList = new List<SpeciesNameDTO>();
            AnimalList = new List<AnimalNameDTO>();
            NoteList = new List<Note>();
            Note = new NoteDTO();
        }

        public void OnGet()
        {
            List<Species> species = _speciesService.GetAllSpeciesNames();

            SpeciesList = species.Select(s => new SpeciesNameDTO
            {
                SpeciesId = s.SpeciesId.ToString(),
                SpeciesName = s.SpeciesName
            }).ToList();

            List<Note> unfilteredNotes = _noteService.GetAllNotes();

            foreach (Note note in unfilteredNotes)
            {
                if(note.Employee.Id == Guid.Parse(User.FindFirstValue("NameIdentifier")) && note.Archive == false)
                {
                    NoteList.Add(note);
                }
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                string noteText = Note.NoteText;
                Guid employeeId = Guid.Parse(User.FindFirstValue("NameIdentifier"));
                Guid speciesId = Note.SelectedSpeciesId;

                Note note = new(noteText, employeeId, speciesId);
                _noteService.CreateNote(note);

                return Redirect(Statics.Routes.EMPLOYEEDASHBOARDNOTES);
            }
            return Page();
        }
    }
}
