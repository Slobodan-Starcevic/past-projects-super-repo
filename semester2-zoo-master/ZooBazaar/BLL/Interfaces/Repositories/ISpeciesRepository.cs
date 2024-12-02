using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces.Repositories
{
    public interface ISpeciesRepository
    {
        void CreateSpecies(Species species);
        List<Species> GetSpecies();
        Species GetSpeciesByInt(Guid id);
        List<Species> GetSpeciesFromEnclosure(Guid enclosure_id);
        List<Species> GetSpeciesFromTask(Guid task_id);
        void EditSpecies(Species species, Guid id);
        void DeleteSpecies(Guid id);
        public void EditSpeciesMaxAge(Guid id, string MaxAge);
        public void EditSpeciesName(Guid id, string SpeciesName);
        Species GetSpeciesByAnimalid(Guid animal_id);
        void EdditShowStatus(Guid id, bool v);
        void EdditSpeciesEnclosure(Guid id, Enclosure? enclosure);
        void EdditSpeciesIncubationTime(Guid id, int v);
        void EdditSpeciesLifeSpan(Guid id, int v);
        void EdditSpeciesShowStatus(Guid id, bool v);
        void EdditSpeciesSize(Guid id, int v);
        void EdditSpeciesSpeed(Guid id, int v);
        void EdditSpeciesWeight(Guid id, int v);
        void EditEnclosure(Guid id, Enclosure enclosure);
        void EditEndangered(Guid id, Endangered endangered);
        List<Species> GetAllSpeciesNames();

    }
}
