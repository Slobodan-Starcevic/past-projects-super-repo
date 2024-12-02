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
	public class EnclosureService : IEnclosureService
    {
        private readonly IEnclosureRepository _enclosureRepository;

        public EnclosureService(IEnclosureRepository enclosureRepository)
        {
            _enclosureRepository = enclosureRepository;
        }

        public void CreateEnclosure(string name)
        {
            Enclosure enclosure = new Enclosure(name);

            _enclosureRepository.CreateEnclosure(enclosure);
        }

        public void DeleteEnclosure(Guid id)
        {
            _enclosureRepository.DeleteEnclosure(id);
        }

       

		public void EditEnclosureName(Enclosure enclosure)
		{

			_enclosureRepository.EditEnclosure(enclosure);
		}

		public void EditEnclosureShowOnline(Enclosure enclosure, bool showOnline)
		{
			_enclosureRepository.EditShowOnWeb( enclosure, showOnline);
		}

		public Enclosure GetEnclosure(Guid id)
        {
            return _enclosureRepository.GetEnclosure(id);
        }

        public List<Enclosure> GetEnclosures()
        {
            return _enclosureRepository.GetEnclosures();
        }
    }
}
