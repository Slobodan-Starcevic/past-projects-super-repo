using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface IContentService
    {
        void CreateAnimalContent(Animal animal, WebContentOrder order, string title, string text, string imageUrl);
        void CreateSpeciesContent(Species species, WebContentOrder order, string title, string text, string imageUrl);
        void CreateEnclosureContent(Enclosure enclosure, WebContentOrder order, string title, string text, string imageUrl);
        List<Content> GetAnimalContents(Guid animal_id);
        List<Content> GetSpeciesContents(Guid species_id);
        List<Content> GetEnclosureContents(Guid enclosure_id);
        void UpdateAnimalContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid animal_id);
        void UpdateSpeciesContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid species_id);
        void UpdateEnclosureContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid enclosure_id);
        void DeleteContent(Guid content_id);
        void EdditContentTitle(Guid contentId, string text);
        void EdditContentText(Guid contentId, string text);
        void EdditContentOrder(Guid contentId, WebContentOrder wCO);
        void EdditContentImageUrl(Guid contentId, string text);
    }
}
