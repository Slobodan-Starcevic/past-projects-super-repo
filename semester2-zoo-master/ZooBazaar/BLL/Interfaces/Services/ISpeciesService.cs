using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Repositories;
using BLL.Models;

namespace BLL.Interfaces.Services
{
    public interface ISpeciesService
    {
        void CreateSpecies(string speciesName, int weight, int size, int speciesLifespan, int speed, int speciesIncubationTime,
            Endangered speciesEndangeredLevel, Enclosure speciesEnclosure);

        void EdditShowStatus(Guid id, bool v);
        void EditEnclosure(Guid id, Enclosure enclosure);

        void EditEndangererd(Guid id, Endangered endangered);

        void EditSpecies(Guid id, string speciesName, int weight, int size, int speciesLifespan, int speed, int speciesIncubationTime,
            Endangered speciesEndangeredLevel, Enclosure speciesEnclosure, string url);

        void EditSpeciesMaxAge(Guid id, string MaxAge);

        void EditSpeciesName(Guid id, string SpeciesName);
        Species GetSpecies(Guid id);

        List<Species> GetSpeciesList();
        void RemoveSpecies(Guid id);
        List<Species> GetAllSpeciesNames();

        List<Species> GetSpeciesFromEnclosure(Guid enclosure_id);
    }
}
