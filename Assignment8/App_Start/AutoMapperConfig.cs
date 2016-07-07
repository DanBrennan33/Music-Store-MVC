using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment8
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            // Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

            // AutoMapper create map statements

            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();

            // Add more below...

            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithMediaItem>();
            Mapper.CreateMap<Controllers.ArtistBase, Controllers.ArtistEditForm>();
            Mapper.CreateMap<Controllers.ArtistAdd, Models.Artist>();

            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();
            Mapper.CreateMap<Controllers.AlbumAdd, Models.Album>();
            Mapper.CreateMap<Controllers.AlbumBase, Controllers.AlbumEditExistForm>();

            Mapper.CreateMap<Models.Track, Controllers.TrackBase>();
            Mapper.CreateMap<Models.Track, Controllers.TrackAudio>();
            Mapper.CreateMap<Controllers.TrackAdd, Models.Track>();
            Mapper.CreateMap<Controllers.TrackBase, Controllers.TrackEditExistForm>();

            Mapper.CreateMap<Models.MediaItem, Controllers.MediaItemBase>();
            Mapper.CreateMap<Models.MediaItem, Controllers.MediaItemContent>();
            Mapper.CreateMap<Controllers.MediaItemAdd, Models.MediaItem>();

            Mapper.CreateMap<Models.Genre, Controllers.GenreBase>();
            
#pragma warning restore CS0618
        }
    }
}