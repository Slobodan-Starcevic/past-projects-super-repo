using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly ISpeciesRepository _speciesRepository;

        public SpeciesService(ISpeciesRepository speciesRepository)
        {
            _speciesRepository = speciesRepository;
        }
     

        public void CreateSpecies(string speciesName, int weight, int size, int speciesLifespan, int speed, int speciesIncubationTime,
            Endangered speciesEndangeredLevel, Enclosure speciesEnclosure)
        {
            Species species = new Species(speciesName, weight, size, speciesLifespan, speed, speciesIncubationTime,
            speciesEndangeredLevel, speciesEnclosure);

            _speciesRepository.CreateSpecies(species);
        }

		
		public void EditSpecies(Guid id, string speciesName, int weight, int size, int speciesLifespan, int speed, int speciesIncubationTime, 
            Endangered speciesEndangeredLevel, Enclosure speciesEnclosure, string url)
        {
            Species species = new Species(id, speciesName, weight, size, speciesLifespan, speed, speciesIncubationTime,
            speciesEndangeredLevel, speciesEnclosure, url);

            _speciesRepository.EditSpecies(species, id);
        }

		public void EditSpeciesMaxAge(Guid id, string MaxAge)
		{
			_speciesRepository.EditSpeciesMaxAge(id, MaxAge);
		}

		public void EditSpeciesName(Guid id, string SpeciesName)
		{
			EditSpeciesMaxAge(id, SpeciesName);
		}


		public Species GetSpecies(Guid id)
        {
            return _speciesRepository.GetSpeciesByInt(id);
        }

        public List<Species> GetSpeciesList()
        {
            return _speciesRepository.GetSpecies();
        }
		public void RemoveSpecies(Guid id)
        {
            _speciesRepository.DeleteSpecies(id);
        }
  

        public void EdditShowStatus(Guid id, bool v)
        {
            _speciesRepository.EdditShowStatus(id, v);
        }

        public void EdditSpeciesEnclosure(Guid id, Enclosure? enclosure)
        {
            _speciesRepository.EdditSpeciesEnclosure(id, enclosure);
        }

        public void EdditSpeciesIncubationTime(Guid id, int v)
        {
            _speciesRepository.EdditSpeciesIncubationTime(id,v);
        }

        public void EdditSpeciesLifeSpan(Guid id, int v)
        {
            _speciesRepository.EdditSpeciesLifeSpan(id,v);
        }

        public void EdditSpeciesSize(Guid id, int v)
        {
            _speciesRepository.EdditSpeciesSize(id,v);
        }

        public void EdditSpeciesSpeed(Guid id, int v)
        {
            _speciesRepository.EdditSpeciesSpeed(id,v);
        }
        public void EdditSpeciesWeight(Guid id, int v)
        {
            _speciesRepository.EdditSpeciesWeight(id,v);
        }
        public void EditEnclosure(Guid id, Enclosure enclosure)
        {
            _speciesRepository.EditEnclosure(id, enclosure);
        }
        public void EditEndangererd(Guid id, Endangered endangered)
        {
            _speciesRepository.EditEndangered(id, endangered);
        }
      
        public List<Species> GetAllSpeciesNames()
        {
            return _speciesRepository.GetAllSpeciesNames();
        }

        public List<Species> GetSpeciesFromEnclosure(Guid enclosure_id)
        {
            return _speciesRepository.GetSpeciesFromEnclosure(enclosure_id);
        }
    }
}
