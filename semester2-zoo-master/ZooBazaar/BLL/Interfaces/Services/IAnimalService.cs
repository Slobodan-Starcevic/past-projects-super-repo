using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces.Services
{
    public interface IAnimalService
    {
        void CreateAnimal(Species species, string animalName, int weight, int size, int speed, DateTime birthdate, Sex sex, DateOnly arrivalDate, DateOnly? leaveDate);
        void EdditShowStatus(Guid Animal_id, bool v);
        void RemoveAnimal(Guid id);
        Animal GetAnimal(Guid id);
        List<Animal> GetAnimals();
		List<Animal> GetAnimalsBySpecies(Guid SpeciesId);
		List<Animal> GetAnimalsByEnclosure(Guid id, Guid enclosureId);
        void EditAnimalBirthdate(Guid id, DateTime birthdate);
        void EditAnimalName(Guid id, string name);
        void EditAnimalSex(Guid id, Sex sex);
        List<Animal> GetAllAnimalNamesBySpeciesId(string SpeciesId);
    }
}
