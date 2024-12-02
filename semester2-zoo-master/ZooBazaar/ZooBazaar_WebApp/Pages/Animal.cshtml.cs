using BLL.Interfaces.Services;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class AnimalModel : PageModel
    {
        private readonly IAnimalService _animalService;
        private readonly IContentService _contentService;
        public Animal? Animal { get; set; }
        public List<Content> AnimalContent { get; set; }

        public List<Animal> Animals { get; set; }
        public Dictionary<Guid, string> ContentList { get; set; }

        public AnimalModel(IAnimalService animalService, IContentService contentService)
        {
            _animalService = animalService;
            Animals = new List<Animal>();
            AnimalContent = new List<Content>();
            _contentService = contentService;
            ContentList = new Dictionary<Guid, string>();
        }

        public void OnGet(Guid id)
        {
            Animal = _animalService.GetAnimal(id);
            AnimalContent = _contentService.GetAnimalContents(id);

            var animals = _animalService.GetAnimals();

            foreach (var animal in animals)
            {
                if(animal.SpeciesName == Animal.SpeciesName)
                {
                    if(animal.ShowOnWeb == true)
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
}
