using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        void CreateAnimal(Animal animal);
        Animal GetAnimal(Guid id);
        List<Animal> GetAnimalsFromTask(Guid task_id);
        List<Animal> GetAllAnimalsBySpecies(Guid speciesId);
        List<Animal> GetAnimalsByEnclosure(Guid id, Guid enclosureId);
        List<Animal> GetAnimals();
        void DeleteAnimal(Guid id);
        void EditAnimalBirthdate(Guid id, DateTime birthdate);
        void EditAnimalName(Guid id, string name);
        void EditAnimalSex(Guid id, Sex sex);
        void EdditAnimalLeaveD(Guid animalId, DateOnly dateOnly);
        void EdditAnimalArivalDate(Guid id, DateOnly dateOnly);
        void EditAnimalWeight(Guid id, int v);
        void EditAnimalSize(Guid id, int v);
        void EditAnimalSpeed(Guid id, int v);
        void EdditShowStatus(Guid Animal_id, bool v);
        List<Animal> GetAllAnimalNamesBySpeciesId(string speciesId);
    }
}
