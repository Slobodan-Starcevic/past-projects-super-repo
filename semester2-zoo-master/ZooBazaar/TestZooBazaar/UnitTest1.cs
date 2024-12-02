using BLL.Interfaces.Repositories;
using BLL.Models;
using DAL;
using DAL.Repositories;

namespace TestZooBazaar
{
    [TestClass]
    public class UnitTest1
    {
        private EnclosureRepository enclosureRepository;
        public UnitTest1()
        {
            enclosureRepository = new EnclosureRepository();
        }
        public void GetEnclosures()
        {
            List<Enclosure> enclosures = enclosureRepository.GetEnclosures();

            Assert.IsNotNull(enclosures);
        }
     

    }
}