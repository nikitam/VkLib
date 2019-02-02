using System;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class Album: VkObject
    {
        public String Id { get; set; }

        public String ThumbId { get; set; }

        public String OwnerId { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public Int32 Size { get; set; }

        public Boolean CanUpload { get; set; }

        public Boolean UploadOnlyAdmins { get; set; }

        public Boolean CommentsDisabled { get; set; }

        public String ThumbSource { get; set; }

        public Album()
        {
        }

        public Album(Album album)
        {
            this.Id = album.Id;
            this.ThumbId = album.ThumbId;
            this.OwnerId = album.OwnerId;
            this.Title = album.Title;
            this.Description = album.Description;
            this.Created = album.Created;
            this.Updated = album.Updated.GetValueOrDefault();
            this.Size = album.Size;
            this.CanUpload = album.CanUpload;
            this.UploadOnlyAdmins = album.UploadOnlyAdmins;
            this.CommentsDisabled = album.CommentsDisabled;
            this.ThumbSource = album.ThumbSource;
        }

        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitAlbum(this, data);
        }
    }
}