using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repositories
{
    public interface IContentRepository
    {
        void CreateAnimalContent(Content content, Guid animal_id);
        void CreateSpeciesContent(Content content, Guid species_id);
        void CreateEnclosureContent(Content content, Guid enclosure_id);
        List<Content> GetAnimalContents(Guid animal_id);
        List<Content> GetSpeciesContents(Guid species_id);
        List<Content> GetEnclosureContents(Guid enclosure_id);
		void UpdateContentTitle(Guid content_Id, string text);
		void UpdateContenttext(Guid content_Id, string text);
		void UpdateContentPhotoUrl(Guid content_Id, string text);
		void DeleteContent(Guid content_id);
        void UpdateAnimalContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid animal_id);
        void UpdateEnclosureContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid enclosure_id);
        void UpdateSpeciesContent(WebContentOrder order, string title, string contentText, string photoUrl, Guid species_id);
        void EdditContentOrder(Guid contentId, WebContentOrder wCO);
       

    }
}
