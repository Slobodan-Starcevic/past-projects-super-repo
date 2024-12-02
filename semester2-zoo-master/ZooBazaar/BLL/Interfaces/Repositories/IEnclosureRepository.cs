using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces.Repositories
{
    public interface IEnclosureRepository
    {
        void CreateEnclosure(Enclosure enclosure);
        Enclosure GetEnclosure(Guid id);
        List<Enclosure> GetEnclosures();
        void EditEnclosure(Enclosure enclosure);
        void DeleteEnclosure(Guid id);
        void EditShowOnWeb(Enclosure enclosure, bool showOnWeb);
    }
}
