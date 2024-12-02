using BLL.Interfaces.Repositories;
using BLL.Models;
using BLL.Services;
using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCore.DTO
{
	public class EnclosureDTO
	{
		private IEnclosureRepository enclosureRepository;

		private List<Enclosure> enclosures;
		private Enclosure? selectedEnclosure;

		public Enclosure SelectedEnclosure { get { return selectedEnclosure; } }
		public List<Enclosure> Enclosure { get { return enclosures; } }

		public List<Enclosure> EnclosuresList { get { return enclosures; } }

		public EnclosureDTO()
		{
			enclosureRepository = new EnclosureRepository();
			GetListEnclosures();
		}
		internal void SelectAnimal(Enclosure enclosure)
		{
			this.selectedEnclosure = enclosure;
		}
		public void GetListEnclosures()
		{
			enclosures = enclosureRepository.GetEnclosures();

		}
		public List<Enclosure> getEnclosures()
		{
			GetListEnclosures();
			return enclosures;
		}

		internal void NewEnclosure(string name)
		{
			enclosureRepository.CreateEnclosure(new Enclosure(name));
		}

		internal void EdditEnclosure(Enclosure enclosure, string name)
		{
			Enclosure  enclosureEddit = new Enclosure(enclosure.Id,name, enclosure.Url);
			enclosureRepository.EditEnclosure(enclosureEddit);
		}
		public void SelectEnclosure(Enclosure enclosure)
		{
			this.selectedEnclosure = enclosure;
		}

		internal void DeleteEnclosure(Guid id)
		{
			enclosureRepository.DeleteEnclosure(id);
		}

        internal void EdditShowStatus(bool showOnWeb)
        {
            enclosureRepository.EditShowOnWeb(selectedEnclosure, showOnWeb);
        }

		internal void DeselectEnclosure()
		{
			this.selectedEnclosure = null;
		}
	}
}
