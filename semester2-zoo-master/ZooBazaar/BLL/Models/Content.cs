using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	public class Content
	{
		private Guid id;
		private Enclosure enclosure;
		private Species species;
		private Animal animal;
		private WebContentOrder order;
		private string title;
		private string text;
		private string imageUrl;

        //Constructors for enclosure content
		public Content(Enclosure enclosure, WebContentOrder order, string title, string text, string imageUrl)
		{
			this.Id = Guid.NewGuid();
			this.Enclosure = enclosure;
			this.Order = order;
			this.Title = title;
			this.Text = text;
			this.ImageUrl = imageUrl;
		}

        public Content(Guid id, Enclosure enclosure, WebContentOrder order, string title, string text, string imageUrl)
			:this(enclosure, order, title, text, imageUrl)
        {
			this.Id = id;
        }

        //Constructors for species content
        public Content(Species species, WebContentOrder order, string title, string text, string imageUrl)
        {
            this.Id = Guid.NewGuid();
            this.Species = species;
            this.Order = order;
            this.Title = title;
            this.Text = text;
            this.ImageUrl = imageUrl;
        }

        public Content(Guid id, Species species, WebContentOrder order, string title, string text, string imageUrl)
            : this(species, order, title, text, imageUrl)
        {
            this.Id = id;
        }

        //Constructors for animal content
        public Content(Animal animal, WebContentOrder order, string title, string text, string imageUrl)
        {
            this.Id = Guid.NewGuid();
            this.Animal = animal;
            this.Order = order;
            this.Title = title;
            this.Text = text;
            this.ImageUrl = imageUrl;
        }

        public Content(Guid id, Animal animal, WebContentOrder order, string title, string text, string imageUrl)
            : this(animal, order, title, text, imageUrl)
        {
            this.Id = id;
        }

        public Guid Id { get => id; private set => id = value; }
        public Enclosure Enclosure { get => enclosure; private set => enclosure = value; }
        public Species Species { get => species; private set => species = value; }
        public Animal Animal { get => animal; private set => animal = value; }
        public WebContentOrder Order { get => order; private set => order = value; }
        public string Title { get => title; private set => title = value; }
        public string Text { get => text; private set => text = value; }
        public string ImageUrl { get => imageUrl; private set => imageUrl = value; }

        public override string ToString()
        {
            return Order.ToString();
        }
    }
}
