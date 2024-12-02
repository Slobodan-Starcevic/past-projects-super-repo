using BLL.Interfaces.Services;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class SpeciesModel : PageModel
    {
        private readonly ISpeciesService _speciesService;
        private readonly IAnimalService _animalService;
        private readonly IContentService _contentService;
        public Species? Species { get; set; }

        public List<Content> SpeciesContent { get; set; }

        public List<Animal> Animals { get; set; }
        public Dictionary<Guid, string> ContentList { get; set; }

        public SpeciesModel(ISpeciesService speciesService, IAnimalService animalService, IContentService contentService)
        {
            Animals = new List<Animal>();
            SpeciesContent = new List<Content>();
            _speciesService = speciesService;
            _animalService = animalService;
            _contentService = contentService;
            ContentList = new Dictionary<Guid, string>();
        }

        public void OnGet(Guid id)
        {
            Species = _speciesService.GetSpecies(id);
            SpeciesContent = _contentService.GetSpeciesContents(id);

            var rawAnimals = _animalService.GetAnimalsBySpecies(id);

            foreach (var animal in rawAnimals)
            {
                if (animal.ShowOnWeb == true)
                {
                    var content = _contentService.GetAnimalContents(animal.AnimalId);
                    if (content != null)
                    {
                        ContentList.Add(animal.AnimalId, content[0].ImageUrl);
                    }

                    Animals.Add(animal);
                }
            }
        }
    }
}
