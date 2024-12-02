using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataTest
{
    [TestClass]
    public class EnclosureTest
    {
        //[TestMethod]
        //public void MakeEnlcosure()
        //{
        //    Enclosure TestEncl = new Enclosure("Name",new List<Species>(), new List<Content>());
        //    Assert.IsNotNull(TestEncl);
        //}
        [TestMethod]
        public void MakeEnclosureCreation()
        {
            // Arrange
            string name = "Enclosure 1";

            // Act
            Enclosure testEnclosure = new Enclosure(name);

            // Assert
            Assert.IsNotNull(testEnclosure);
            Assert.AreEqual(name, testEnclosure.Name);
            Assert.IsNotNull(testEnclosure.Id);
            Assert.IsTrue(testEnclosure.Url.Contains(testEnclosure.Id.ToString()));
        }

        [TestMethod]
        public void RetrieveEnclosureFromDatabase()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "Enclosure 1";
            string url = "/enclosures?id=" + id;

            // Act
            Enclosure testEnclosure = new Enclosure(id, name, url);

            // Assert
            Assert.IsNotNull(testEnclosure);
            Assert.AreEqual(id, testEnclosure.Id);
            Assert.AreEqual(name, testEnclosure.Name);
            Assert.AreEqual(url, testEnclosure.Url);
        }


        //[TestMethod]
        //public void AddContentToEnclosure()
        //{
        //Arange
        //make enclosure
        //make content object

        //Act
        //call the "addcontent" method from the enclosure class and add the content to it example: enclosure.AddContent(content)

        //Assert
        //test if the content in the enclosure class matches the content you made in this testmethod
        //example: Compare(enclosure.webContent to content)
        //}

        [TestMethod]
        public void AddContentToEnclosure()
        {
            // Arrange
            Enclosure enclosure = new Enclosure("Jungle");
            Species species = new Species("Lion", 100, 10, 80, 15, 90, Endangered.VULNERABLE, enclosure);
            Animal animal = new Animal(species, "Jaguar", species.Weight, species.Size, species.Speed, new DateTime(2001, 6, 15), Sex.MALE, new DateTime(2005, 6, 15), null);
            WebContentOrder order = new WebContentOrder();

            Content content = new Content(animal, order, "title", "text", "imageUrl");

            // Act
            enclosure.AddContent(new List<Content> { content });

            // Assert
            Assert.IsNotNull(enclosure.WebContent);
            Assert.AreEqual(1, enclosure.WebContent.Count);
            Assert.AreEqual(content, enclosure.WebContent[0]);
        }



        [TestMethod]
        public void RemoveContentFromEnclosure()
        {

        }

          
    }
}
