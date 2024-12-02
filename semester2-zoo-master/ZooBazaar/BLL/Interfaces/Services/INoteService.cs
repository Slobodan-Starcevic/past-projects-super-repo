using BLL.Interfaces.Repositories;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface INoteService
    {
        void Create(string text, Employee employee, List<Species> species);

        void Delete(Guid id);

        void Edit(Guid id, string newDescription);

        void Edit(Guid id, List<Animal> animals);

        List<Note> GetAllNotes();

        Note GetNote(Guid id);

        void CreateNote(Note note);

        void ArchiveNote(Guid id);
    }
}
