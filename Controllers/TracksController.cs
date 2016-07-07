using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    [Authorize]
    public class TracksController : Controller
    {
        // GET: Tracks
        Manager man = new Manager();
        public ActionResult Index()
        {
            return View(man.TrackGetAll());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            var o = man.TrackGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(man.TrackGetById(id));
            }
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var o = man.TrackGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else {
                var editForm = AutoMapper.Mapper.Map<TrackEditExistForm>(o);
                editForm.GenreList = new SelectList(man.GenreGetAll(), "Name", "Name");
                return View(editForm);
            }
        }

        // POST: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEditExistForm newTrack)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newTrack.Id });
            }
            if (id.GetValueOrDefault() != newTrack.Id)
            {
                return RedirectToAction("index");
            }
            var editedItem = man.TrackEditForm(newTrack);
            if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = newTrack.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = newTrack.Id });
            }
        }

        // GET: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = man.TrackGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = man.TrackDelete(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }
    }
}
