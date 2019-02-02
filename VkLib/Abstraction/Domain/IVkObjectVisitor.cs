using VkLib.Objects;
using VkLib.Objects.ServiceObjects;

namespace VkLib.Abstraction.Domain
{

    public interface IVkObjectVisitor<in T>
    {
        void VisitGroup(Group obj, T data);

        void VisitAlbum(Album obj, T data);

        void VisitPhoto(Photo obj, T data);

        void VisitMessage(Message obj, T data);

        void VisitPhotoComment(PhotoComment obj, T data);

        void VisitUser(User obj, T data);

        void VisitError(Error obj, T data);

        void VisitCity(City obj, T data);

        void VisitUploadServerData(UploadServerData obj, T data);
    }
}