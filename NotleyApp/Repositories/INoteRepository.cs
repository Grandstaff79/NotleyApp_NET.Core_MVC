using NotleyApp.Models;
using System;
using System.Collections.Generic;

namespace NotleyApp.Repositories
{
    public interface INoteRepository
    {
        void DeleteNote(NoteModel noteModel);
        NoteModel FindNoteByID(Guid id);
        IEnumerable<NoteModel> GetAllNotes();
        void SaveNote(NoteModel noteModel);
    }
}