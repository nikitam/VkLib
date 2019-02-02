using System;
using System.Collections.Generic;
using VkLib.Methods.Photos;
using VkLib.Objects;
using VkLib.Objects.ServiceObjects;

namespace VkLib.Abstraction.Visitors
{
    public interface IPhotoMethodsVisitor<T>
    {
        Album VisitPhotosCreateAlbum(CreateAlbum method, T data);

        List<Album> VisitPhotosGetAlbums(GetAlbums method, T data);

        List<Photo> VisitPhotosGet(Get method, T data);

        List<PhotoComment> VisitPhotoGetComments(GetComments method, T data);

        String VisistPhotoCreateComment(CreateComment method, T data);

        UploadServerData VisitPhotosGetUploadServer(GetUploadServer method, T data);

        List<Photo> VisitPhotosSave(Save method, T data);

        Int32 VisitPhotosGetAlbumsCount(GetAlbumsCount method, T data);

        Int32 VisitPhotosDeleteAlbum(DeleteAlbum method, T data);
    }
}