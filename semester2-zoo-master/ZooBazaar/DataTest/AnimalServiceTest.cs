using System;
using System.Collections.Generic;

using BLL.Interfaces.Services;
using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using BLL.Interfaces.Repositories;
using BLL.Services;
using NUnit.Framework;

namespace DataTest
{
    [TestClass]
    public class AnimalServiceTest
    {
        //[TestMethod]
        //public void RemoveAnimal_ValidId_AnimalRemoved()
        //{
        //    Enclosure enclosure = new Enclosure("Jungle");
        //    Species species = new Species("ape", 100, 10, 80, 15, 90, Endangered.VULNERABLE, enclosure);
        //    Animal animal = new Animal(species, "gorilla", species.Weight, species.Size, species.Speed, new DateTime(10 / 05 / 2000), Sex.MALE, new DateTime(10/05/2005), null);

        //    MockAnimalRepo.AddAnimalToList(animal);
        //    MockAnimalRepo.RemoveAnimalFromList(animal.AnimalId);

        //    //Testing if animal is still in list here


        //    // Arrange
        //    //int id = 1;

        //    var animalServiceMock = new Mock<IAnimalService>();

        //    // Act
        //    animalServiceMock.Object.RemoveAnimal(animal.AnimalId);

        //    // Assert
        //    animalServiceMock.Verify(s => s.RemoveAnimal(animal.AnimalId), Times.Once);
        //}


        private IAnimalRepository _animalRepository;
        private IContentRepository _contentRepository;
        private AnimalService _animalService;

        [SetUp]
        public void Setup()
        {
            _animalRepository = Mock.Of<IAnimalRepository>();
            _contentRepository = Mock.Of<IContentRepository>();
            _animalService = new AnimalService(_animalRepository, _contentRepository);
        }

        [TestMethod]
        public void GetAnimal_ReturnsAnimalFromRepository()
        {
            // Arrange
            Guid animalId = Guid.NewGuid();
            Enclosure enclosure = new Enclosure("Jungle");
            Species species = new Species("Lion", 200, 150, 15, 80, 90, Endangered.VULNERABLE, new Enclosure("Enclosure 1"));


            Animal expectedAnimal = new Animal(species, "Jaguar", species.Weight, species.Size, species.Speed, new DateTime(2001, 6, 15), Sex.MALE, new DateTime(2005, 6, 15), null);
            Mock.Get(_animalRepository)
                .Setup(r => r.GetAnimal(animalId))
                .Returns(expectedAnimal);

            // Act
            Animal actualAnimal = _animalService.GetAnimal(animalId);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedAnimal, actualAnimal);
        }

        [TestMethod]
        public void RemoveAnimal_CallsDeleteAnimalMethodInRepository()
        {
            // Arrange
            Guid animalId = Guid.NewGuid();

            // Act
            _animalService.RemoveAnimal(animalId);

            // Assert
            Mock.Get(_animalRepository).Verify(r => r.DeleteAnimal(animalId), Times.Once);
        }

        [TestMethod]
        public void EditAnimalBirthdate_CallsEditAnimalBirthdateMethodInRepository()
        {
            // Arrange
            Guid animalId = Guid.NewGuid();
            DateTime birthdate = new DateTime(2022, 1, 1);

            // Act
            _animalService.EditAnimalBirthdate(animalId, birthdate);

            // Assert
            Mock.Get(_animalRepository).Verify(r => r.EditAnimalBirthdate(animalId, birthdate), Times.Once);
        }

        [TestMethod]
        public void EditAnimalName_CallsEditAnimalNameMethodInRepository()
        {
            // Arrange
            Guid animalId = Guid.NewGuid();
            string name = "New Name";

            // Act
            _animalService.EditAnimalName(animalId, name);

            // Assert
            Mock.Get(_animalRepository).Verify(r => r.EditAnimalName(animalId, name), Times.Once);
        }

        [TestMethod]
        public void EditAnimalSex_CallsEditAnimalSexMethodInRepository()
        {
            // Arrange
            Guid animalId = Guid.NewGuid();
            Sex sex = Sex.FEMALE;

            // Act
            _animalService.EditAnimalSex(animalId, sex);

            // Assert
            Mock.Get(_animalRepository).Verify(r => r.EditAnimalSex(animalId, sex), Times.Once);
        }

        [TestMethod]
        public void GetAnimalsByEnclosure_ReturnsAnimalsByEnclosureFromRepository()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid enclosureId = Guid.NewGuid();

            List<Animal> expectedAnimals = new List<Animal> { };
            Mock.Get(_animalRepository)
                .Setup(r => r.GetAnimalsByEnclosure(id, enclosureId))
                .Returns(expectedAnimals);

            // Act
            List<Animal> actualAnimals = _animalService.GetAnimalsByEnclosure(id, enclosureId);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedAnimals, actualAnimals);
        }

        [TestMethod]
        public void EditAnimalPhotoUrl_CallsEditAnimalPhotoUrlMethodInRepository()
        {
            /*// Arrange
            Guid animalId = Guid.NewGuid();
            string photoUrl = "/path/to/photo.jpg";

            // Act
            _animalService.EditAnimalPhotoUrl(animalId, photoUrl);

            // Assert
            Mock.Get(_animalRepository).Verify(r => r.EditAnimalPhotoUrl(animalId, photoUrl), Times.Once);*/
        }

        [TestMethod]
        public void GetAnimalsBySpecies_ReturnsAnimalsBySpeciesFromRepository()
        {
            // Arrange
            Guid speciesId = Guid.NewGuid();
            List<Animal> expectedAnimals = new List<Animal> { };
            Mock.Get(_animalRepository)
                .Setup(r => r.GetAllAnimalsBySpecies(speciesId))
                .Returns(expectedAnimals);

            // Act
            List<Animal> actualAnimals = _animalService.GetAnimalsBySpecies(speciesId);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedAnimals, actualAnimals);
        }

        [TestMethod]
        public void CreateAnimal_CreatesAnimalInRepository()
        {
            // Arrange
            Species species = new Species("Lion", 200, 150, 15, 80, 90, Endangered.VULNERABLE, new Enclosure("Enclosure 1"));

            string animalName = "New Animal";
            int weight = 100;
            int size = 5;
            int speed = 10;
            DateTime birthdate = new DateTime(2022, 1, 1);
            Sex sex = Sex.MALE;
            DateOnly arrivalDate = new DateOnly(2022, 1, 1);
            DateOnly? leaveDate = new DateOnly(2022, 2, 1);
            Animal expectedAnimal = new Animal(species, "Jaguar", species.Weight, species.Size, species.Speed, new DateTime(2001, 6, 15), Sex.MALE, new DateTime(2005, 6, 15), null);
            Mock.Get(_animalRepository)
                .Setup(r => r.CreateAnimal(It.IsAny<Animal>()))
                .Callback<Animal>(a => expectedAnimal = a);

            // Act
            _animalService.CreateAnimal(species, animalName, weight, size, speed, birthdate, sex, arrivalDate, leaveDate);

            // Assert
            Mock.Get(_animalRepository).Verify(r => r.CreateAnimal(It.IsAny<Animal>()), Times.Once);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(species, expectedAnimal.SpeciesName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(animalName, expectedAnimal.AnimalName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(weight, expectedAnimal.Weight);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(size, expectedAnimal.Size);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(speed, expectedAnimal.Speed);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(birthdate, expectedAnimal.Birthdate);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(sex, expectedAnimal.Sex);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(arrivalDate, expectedAnimal.ArrivalDate);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(leaveDate, expectedAnimal.LeaveDate);
        }

        // Add test methods for the remaining methods in AnimalService class here
        // Rest of the test methods


        private void SetupAnimalRepository_GetAnimal(Guid animalId, Animal animal)
        {
            Mock.Get(_animalRepository)
                .Setup(r => r.GetAnimal(animalId))
                .Returns(animal);
        }


    }
}
