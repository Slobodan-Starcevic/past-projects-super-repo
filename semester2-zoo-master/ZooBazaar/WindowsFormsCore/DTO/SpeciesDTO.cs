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
	public class SpeciesDTO
	{
		private ISpeciesRepository _speciesRepository;
		private SpeciesService speciesService;
		private AnimalRepository animalRepository;

		private Species? selectedSpecies;
		private readonly List<Species> listOfSpecies;

		private string speciesName;
		private int weight;
		private int size;
		private int speciesLifespan;
		private int speed;
		private int speciesIncubationTime;
		private Endangered speciesEndangeredLevel;
		private Enclosure speciesEnclosure;


		public SpeciesDTO()
		{
			_speciesRepository = new SpeciesRepository();
			speciesService = new SpeciesService(_speciesRepository);
			listOfSpecies = new List<Species>();
			animalRepository = new AnimalRepository();
			GetListFromRepo();
		}

		public void GetListFromRepo()
		{
			listOfSpecies.Clear();
			listOfSpecies.AddRange(speciesService.GetSpeciesList());
		}

		internal void SelectSpecies(Species? species)
		{
			this.selectedSpecies = species;
		}

		internal void EdditSpeciesName(Guid id, string text)
		{
			speciesService.EditSpeciesName(id, text);
		}

		internal void NewSpeciesName(string text)
		{
			this.speciesName = text;
		}

		internal void DeleteSelectedSpecies()
		{
            var animal = animalRepository.GetAllAnimalsBySpecies(selectedSpecies.SpeciesId);

            foreach (Animal a in animal)
            {
                animalRepository.DeleteAnimal(a.AnimalId);
            }
            speciesService.RemoveSpecies(selectedSpecies.SpeciesId);
			selectedSpecies = null;
		}

		internal void EdditSpeciesWeight(Guid id, decimal value)
		{
			speciesService.EdditSpeciesWeight(id, Convert.ToInt32(value));
		}

		internal void NewSpeciesWeight(decimal value)
		{
			this.weight = Convert.ToInt32(value);
		}

		internal void NewSpeciesSize(decimal value)
		{
			this.size = Convert.ToInt32(value);
		}

		internal void EdditSpeciesSize(Guid id, decimal value)
		{
			speciesService.EdditSpeciesSize(id, Convert.ToInt32(value));
		}

		internal void NewSpeciesLifeSpan(decimal value)
		{
			this.speciesLifespan = Convert.ToInt32(value);
		}

		internal void EdditSpeciesLifeSpan(Guid id, decimal value)
		{
			speciesService.EdditSpeciesLifeSpan(id, Convert.ToInt32(value));
		}

		internal void NewSpeciesSpeed(decimal value)
		{
			this.speed = Convert.ToInt32(value);
		}

		internal void EdditSPeciesSpeed(Guid id, decimal value)
		{
			speciesService.EdditSpeciesSpeed(id,Convert.ToInt32(value));
		}

		internal void NewSPeciesIncubation(decimal value)
		{
			this.speciesIncubationTime = Convert.ToInt32(value);
		}

		internal void EdditSpeciesIncubation(Guid id, decimal value)
		{
			speciesService.EdditSpeciesIncubationTime(id,Convert.ToInt32(value));
		}

		internal void NewSpeciesEndangeredL(Endangered endangered)
		{
			this.speciesEndangeredLevel = endangered;
		}

	

		internal void NewSpeceisEnclosure(Enclosure? enclosure)
		{
			this.speciesEnclosure = enclosure;
		}

		internal void EdditSpeciesEnclosure(Guid id, Enclosure? enclosure)
		{
			speciesService.EdditSpeciesEnclosure(id, enclosure);
		}

		internal void makeNewSpecies()
		{
			speciesService.CreateSpecies(speciesName, weight, size, speciesLifespan, speed, speciesIncubationTime, speciesEndangeredLevel, speciesEnclosure);
		}

		internal void EdditSpeciesShowStatus(bool v)
		{
			speciesService.EdditShowStatus(selectedSpecies.SpeciesId, v);
		}

        internal void EdditSpeciesEndangeredL(Guid id, Endangered endangered)
        {
            speciesService.EditEndangererd(id, endangered);
        }

		internal void DeselectSpecies()
		{
			this.selectedSpecies = null;
		}

		public List<Species> ListOfSpecies
		{
			get { return listOfSpecies; }
		}
		public Species SelectedSpecies
		{
			get { return selectedSpecies; }
		}
	}
}
