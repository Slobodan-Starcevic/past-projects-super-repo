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
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public void Create(string text, Employee employee, List<Species> species)
        {
            _noteRepository.Create(new Note(text, employee, species));
        }

        public void Delete(Guid id)
        {
            _noteRepository.Delete(id);
        }

        public void Edit(Guid id, string newDescription)
        {
            _noteRepository.Edit(id, newDescription);
        }

        public void Edit(Guid id, List<Animal> animals)
        {
            _noteRepository.Edit(id, animals);
        }

        public List<Note> GetAllNotes()
        {
            return _noteRepository.GetAllNotes();
        }

        public Note GetNote(Guid id)
        {
            return _noteRepository.GetNote(id);
        }

        public void CreateNote(Note note)
        {
            _noteRepository.CreateNote(note);
        }

        public void ArchiveNote(Guid id)
        {
            _noteRepository.ArchiveNote(id);
        }
    }
}
