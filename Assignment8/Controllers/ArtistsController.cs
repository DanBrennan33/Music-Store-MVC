using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        Manager man = new Manager();
        // GET: Artists
        public ActionResult Index()
        {
            return View(man.ArtistGetAll());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            var o = man.ArtistGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(man.ArtistGetById(id));
            }
        }

        // GET: Artists/ArtistsWithMediaItems/5
        public ActionResult DetailsWithMediaItems(int? id)
        {
            var o = man.ArtistWithMediaItemGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddForm();
            form.GenreList = new SelectList(man.GenreGetAll(), "Name", "Name");
            return View(form);
        }

        // POST: Artists/Create
        [Authorize(Roles = "Executive")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ArtistAdd newArtist)
        {
            if (!ModelState.IsValid)
            {
                return View(newArtist);
            }

            var addedItem = man.ArtistAdd(newArtist);

            if (addedItem == null)
            {
                return View(newArtist);
            }
            else
            {
                return RedirectToAction("details", "Artists", new { id = addedItem.Id });
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var a = man.ArtistGetById(id);

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AlbumAddForm();
                form.ArtistName = a.Name;
                form.GenreList = new SelectList(man.GenreGetAll(), "Name", "Name");
                return View(form);
            }
        }

        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAdd newAlbum)
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
                return RedirectToAction("Details", "Albums", new { id = addedItem.Id });
            }
        }


        [Route("artist/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            var a = man.ArtistGetById(id);

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new MediaItemAddForm();
                form.ArtistName = a.Name;
                form.ArtistId = a.Id;
                return View(form);
            }
        }

        [Route("artist/{id}/addmediaitem")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMediaItem(int? id, MediaItemAdd newAsset)
        {
            if (!ModelState.IsValid && id.GetValueOrDefault() == newAsset.ArtistId)
            {
                return View(newAsset);
            }

            var addedItem = man.MediaItemAdd(newAsset);

            if (addedItem == null)
            {
                return View(newAsset);
            }
            else
            {
                return RedirectToAction("DetailsWithMediaItems", new { id = addedItem.ArtistId });
            }
        }


        // GET: Artists/Edit/5
        [Authorize(Roles = "Executive")]
        public ActionResult Edit(int? id)
        {
            var o = man.ArtistGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else {
                var editForm = AutoMapper.Mapper.Map<ArtistEditForm>(o);
                editForm.GenreList = new SelectList(man.GenreGetAll(), "Name", "Name");
                return View(editForm);
            }
        }

        // POST: Artists/Edit/5
        [Authorize(Roles = "Executive")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, ArtistEditForm newArtist)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newArtist.Id });
            }
            if (id.GetValueOrDefault() != newArtist.Id)
            {
                return RedirectToAction("index");
            }
            var editedItem = man.ArtistEditForm(newArtist);
            if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = newArtist.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = newArtist.Id });
            }
        }

        // GET: Artists/Delete/5
        [Authorize(Roles = "Executive")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = man.ArtistGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Artists/Delete/5
        [Authorize(Roles = "Executive")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = man.ArtistDelete(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }
    }
}
