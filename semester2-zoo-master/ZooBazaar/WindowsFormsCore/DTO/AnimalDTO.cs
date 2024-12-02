using BLL.Interfaces.Repositories;
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
	public class AnimalDTO
	{
		private IAnimalRepository _animalRepository;
		private ContentRepository _contentRepository;
		private AnimalService animalService;
		private readonly List<Animal> listOfAnimals;
		private List<Animal> allAnimals;

		private Animal? selectedAnimal;
		private string animalName;
		private int weight;
		private int size;
		private int speed;
		private DateTime birthdate;
		private Sex sex;
		private DateOnly arrivalDate;
		private DateOnly? leaveDate;




		public AnimalDTO(AnimalRepository animalRepository, ContentRepository contentRepository)
		{
			_animalRepository= new AnimalRepository();
			animalService = new AnimalService(animalRepository, contentRepository);
			listOfAnimals= new List<Animal>();
			this.allAnimals = new List<Animal>();
		}
		public void GetListOfAnimals(Species selectedSpecies)
		{
			listOfAnimals.Clear();
			listOfAnimals.AddRange(animalService.GetAnimalsBySpecies(selectedSpecies.SpeciesId));
		}

		internal void SelectAnimal(Animal animal)
		{
			this.selectedAnimal= animal;
		}

		internal void NullSelectedAnimal()
		{
			selectedAnimal = null;
		}

		internal void newAnimalBirthDate(DateTime value)
		{
			this.birthdate= value;
		}

		internal void EdditAnimalBirthDate(Guid animalid, DateTime dateTime)
		{
			animalService.EditAnimalBirthdate(animalid, dateTime);
		}

		internal void NewAnimalName(string text)
		{
			this.animalName= text;
		}

	

		internal void EdditAnimalName(Guid animalid, string text)
		{
			animalService.EditAnimalName(animalid, text);
		}

		internal void NewAnimalSex(Sex sex)
		{
			this.sex= sex;
		}

		internal void EdditAnimalSex(Guid animalid, Sex sex)
		{
			animalService.EditAnimalSex(animalid,sex);
		}

		internal void NewAnimalArivalD(DateOnly dateOnly)
		{
			this.arrivalDate = dateOnly;
		}

		internal void EdditAnimalArrivalDate(Guid id, DateOnly dateOnly)
		{
			animalService.EdditAnimalArivalDate(id, dateOnly);
		}

		internal void NewAnimalLeaveDate(DateOnly dateOnly)
		{
			this.leaveDate = dateOnly;
		}

		internal void EdditAnimalLeaveD(Guid animalId, DateOnly dateOnly)
		{
			animalService.EdditAnimalLeaveD(animalId, dateOnly);
		}

		internal void makeNewAnimal(Species selectedSpecies)
		{ 
			animalService.CreateAnimal(selectedSpecies,this.animalName, this.weight, this.size, this.speed, this.birthdate, this.sex, this.arrivalDate, this.leaveDate);		  
		}

		internal void GetAllAnimals()
		{
			this.allAnimals.Clear();
			this.allAnimals.AddRange(animalService.GetAnimals());
		}

		internal void EdditShowStatus(bool v)
		{
			animalService.EdditShowStatus(selectedAnimal.AnimalId, v);
		}

		internal void NewAnimalWeight(int v)
		{
			this.weight= v;
		}

		internal void EdditAnimalWeight(Guid id, int v)
		{
			animalService.EditAnimalWeight(id, v); ;
		}

		internal void NewAnimalSize(int v)
		{
			this.size= v;
		}

		internal void EdditANimalSize(Guid id, int v)
		{
			animalService.EditAnimalSize(id, v);	
		}

		internal void NewAnimalSpeed(int v)
		{
			this.speed= v;
		}

		internal void EdditAnimalSpeed(Guid id, int v)
		{
			animalService.EditAnimalSpeed(id, v);
		}

		internal void DeselectAnimal()
		{
			this.selectedAnimal = null;
		}

		public List<Animal> ListOfAnimals { get { return listOfAnimals; } }
		public Animal SelectedAnimal { get { return selectedAnimal; } }
		public List<Animal> AllAnimals { get { return allAnimals; } }
	}
}
