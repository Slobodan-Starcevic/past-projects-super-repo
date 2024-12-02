using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Species
    {
        private Guid speciesId;
        private string speciesName;
        private int weight;
        private int size;
        private int speciesLifespan;
        private int speed;
        private int speciesIncubationTime;
        private Endangered speciesEndangeredLevel;
        private Enclosure speciesEnclosure;

        protected List<Content>? webContent;
        protected string url;
        protected bool showOnWeb;
        protected string pfpURL;

        //Constructor for new species creation
        public Species(string speciesName, int weight, int size, int speciesLifespan, int speed, int speciesIncubationTime, 
            Endangered speciesEndangeredLevel, Enclosure speciesEnclosure)
        {
            Guid newGuid = Guid.NewGuid();
            this.SpeciesId = newGuid;
            this.SpeciesName = speciesName;
            this.Weight = weight;
            this.Size = size;
            this.SpeciesLifespan = speciesLifespan;
            this.Speed = speed;
            this.SpeciesIncubationTime = speciesIncubationTime;
            this.SpeciesEndangeredLevel = speciesEndangeredLevel;
            this.SpeciesEnclosure = speciesEnclosure;
            
            SetUrl(newGuid);
            SetShowOnWeb();
        }

        //Constructor for species retrieval from database
        public Species(Guid speciesId, string speciesName, int weight, int size, int speciesLifespan, int speed, int speciesIncubationTime, 
            Endangered speciesEndangeredLevel, Enclosure speciesEnclosure, string url)
        {
            this.SpeciesId = speciesId;
            this.SpeciesName = speciesName;
            this.Weight = weight;
            this.Size = size;
            this.SpeciesLifespan = speciesLifespan;
            this.Speed = speed;
            this.SpeciesIncubationTime = speciesIncubationTime;
            this.SpeciesEndangeredLevel = speciesEndangeredLevel;
            this.SpeciesEnclosure = speciesEnclosure;
            this.Url = url;
        }

        public Species(Guid speciesId, string speciesName, int weight, int size, int speciesLifespan, int speed, int speciesIncubationTime,
            Endangered speciesEndangeredLevel, Enclosure speciesEnclosure, string url, bool showOnWeb, string pfpURL)
        {
            this.SpeciesId = speciesId;
            this.SpeciesName = speciesName;
            this.Weight = weight;
            this.Size = size;
            this.SpeciesLifespan = speciesLifespan;
            this.Speed = speed;
            this.SpeciesIncubationTime = speciesIncubationTime;
            this.SpeciesEndangeredLevel = speciesEndangeredLevel;
            this.SpeciesEnclosure =speciesEnclosure;
            this.Url = url;
            this.ShowOnWeb = showOnWeb;
            this.PfpURL = pfpURL;
        }

        //CTOR FOR SPECIES OBJECT WITH ID AND NAME ONLY
        public Species(Guid id, string speciesName)
        {
            this.SpeciesId= id;
            this.SpeciesName= speciesName;
        }

        public void AddContent(List<Content> contents)
        {
            webContent.AddRange(contents);
        }

        public virtual void SetUrl(Guid id)
        {
            this.Url = $"/species?id={id}";
        }

        public virtual void SetShowOnWeb()
        {
            this.ShowOnWeb = false;
        }

        public override string ToString()
        {
            return $"{SpeciesId.ToString().ToUpperInvariant()} - {SpeciesName}";
        }

        public Guid SpeciesId { get => speciesId; private set => speciesId = value; }
        public string SpeciesName { get => speciesName; private set => speciesName = value; }
        public int Weight { get => weight; private set => weight = value; }
        public int Size { get => size; private set => size = value; }
        public int SpeciesLifespan { get => speciesLifespan; private set => speciesLifespan = value; }
        public int Speed { get => speed; private set => speed = value; }
        public int SpeciesIncubationTime { get => speciesIncubationTime; private set => speciesIncubationTime = value; }
        public Endangered SpeciesEndangeredLevel { get => speciesEndangeredLevel; private set => speciesEndangeredLevel = value; }
        public Enclosure SpeciesEnclosure { get => speciesEnclosure; private set => speciesEnclosure = value; }

        public virtual List<Content>? WebContent { get => webContent; protected set => webContent = value; }
        public virtual string Url { get => url; protected set => url = value; }
        public virtual bool ShowOnWeb { get => showOnWeb; protected set => showOnWeb = value; }
        public virtual string PfpURL { get => pfpURL; protected set => pfpURL = value; }
    }
}
