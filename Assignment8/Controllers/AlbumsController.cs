using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        Manager man = new Manager();
        // GET: Albums
        public ActionResult Index()
        {
            return View(man.AlbumGetAll());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            var o = man.AlbumGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(man.AlbumGetById(id));
            }
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AlbumAdd newAlbum)
        {
            if (!ModelState.IsValid)
            {
                return View(newAlbum);
            }

            var addedItem = man.AlbumAdd(newAlbum);

            if (addedItem == null)
            {
                return View(newAlbum);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var a = man.AlbumGetById(id);

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new TrackAddForm();
                form.AlbumName = a.Name;
                form.GenreList = new SelectList(man.GenreGetAll(), "Name", "Name");
                return View(form);
            }
        }

        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        [HttpPost]
        public ActionResult AddTrack(TrackAdd newTrack)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrack);
            }

            var addedItem = man.TrackAdd(newTrack);

            if (addedItem == null)
            {
                return View(newTrack);
            }
            else
            {
                return RedirectToAction("Details", "Tracks", new { id = addedItem.Id });
            }
        }

        // GET: Albums/Edit/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Edit(int? id)
        {
            var o = man.AlbumGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else {
                var editForm = AutoMapper.Mapper.Map<AlbumEditExistForm>(o);
                editForm.GenreList = new SelectList(man.GenreGetAll(), "Name", "Name");
                return View(editForm);
            }
        }

        // POST: Albums/Edit/5
        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, AlbumEditExistForm newAlbum)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newAlbum.Id });
            }
            if (id.GetValueOrDefault() != newAlbum.Id)
            {
                return RedirectToAction("index");
            }
            var editedItem = man.AlbumEditForm(newAlbum);
            if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = newAlbum.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = newAlbum.Id });
            }
        }

        // GET: Albums/Delete/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = man.AlbumGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Albums/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = man.AlbumDelete(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }
    }
}
