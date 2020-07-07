using NotleyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotleyApp.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly List<NoteModel> _notes;

        public NoteRepository()
        {
            _notes = new List<NoteModel>();
        }

        public NoteModel FindNoteByID(Guid id)
        {
            var note = _notes.Find(match: n => n.ID == id);
            return note;
        }

        public IEnumerable<NoteModel> GetAllNotes()
        {
            return _notes;
        }

        public void SaveNote(NoteModel noteModel)
        {
            _notes.Add(noteModel);
        }

        public void DeleteNote(NoteModel noteModel)
        {
            _notes.Remove(noteModel);

        }
    }
}
