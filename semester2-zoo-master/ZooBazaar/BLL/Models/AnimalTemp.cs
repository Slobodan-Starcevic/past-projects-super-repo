using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public  class AnimalTemp
    {
        private int id;
        private string name;
        private string url;
        private Species species;
        private Enclosure enclosure;

        public AnimalTemp(int id, string name, Enclosure enclosure, Species species)
        {
            this.id = id;
            this.name = name;
            this.enclosure = enclosure;
            this.url = $"/animal?id={id}";
            this.species = species;
        }

        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public string Url { get { return url; } }
        public Species Species { get { return species; } }
        public Enclosure Enclosure { get { return enclosure; } }

    }
}
