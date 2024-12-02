//using BLL.Models;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;

//namespace WebApp
//{
//    public class TempRepo
//    {
//        private static TempRepo? instance;

//        public static TempRepo Instance
//        {
//            get
//            {
//                if(instance == null)
//                {
//                    instance = new TempRepo();
//                }
//                return instance;
//            }
//        }

//        private List<Enclosure> enclosures = new List<Enclosure>();
//        private List<Species> species = new List<Species>();
//        private List<AnimalTemp> animals = new List<AnimalTemp>();

//        private TempRepo()
//        {
//            Enclosure jungle = new Enclosure(1, "Jungle");
//            enclosures.Add(jungle);
//            Enclosure desert = new Enclosure(2, "Desert");
//            enclosures.Add(desert);
//            Enclosure ocean = new Enclosure(3, "Ocean");
//            enclosures.Add(ocean);
//            /*enclosure = new Enclosure(4, "Savanna");
//            enclosures.Add(enclosure);*/

//            Species jaguar = new Species(1, "Jaguar", jungle);
//            species.Add(jaguar);
//            Species toucan = new Species(2, "Toucan", jungle);
//            species.Add(toucan);
//            Species frog = new Species(3, "Poison Dart Frog", jungle);
//            species.Add(frog);

//            AnimalTemp bob = new AnimalTemp(1, "Bob", jungle, jaguar);
//            animals.Add(bob);
//            AnimalTemp ken = new AnimalTemp(2, "Ken", jungle, jaguar);
//            animals.Add(ken);
//            AnimalTemp jeniffer = new AnimalTemp(3, "Jeniffer", jungle, jaguar);
//            animals.Add(jeniffer);
//        }

//        public List<Enclosure> GetEnclosures()
//        {
//            return enclosures;
//        }

//        public Enclosure? GetEnclosureById(int id)
//        {
//            Enclosure? enclosure = enclosures.FirstOrDefault(e => e.ID == id);
//            return enclosure;
//        }

//        public Species? GetSpeciesById(int id)
//        {
//            Species? sp = species.FirstOrDefault(s => s.Idspecies == id);
//            return sp;
//        }

//        public List<Species> GetSpeciesByEnclosureId(int id)
//        {
//            List<Species> spList = species.Where(s => s.Enclosure.ID == id).ToList();
//            return spList;
//        }

//        public AnimalTemp? GetAnimalById(int id)
//        {
//            AnimalTemp? an = animals.FirstOrDefault(a => a.Id == id);
//            return an;
//        }

//        public List<AnimalTemp> GetAnimalsBySpeciesId(int id)
//        {
//            List<AnimalTemp> anList = animals.Where(a => a.Species.Idspecies == id).ToList();
//            return anList;
//        }

//    }
//}
