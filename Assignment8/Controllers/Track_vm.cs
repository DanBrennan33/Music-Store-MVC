using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class TrackBase : TrackAdd
    {
        public int Id { get; set; }
    }
    public class TrackAdd
    {
        [Required, StringLength(200), Display(Name = "Track")]
        public string Name { get; set; }
        [StringLength(500), Display(Name = "Composer(s)")]
        public string Composers { get; set; }

        [Display(Name = "Track Genre")]
        public string Genre { get; set; }

        [Display(Name = "Genre")]
        public SelectList GenreList { get; set; }

        [StringLength(200)]
        public string Clerk { get; set; }

        [Display(Name = "Album")]
        public string AlbumName { get; set; }
        // Audio Content
        public HttpPostedFileBase AudioUpload { get; set; }
    }
    public class TrackAddForm
    {
        [Display(Name = "Track")]
        public string Name { get; set; }

        [Display(Name = "Composer(s)")]
        public string Composers { get; set; }

        [Display(Name = "Genre")]
        public SelectList GenreList { get; set; }

        [Display(Name = "Album")]
        public string AlbumName { get; set; }

        //Audio Content
        [Required]
        [Display(Name = "Audio Sample")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }

    public class TrackAudio
    {
        public int Id { get; set; }

        //Audio content
        [Display(Name = "Audio Sample")]
        public string ContentType { get; set; }

        [Display(Name = "Audio Sample")]
        public byte[] Content { get; set; }

    }

    public class TrackEditExist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composers { get; set; }
        public string Genre { get; set; }
        public string Clerk { get; set; }

    }
    public class TrackEditExistForm : TrackEditExist
    {
        public SelectList GenreList { get; set; }
    }
}