using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class SpeciesTest
    {
        [TestMethod]
        public void CreateNewSpecies()
        {
            // Arrange
            string speciesName = "Lion";
            int weight = 200;
            int size = 150;
            int speciesLifespan = 15;
            int speed = 80;
            int speciesIncubationTime = 90;
            Endangered speciesEndangeredLevel = Endangered.VULNERABLE;
            Enclosure speciesEnclosure = new Enclosure("Enclosure 1");

            // Act
            Species species = new Species(speciesName, weight, size, speciesLifespan, speed, speciesIncubationTime,
                speciesEndangeredLevel, speciesEnclosure);

            // Assert
            Assert.IsNotNull(species);
            Assert.AreEqual(speciesName, species.SpeciesName);
            Assert.AreEqual(weight, species.Weight);
            Assert.AreEqual(size, species.Size);
            Assert.AreEqual(speciesLifespan, species.SpeciesLifespan);
            Assert.AreEqual(speed, species.Speed);
            Assert.AreEqual(speciesIncubationTime, species.SpeciesIncubationTime);
            Assert.AreEqual(speciesEndangeredLevel, species.SpeciesEndangeredLevel);
            Assert.AreEqual(speciesEnclosure, species.SpeciesEnclosure);
            Assert.IsFalse(species.ShowOnWeb);
        }
        [TestMethod]
        public void RetrieveSpeciesFromDatabase()
        {
            // Arrange
            Guid speciesId = Guid.NewGuid();
            string speciesName = "Tiger";
            int weight = 250;
            int size = 125;
            int speciesLifespan = 15;
            int speed = 80;
            int speciesIncubationTime = 90;
            Endangered speciesEndangeredLevel = Endangered.VULNERABLE;
            Enclosure speciesEnclosure = new Enclosure("Enclosure 1");
            string url = "/species?id=" + speciesId;

            // Act
            Species species = new Species(speciesId, speciesName, weight, size, speciesLifespan, speed, speciesIncubationTime,
                speciesEndangeredLevel, speciesEnclosure, url);

            // Assert
            Assert.IsNotNull(species);
            Assert.AreEqual(speciesId, species.SpeciesId);
            Assert.AreEqual(speciesName, species.SpeciesName);
            Assert.AreEqual(weight, species.Weight);
            Assert.AreEqual(size, species.Size);
            Assert.AreEqual(speciesLifespan, species.SpeciesLifespan);
            Assert.AreEqual(speed, species.Speed);
            Assert.AreEqual(speciesIncubationTime, species.SpeciesIncubationTime);
            Assert.AreEqual(speciesEndangeredLevel, species.SpeciesEndangeredLevel);
            Assert.AreEqual(speciesEnclosure, species.SpeciesEnclosure);
            Assert.AreEqual(url, species.Url);
        }
        [TestMethod]
        public void AddContentToSpecies()
        {
            // Arrange
            WebContentOrder order = new WebContentOrder();
            Enclosure enclosure = new Enclosure("Jungle");
            Species species = new Species("Lion", 200, 150, 15, 80, 90, Endangered.VULNERABLE, new Enclosure("Enclosure 1"));
            Animal animal = new Animal(species, "Jaguar", species.Weight, species.Size, species.Speed, new DateTime(2001, 6, 15), Sex.MALE, new DateTime(2005, 6, 15), null);
            
            Content content = new Content(animal, order, "Title", "Text", "ImageUrl");

            // Act
            species.AddContent(new List<Content> { content });

            // Assert
            Assert.IsNotNull(species.WebContent);
            Assert.AreEqual(1, species.WebContent.Count);
            Assert.AreEqual(content, species.WebContent[0]);
        }

        [TestMethod]
        public void SetUrlForSpecies()
        {
            // Arrange
            Species species = new Species("Lion", 200, 150, 15, 80, 90, Endangered.VULNERABLE, new Enclosure("Enclosure 1"));
            Guid speciesId = Guid.NewGuid();
            string expectedUrl = $"/species?id={speciesId}";

            // Act
            species.SetUrl(speciesId);

            // Assert
            Assert.AreEqual(expectedUrl, species.Url);
        }

        [TestMethod]
        public void SetShowOnWebForSpecies()
        {
            // Arrange
            Species species = new Species("Lion", 200, 150, 15, 80, 90, Endangered.VULNERABLE, new Enclosure("Enclosure 1"));

            // Act
            species.SetShowOnWeb();

            // Assert
            Assert.IsFalse(species.ShowOnWeb);
        }

        [TestMethod]
        public void ToStringForSpecies()
        {
            // Arrange
            Guid speciesId = Guid.NewGuid();
            string speciesName = "Lion";
            Species species = new Species(speciesId, speciesName, 200, 150, 15, 80, 90, Endangered.VULNERABLE, new Enclosure("Enclosure 1"), "");

            // Act
            string result = species.ToString();

            // Assert
            Assert.AreEqual($"{speciesId.ToString().ToUpperInvariant()} - {speciesName}", result);
        }





    }
}
