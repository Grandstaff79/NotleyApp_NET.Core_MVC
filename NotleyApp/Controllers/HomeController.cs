using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotleyApp.Models;
using NotleyApp.Repositories;

namespace NotleyApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly INoteRepository _noteRepository;

        public HomeController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public IActionResult Index()
        {
            var notes = _noteRepository.GetAllNotes().Where(n => n.IsDeleted == false);

            return View(notes);
        }

        public IActionResult NoteDetail(Guid id)
        {
            var note = _noteRepository.FindNoteByID(id);
            return View(note);
        }

        [HttpGet]

        public IActionResult NoteEditor(Guid id = default)
        {
            if (id != Guid.Empty)
            {
                var note = _noteRepository.FindNoteByID(id);

                return View(note);

            }

            return View();


        }
        [HttpPost]

        public IActionResult NoteEditor(NoteModel noteModel)
        {

            if (ModelState.IsValid)
            {
                var date = DateTime.Now;

                if (noteModel != null && noteModel.ID == Guid.Empty)
                {

                    noteModel.ID = Guid.NewGuid();
                    noteModel.CreatedDate = date;
                    noteModel.LastModified = date;
                    _noteRepository.SaveNote(noteModel);
                }
                else
                {

                    var note = _noteRepository.FindNoteByID(noteModel.ID);
                    note.LastModified = date;
                    note.Subject = noteModel.Subject;
                    note.Detail = noteModel.Detail;
                }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            public IActionResult DeleteNote(Guid id)
            {
                var note = _noteRepository.FindNoteByID(id);
                note.IsDeleted = true;
                return RedirectToAction("Index");
            }



            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }


