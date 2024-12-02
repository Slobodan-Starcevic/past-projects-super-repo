using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using BLL.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IContentRepository contentRepository;

        public AnimalService(IAnimalRepository animalRepository, IContentRepository contentRepository)
        {
            this._animalRepository = animalRepository;
            this.contentRepository = contentRepository;

		}      

        public Animal GetAnimal(Guid id)
        {
            return _animalRepository.GetAnimal(id);
        }

        public void RemoveAnimal(Guid Animalid)
        {
            _animalRepository.DeleteAnimal(Animalid);
        }   
        public void EditAnimalBirthdate(Guid id, DateTime birthdate)
        {
            _animalRepository.EditAnimalBirthdate(id, birthdate);
        }

        public void EditAnimalName(Guid id, string name)
        {
            _animalRepository.EditAnimalName(id, name);
        }

        public void EditAnimalSex(Guid id, Sex sex)
        {
            _animalRepository.EditAnimalSex(id, sex);
        }

		public List<Animal> GetAnimalsByEnclosure(Guid id, Guid enclosureId)
		{
			return _animalRepository.GetAnimalsByEnclosure(id, enclosureId);
		}

		public List<Animal> GetAnimalsBySpecies(Guid SpeciesId)
		{
            return _animalRepository.GetAllAnimalsBySpecies(SpeciesId);
		}
         
        public void CreateAnimal(Species species, string animalName, int weight, int size, int speed, DateTime birthdate, Sex sex, DateOnly arrivalDate, DateOnly? leaveDate)
        {
            DateTime convertedArrivalDate = new DateTime(arrivalDate.Year, arrivalDate.Month, arrivalDate.Day);
            DateTime? convertedLeaveDate = leaveDate != null ? new DateTime(leaveDate.Value.Year, leaveDate.Value.Month, leaveDate.Value.Day) : (DateTime?)null;

            Animal animal = new Animal(species, animalName, weight, size, speed, birthdate, sex, convertedArrivalDate, convertedLeaveDate);

            _animalRepository.CreateAnimal(animal);
        }



        public IEnumerable<Content> GetAnimalContents(Guid idAnimal)
		{
			return contentRepository.GetAnimalContents(idAnimal);
		}

		public void CreateAnimalContent(Content content, Guid iD)
		{
			contentRepository.CreateAnimalContent(content, iD);
		}

		public void DeleteContent(Guid iD)
		{
			contentRepository.DeleteContent(iD);
		}

		public void UpdateAnimalContentTitle(Guid id, string text)
		{
			contentRepository.UpdateContentTitle(id, text);
		}

		public void UpdateAnimalContenttext(Guid id, string text)
		{
			contentRepository.UpdateContenttext(id, text);
		}

		public void EditAnimalContentPhotoUrl(Guid id, string text)
		{
			contentRepository.UpdateContentPhotoUrl(id, text);
		}

		public List<Animal> GetAnimals()
		{
			return _animalRepository.GetAnimals();
		}
        public void EdditAnimalLeaveD(Guid animalId, DateOnly dateOnly)
        {
            _animalRepository.EdditAnimalLeaveD(animalId,dateOnly);
        }

        public void EdditAnimalArivalDate(Guid id, DateOnly dateOnly)
        {
            _animalRepository.EdditAnimalArivalDate(id,dateOnly);
        }
        public void EditAnimalWeight(Guid id, int v)
        {
            _animalRepository.EditAnimalWeight(id,v);
        }

        public void EditAnimalSize(Guid id, int v)
        {
            _animalRepository.EditAnimalSize(id,v);
        }

        public void EditAnimalSpeed(Guid id, int v)
        {
            _animalRepository.EditAnimalSpeed(id,v);
        }

        public void EdditShowStatus(Guid Animal_id, bool v)
        {
            _animalRepository.EdditShowStatus(Animal_id,v);
        }

        public List<Animal> GetAllAnimalNamesBySpeciesId(string speciesId)
        {
            return _animalRepository.GetAllAnimalNamesBySpeciesId(speciesId);
        }
    }
}
