using System.Collections.Generic;
using System.Web.Mvc;
using Notes.Web.Models;

namespace Notes.Web.Controllers
{
    public class NotesController : Controller
    {
        //
        // GET: /Notes/

        public ActionResult Index()
        {
            var notes = new List<NoteViewModel> {
                new NoteViewModel { Text = "Testing" },
                new NoteViewModel { Text = "Testing 2" }
            };

            return View(notes);
        }

    }
}
