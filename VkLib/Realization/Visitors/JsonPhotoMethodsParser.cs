using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Methods.Photos;
using VkLib.Objects;
using VkLib.Objects.ServiceObjects;

namespace VkLib.Realization.Visitors
{
    public class JsonPhotoMethodsParser: BaseMethodsVisitor<JToken>, IPhotoMethodsVisitor<JToken>
    {
        public JsonPhotoMethodsParser(IVkObjectVisitor<JToken> v) : base(v)
        {
        }

        #region Implementation of IPhotoMethodsVisitor<JToken>

        public Album VisitPhotosCreateAlbum(CreateAlbum method, JToken data)
        {
            var album = new Album();
            album.Accept(this.ObjectParser, data["response"]);
            return album;
        }

        public List<Album> VisitPhotosGetAlbums(GetAlbums method, JToken data)
        {
            var result = new List<Album>();
            foreach (var albumToken in data["response"]["items"])
            {
                var album = new Album();
                album.Accept(this.ObjectParser, albumToken);
                result.Add(album);
            }

            return result;
        }

        public List<Photo> VisitPhotosGet(Get method, JToken data)
        {
            var result = new List<Photo>();
            foreach (var photoItem in data["response"]["items"])
            {
                var photo = new Photo();
                photo.Accept(this.ObjectParser, photoItem);
                result.Add(photo);
            }
            return result;
        }

        public List<PhotoComment> VisitPhotoGetComments(GetComments method, JToken data)
        {
            var result = new List<PhotoComment>();
            var commentors = new List<VkPrincipal>();
            foreach (var item in data["response"]["profiles"])
            {
                var profile = new User();
                profile.Accept(this.ObjectParser, item);
                commentors.Add(profile);
            }
            foreach (var item in data["response"]["groups"])
            {
                var group = new Group();
                group.Accept(this.ObjectParser, item);
                commentors.Add(group);
            }
            foreach (var item in data["response"]["items"])
            {
                var comment = new PhotoComment();
                comment.Accept(this.ObjectParser, item);
                comment.Creator = commentors.SingleOrDefault(x => x.Id == comment.FromId);
                result.Add(comment);
            }
            return result;
        }

        public String VisistPhotoCreateComment(CreateComment method, JToken data)
        {
            return data.SafeGetValue<String>("response");
        }

        public UploadServerData VisitPhotosGetUploadServer(GetUploadServer method, JToken data)
        {
            var result = new UploadServerData();
            result.Accept(this.ObjectParser, data["response"]);
            return result;
        }

        public List<Photo> VisitPhotosSave(Save method, JToken data)
        {
            var result = new List<Photo>();
            foreach (var photoItem in data["response"])
            {
                var photo = new Photo();
                photo.Accept(this.ObjectParser, photoItem);
                result.Add(photo);
            }
            return result;
        }

        public Int32 VisitPhotosGetAlbumsCount(GetAlbumsCount method, JToken data)
        {
            return data.SafeGetValue<Int32>("response");
        }

        public Int32 VisitPhotosDeleteAlbum(DeleteAlbum method, JToken data)
        {
            return data.SafeGetValue<Int32>("response");
        }

        #endregion


    }
}