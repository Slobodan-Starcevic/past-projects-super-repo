using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces.Services
{
    public interface IEnclosureService
    {
        void CreateEnclosure(string name);
        void DeleteEnclosure(Guid id);
        void EditEnclosureName(Enclosure enclosure);
        void EditEnclosureShowOnline(Enclosure enclosure, bool showOnline);

		Enclosure GetEnclosure(Guid id);
        List<Enclosure> GetEnclosures();
    }
}
