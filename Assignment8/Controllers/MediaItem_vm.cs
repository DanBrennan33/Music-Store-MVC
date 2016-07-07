using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment8.Controllers
{
    public class MediaItemBase : MediaItemAdd
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
    }

    public class MediaItemAdd
    {
        public MediaItemAdd()
        {
            TimeStamp = DateTime.Now;
        }
        public string StringId { get; set; }
        public DateTime TimeStamp { get; set; }
        [Required]
        public string Caption { get; set; }
        public string ArtistName { get; set; }
        public int ArtistId { get; set; }

        // Media Content
        public HttpPostedFileBase MediaUpload { get; set; }
    }

    public class MediaItemAddForm
    {
        public MediaItemAddForm()
        {
            TimeStamp = DateTime.Now;
        }
        public string StringId { get; set; }
        public DateTime TimeStamp { get; set; }
        [Display(Name = "Descriptive Caption")]
        public string Caption { get; set; }
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int ArtistId { get; set; }

        //Media Content
        [Required]
        [Display(Name = "Media Item")]
        [DataType(DataType.Upload)]
        public string MediaUpload { get; set; }
    }

    public class MediaItemContent
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}