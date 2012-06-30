using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Notes.Domain;
using Notes.NH.Repositories;
using Notes.Web.Filters;
using Notes.Web.Models;

namespace Notes.Web.Controllers
{
    public class NotesController : Controller
    {
        //
        // GET: /Notes/

        public ActionResult Index()
        {
            var uow = UnitOfWorkProvider.GetCurrent();
            var notesRepository = new IntKeyedRepository<Note>(uow.Session);
            
            var notes = notesRepository.GetAll();

            var notesViewModel = notes.Select(x => new NoteViewModel()
                                  {
                                      Id = x.Id,
                                      Text = x.Text
                                  }).ToList();

            return View(notesViewModel);
        }

        public ActionResult New()
        {
            return View(new NoteViewModel());
        }

        public ActionResult Create(NoteViewModel noteViewModel)
        {
            var uow = UnitOfWorkProvider.GetCurrent();

            if (ModelState.IsValid)
            {
                var note = new Note()
                {
                    Text = noteViewModel.Text
                };
                
                var notesRepository = new IntKeyedRepository<Note>(uow.Session);
                notesRepository.Add(note);

                return RedirectToAction("Index");
            }

            return RedirectToAction("New");
        }

        public ActionResult Edit(int id)
        {
            var uow = UnitOfWorkProvider.GetCurrent();
            var notesRepository = new IntKeyedRepository<Note>(uow.Session);

            var note = notesRepository.Get(id);

            var noteViewModel = new NoteViewModel()
                                    {
                                        Id = note.Id,
                                        Text = note.Text
                                    };

            return View(noteViewModel);
        }

        public ActionResult Update(NoteViewModel noteViewModel)
        {
            var uow = UnitOfWorkProvider.GetCurrent();

            if (ModelState.IsValid)
            {
                var note = new Note()
                {
                    Id = noteViewModel.Id,
                    Text = noteViewModel.Text
                };
                
                var notesRepository = new IntKeyedRepository<Note>(uow.Session);
                notesRepository.Update(note);

                return RedirectToAction("Index");
            }

            return RedirectToAction("New");
        }

        public ActionResult Delete(int id)
        {
            var uow = UnitOfWorkProvider.GetCurrent();
            var notesRepository = new IntKeyedRepository<Note>(uow.Session);
            
            notesRepository.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
