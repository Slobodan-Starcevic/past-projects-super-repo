using BLL.Interfaces.Services;
using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void CreateNewAnimal()
        {
            // Arrange
            Enclosure speciesEnclosure = new Enclosure("Enclosure 1");
            Guid speciesId = Guid.NewGuid();

            Species species = new Species("SpeciesName", 100, 200, 10, 50, 5, Endangered.VULNERABLE, speciesEnclosure);
            string animalName = "Lion";
            int weight = 150;
            int size = 180;
            int speed = 60;
            DateTime birthdate = new DateTime(2010, 1, 1);
            Sex sex = Sex.MALE;
            DateTime arrivalDate = DateTime.Now;
            DateTime? leaveDate = null;

            // Act
            Animal animal = new Animal(species, animalName, weight, size, speed, birthdate, sex, arrivalDate, leaveDate);

            // Assert
            Assert.IsNotNull(animal);
            Assert.AreNotEqual(Guid.Empty, animal.AnimalId);
            Assert.AreEqual(species.SpeciesId, animal.SpeciesId);
            Assert.AreEqual(species.SpeciesName, animal.SpeciesName);
            Assert.AreEqual(weight, animal.Weight);
            Assert.AreEqual(size, animal.Size);
            Assert.AreEqual(species.SpeciesLifespan, animal.SpeciesLifespan);
            Assert.AreEqual(speed, animal.Speed);
            Assert.AreEqual(species.SpeciesIncubationTime, animal.SpeciesIncubationTime);
            Assert.AreEqual(species.SpeciesEndangeredLevel, animal.SpeciesEndangeredLevel);
            Assert.AreEqual(species.SpeciesEnclosure, animal.SpeciesEnclosure);
            Assert.AreEqual(species.Url, animal.Url);
            Assert.AreEqual(animalName, animal.AnimalName);
            Assert.AreEqual(birthdate, animal.Birthdate);
            Assert.AreEqual(sex, animal.Sex);
            Assert.AreEqual(arrivalDate, animal.ArrivalDate);
            Assert.AreEqual(leaveDate, animal.LeaveDate);
            Assert.IsNotNull(animal.WebContent);
            Assert.AreEqual("/animal?id=" + animal.AnimalId, animal.Url);
            Assert.IsFalse(animal.ShowOnWeb);
        }
        [TestMethod]
        public void RetrieveAnimalFromDatabase()
        {
            // Arrange
            Endangered speciesEndangeredLevel = Endangered.VULNERABLE;
            Enclosure speciesEnclosure = new Enclosure("Enclosure 1");
            Guid speciesId = Guid.NewGuid();

            Species species = new Species(speciesId, "SpeciesName", 100, 200, 10, 50, 5, speciesEndangeredLevel, speciesEnclosure, "https://example.com/species");
            Guid animalId = Guid.NewGuid();
            string animalName = "Lion";
            int weight = 150;
            int size = 180;
            int speed = 60;
            DateTime birthdate = new DateTime(2010, 1, 1);
            Sex sex = Sex.MALE;
            DateTime arrivalDate = DateTime.Now;
            DateTime? leaveDate = null;
            string url = "/animal?id=" + animalId;

            // Act
            Animal animal = new Animal(species, animalId, animalName, weight, size, speed, birthdate, sex, arrivalDate, leaveDate, url);

            // Assert
            Assert.IsNotNull(animal);
            Assert.AreEqual(animalId, animal.AnimalId);
            Assert.AreEqual(species.SpeciesId, animal.SpeciesId);
            Assert.AreEqual(species.SpeciesName, animal.SpeciesName);
            Assert.AreEqual(weight, animal.Weight);
            Assert.AreEqual(size, animal.Size);
            Assert.AreEqual(species.SpeciesLifespan, animal.SpeciesLifespan);
            Assert.AreEqual(speed, animal.Speed);
            Assert.AreEqual(species.SpeciesIncubationTime, animal.SpeciesIncubationTime);
            Assert.AreEqual(species.SpeciesEndangeredLevel, animal.SpeciesEndangeredLevel);
            Assert.AreEqual(species.SpeciesEnclosure, animal.SpeciesEnclosure);
            Assert.AreEqual(species.Url, animal.Url);
            Assert.AreEqual(animalName, animal.AnimalName);
            Assert.AreEqual(birthdate, animal.Birthdate);
            Assert.AreEqual(sex, animal.Sex);
            Assert.AreEqual(arrivalDate, animal.ArrivalDate);
            Assert.AreEqual(leaveDate, animal.LeaveDate);
            Assert.IsNotNull(animal.WebContent);
            Assert.AreEqual(url, animal.Url);
            Assert.IsFalse(animal.ShowOnWeb);
        }

        [TestMethod]
        public void SetUrl_SetsUrlProperty()
        {
            // Arrange
            Guid SpeciesId = Guid.NewGuid();

            Species species = new Species(SpeciesId, "SpeciesName", 100, 200, 10, 50, 5, Endangered.ENDANGERED, new Enclosure("Enclosure 1"), "https://example.com/species");
            Animal animal = new Animal(species, "Lion", 150, 180, 60, new DateTime(2010, 1, 1), Sex.MALE, DateTime.Now, null);

            // Act
            animal.SetUrl(Guid.NewGuid());

            // Assert
            Assert.AreEqual($"/animal?id={animal.AnimalId}", animal.Url);
        }

        [TestMethod]
        public void SetShowOnWeb_SetsShowOnWebPropertyToFalse()
        {
            // Arrange
            Guid SpeciesId = Guid.NewGuid();

            Species species = new Species(SpeciesId, "SpeciesName", 100, 200, 10, 50, 5, Endangered.ENDANGERED, new Enclosure("Enclosure 1"), "https://example.com/species");
            Animal animal = new Animal(species, "Lion", 150, 180, 60, new DateTime(2010, 1, 1), Sex.MALE, DateTime.Now, null);

            // Act


            // Assert
            Assert.IsFalse(animal.ShowOnWeb);
        }

        //[TestMethod]
		/*public void ToString_ReturnsAnimalIdAndAnimalName()
        {
            // Arrange

            Guid SpeciesId = Guid.NewGuid();

            Species species = new Species(SpeciesId, "SpeciesName", 100, 200, 10, 50, 5, Endangered.ENDANGERED, new Enclosure("Enclosure 1"), "https://example.com/species");
            Guid animalId = Guid.NewGuid();
            string animalName = "Lion";
            Animal animal = new Animal(species, animalId, animalName, 150, 180, 60, new DateTime(2010, 1, 1), Sex.MALE, DateTime.Now, null, "/animal?id=" + animalId);

            // Act
            string result = animal.ToString();

            // Assert
            Assert.AreEqual($"{animalId.ToString().ToUpperInvariant()} - {animalName}", result);
        }*/




	}
}
