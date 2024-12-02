using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using BLL.Models;
using BLL.Services;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCore.DTO
{
	internal class ContentDTO
	{
		private List<Content> listContents;
		private IContentService contentService;

		private Content? selectedContent;

		private WebContentOrder order;
		private string title;
		private string text;
		private string imageUrl;

		public ContentDTO()
		{
			listContents = new List<Content>();
			IContentRepository contentRepository = new ContentRepository();
			contentService = new ContentService(contentRepository);
		}

		public List<Content> ListContents { get { return listContents; } }
		public Content SelectedContent{get{ return selectedContent;} }

		internal void DeleSelectedContent()
		{
			if(selectedContent != null)
			{
				contentService.DeleteContent(selectedContent.Id);
				selectedContent = null;
			}
			
		}

		internal void EdditContentImageUrl(Guid contentId, string text)
		{
			contentService.EdditContentImageUrl(contentId, text);
		}

		internal void EdditContentOrder(Guid contentId, WebContentOrder wCO)
		{
			contentService.EdditContentOrder(contentId, wCO);
		}

		internal void EdditContentText(Guid contentId, string text)
		{
			contentService.EdditContentText(contentId, text);
		}

		internal void EdditContentTitle(Guid contentId, string text)
		{
			contentService.EdditContentTitle(contentId, text);
		}

		internal void GetAnimalContent(Guid animalId)
		{
			
			listContents.Clear();
			listContents.AddRange(contentService.GetAnimalContents(animalId));
		}

		internal void GetEnclosureContents(Guid id)
		{
			listContents.Clear();
			listContents.AddRange(contentService.GetEnclosureContents(id));
		}

		internal void GetSpeciesContents(Guid speciesId)
		{
			listContents.Clear();
			listContents.AddRange(contentService.GetSpeciesContents(speciesId));
		}

		internal void NewAnimalContent(Animal selectedAnimal)
		{
			if(this.imageUrl == null)
			{
				this.imageUrl = "empty";
			}
			contentService.CreateAnimalContent(selectedAnimal, this.order, this.title, this.text, this.imageUrl);
			
		}
		

		internal void NewContentImageUrl(string text)
		{
			this.imageUrl= text;
		}

		internal void NewContentOrder(WebContentOrder wCO)
		{
			this.order = wCO;
		}

		internal void NewContentText(string text)
		{
			this.text= text;
		}

		internal void NewContentTitle(string text)
		{
			this.title = text;
		}

		internal void NewEnclosureContent(Enclosure selectedEnclosure)
		{
            if (this.imageUrl == null)
            {
                this.imageUrl = "empty";
            }
            contentService.CreateEnclosureContent(selectedEnclosure, this.order, this.title, this.text, this.imageUrl);
		}

		internal void NewSpeciesContent(Species selectedSpecies)
		{
            if (this.imageUrl == null)
            {
                this.imageUrl = "empty";
            }
            contentService.CreateSpeciesContent(selectedSpecies, this.order, this.title, this.text, this.imageUrl);
		}

		internal void SelectContent(Content content)
		{
			this.selectedContent = content;
		}


	}
}
