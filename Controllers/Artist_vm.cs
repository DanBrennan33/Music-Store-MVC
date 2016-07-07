using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class ArtistBase : ArtistAdd
    {
        public int Id { get; set; }
    }
    public class ArtistAdd
    {
        [Required]
        [Display(Name = "Artist Profile")]
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }

        public ArtistAdd()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }

        [StringLength(100)]
        [Display(Name = "Birth Name")]
        public string BirthName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required, Display(Name = "Date of Orign")]
        public DateTime BirthOrStartDate { get; set; }

        [StringLength(60)]
        public string Executive { get; set; }

        [Display(Name = "Artist Name"), StringLength(60)]
        public string Name { get; set; }

        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }

        [StringLength(60), Display(Name = "Genre")]
        public string Genre { get; set; }

    }
    public class ArtistAddForm : ArtistAdd
    {
        [Display(Name = "Genre")]
        public SelectList GenreList { get; set; }
    }
    public class ArtistWithMediaItem : ArtistBase
    {
        public ArtistWithMediaItem()
        {
            MediaItems = new List<MediaItemBase>();
        }
        public IEnumerable<MediaItemBase> MediaItems { get; set; }
    }
    public class ArtistEditExist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string UrlArtist { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }
    }
    public class ArtistEditForm : ArtistEditExist
    {
        public SelectList GenreList { get; set; }
    }
}