using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public void CreateAnimalContent(Animal animal, WebContentOrder order, string title, string text, string imageUrl)
        {
            Content content = new Content(animal, order, title, text, imageUrl);

            _contentRepository.CreateAnimalContent(content, animal.AnimalId);
        }

        public void CreateEnclosureContent(Enclosure enclosure, WebContentOrder order, string title, string text, string imageUrl)
        {
            Content content = new Content(enclosure, order, title, text, imageUrl);

            _contentRepository.CreateEnclosureContent(content, enclosure.Id);
        }

        public void CreateSpeciesContent(Species species, WebContentOrder order, string title, string text, string imageUrl)
        {
            Content content = new Content(species, order, title, text, imageUrl);

            _contentRepository.CreateSpeciesContent(content, species.SpeciesId);
        }

        public void DeleteContent(Guid content_id)
        {
            _contentRepository.DeleteContent(content_id);
        }
        public List<Content> GetAnimalContents(Guid animal_id)
        {
            return _contentRepository.GetAnimalContents(animal_id);
        }

        public List<Content> GetEnclosureContents(Guid enclosure_id)
        {
            return _contentRepository.GetEnclosureContents(enclosure_id);
        }

        public List<Content> GetSpeciesContents(Guid species_id)
        {
            return _contentRepository.GetSpeciesContents(species_id);
        }
        public void EdditContentImageUrl(Guid contentId, string text)
        {
            _contentRepository.UpdateContentPhotoUrl(contentId, text);
        }

    

        public void EdditContentText(Guid contentId, string text)
        {
           _contentRepository.UpdateContenttext(contentId, text);
        }

        public void EdditContentTitle(Guid contentId, string text)
        {
            _contentRepository.UpdateContentTitle(contentId, text);
        }
		public void UpdateAnimalContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid animal_id)
		{
            _contentRepository.UpdateAnimalContent(order,title,contentText,photoUrl,animal_id);
		}

		public void UpdateEnclosureContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid enclosure_id)
		{
            _contentRepository.UpdateEnclosureContent(order, title, contentText, photoUrl, enclosure_id);
		}

		public void UpdateSpeciesContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid species_id)
		{
            _contentRepository.UpdateSpeciesContent(order,title,contentText,photoUrl,species_id);
		}
        public void EdditContentOrder(Guid contentId, WebContentOrder wCO)
        {
            _contentRepository.EdditContentOrder(contentId, wCO);
        }
    }
}
