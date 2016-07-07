using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class AlbumBase : AlbumAdd
    {
        public int Id { get; set; }
    }
    public class AlbumAdd
    {
        [Required]
        [Display(Name = "Album Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public AlbumAdd()
        {
            ReleaseDate = DateTime.Now;
        }
        
        [StringLength(60)]
        public string Coordinator { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        [StringLength(60)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [StringLength(160)]
        [Display(Name = "Cover Art")]
        public string UrlAlbum { get; set; }

        [StringLength(60)]
        public string Genre { get; set; }

        [Display(Name = "Artist")]
        public string ArtistName { get; set; }
    }
    public class AlbumAddForm : AlbumAdd
    {
        [Display(Name = "Genre")]
        public SelectList GenreList { get; set; }
    }
    public class AlbumEditExist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string UrlAlbum { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
    public class AlbumEditExistForm : AlbumEditExist
    {
        public SelectList GenreList { get; set; }
    }
}