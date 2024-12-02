using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repositories
{
    public interface INoteRepository
    {
        void Create(Note note);
        Note GetNote(Guid id);
        List<Note> GetAllNotes();
        List<Note> GetEmployeeNotes(Guid employeeId);
        void Edit(Guid id, string newDescription);
        void Edit(Guid id, List<Animal> animals);
        void Delete(Guid id);
        void CreateNote(Note note);
        void ArchiveNote(Guid id);
    }
}
