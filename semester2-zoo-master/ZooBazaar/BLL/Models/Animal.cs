using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Animal : Species
    {
        private Guid animalId;
        private string animalName;
        private DateTime birthdate;
        private Sex sex;
        private DateTime arrivalDate;
        private DateTime? leaveDate;

        private new List<Content>? webContent;
        private new string url;
        private new bool showOnWeb;
        private new string pfpURL;

        //Constructor for new animal creation
        public Animal(Species species, string animalName, int weight, int size, int speed, DateTime birthdate, Sex sex, DateTime arrivalDate, DateTime? leaveDate)
            :base(species.SpeciesId, species.SpeciesName, weight, size, species.SpeciesLifespan, speed, species.SpeciesIncubationTime, species.SpeciesEndangeredLevel, species.SpeciesEnclosure, species.Url)
        {
            Guid newGuid = Guid.NewGuid();
            this.animalId = newGuid;
            this.animalName = animalName;
            this.birthdate = birthdate;
            this.sex = sex;
            this.arrivalDate = arrivalDate;
            this.leaveDate = leaveDate;
            
            SetUrl(newGuid);
            SetShowOnWeb();
        }

        //Constructor for animal retrieval from database
        public Animal(Species species, Guid animalId, string animalName, int weight, int size, int speed, DateTime birthdate, Sex sex, DateTime arrivalDate, DateTime? leaveDate, string url)
            : base(species.SpeciesId, species.SpeciesName, weight, size, species.SpeciesLifespan, speed, species.SpeciesIncubationTime, species.SpeciesEndangeredLevel, species.SpeciesEnclosure, species.Url)
        {
            this.AnimalId = animalId;
            this.AnimalName = animalName;
            this.Birthdate = birthdate;
            this.Sex = sex;
            this.ArrivalDate = arrivalDate;
            this.LeaveDate = leaveDate;
            this.AnimalId = animalId;
            this.AnimalName = animalName;
            this.Birthdate = birthdate;
            this.Sex = sex;
            this.ArrivalDate = arrivalDate;
            this.LeaveDate = leaveDate;
            this.Url = url;
        }

        public Animal(Species species, Guid animalId, string animalName, int weight, int size, int speed, DateTime birthdate, Sex sex, DateTime arrivalDate, DateTime? leaveDate, 
            string url, bool showOnWeb, string pfpURL)
            : base(species.SpeciesId, species.SpeciesName, weight, size, species.SpeciesLifespan, speed, species.SpeciesIncubationTime,
            species.SpeciesEndangeredLevel, species.SpeciesEnclosure, url, showOnWeb, pfpURL)
        {
            this.AnimalId = animalId;
            this.AnimalName = animalName;
            this.Birthdate = birthdate;
            this.Sex = sex;
            this.ArrivalDate = arrivalDate;
            this.LeaveDate = leaveDate;
        }

        //CTOR FOR ANIMAL OBJECT CREATION WITH NAME AND ID ONLY
        public Animal(Guid id, string animalName)
            :base(id, animalName)
        {
        }

        public override void SetUrl(Guid id)
        {
            this.Url = $"/animal?id={id}";
        }

        public override void SetShowOnWeb()
        {
            this.ShowOnWeb = false;
        }

        public override string ToString()
        {
            return $"{animalId.ToString().ToUpperInvariant()} - {animalName}";
        }

        public Guid AnimalId { get => animalId; private set => animalId = value; }
        public string AnimalName { get => animalName; private set => animalName = value; }
        public DateTime Birthdate { get => birthdate; private set => birthdate = value; }
        public Sex Sex { get => sex; private set => sex = value; }
        public DateTime ArrivalDate { get => arrivalDate; private set => arrivalDate = value; }
        public DateTime? LeaveDate { get => leaveDate; private set => leaveDate = value; }

        public override List<Content>? WebContent { get => webContent; protected set => webContent = value; }
        public override string Url { get => url; protected set => url = value; }
        public override bool ShowOnWeb { get => showOnWeb; protected set => showOnWeb = value; }
        public override string PfpURL { get => pfpURL; protected set => pfpURL = value; }
    }
}
