using BLL.Interfaces.Services;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class EnclosuresModel : PageModel
    {
        private readonly IEnclosureService _enclosureService;
        private readonly ISpeciesService _speciesService;
        private readonly IContentService _contentService;
        public Enclosure Enclosure { get; set; }
        public List<Content> EnclosureContent { get; set; }

        public List<Species> Species { get; set; }
        public Dictionary<Guid, string> ContentList { get; set; }

        public EnclosuresModel(IEnclosureService enclosureService, ISpeciesService speciesService, IContentService contentService)
        {
            _enclosureService = enclosureService;
            _speciesService = speciesService;
            Species = new List<Species>();
            EnclosureContent = new List<Content>();
            _contentService = contentService;
            ContentList = new Dictionary<Guid, string>();
        }

        public void OnGet(Guid id)
        {
            Enclosure = _enclosureService.GetEnclosure(id);
            EnclosureContent = _contentService.GetEnclosureContents(id);

            var rawSpecies = _speciesService.GetSpeciesFromEnclosure(id);
            foreach (var speciesItem in rawSpecies)
            {
                if (speciesItem.ShowOnWeb == true)
                {
                    var content = _contentService.GetSpeciesContents(speciesItem.SpeciesId);
                    if (content != null)
                    {
                        ContentList.Add(speciesItem.SpeciesId, content[0].ImageUrl);
                    }

                    Species.Add(speciesItem);
                }
            }
        }
    }
}
