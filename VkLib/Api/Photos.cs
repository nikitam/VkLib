using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Methods.Photos;
using VkLib.Objects;
using VkLib.Objects.ServiceObjects;

namespace VkLib.Api
{
    public class Photos
    {
        public static Int32 GetAlbumCount(IExecuteSystem es, String userId, String groupId)
        {
            var method = new GetAlbumsCount
            {
                UserId = userId,
                GroupId = groupId
            };

            return es.Execute(method);
        }

        public static Int32 DeleteAlbum(IExecuteSystem es, String albumId, String groupId)
        {
            var method = new DeleteAlbum
            {
                AlbumId = albumId,
                GroupId = groupId
            };

            return es.Execute(method);
        }

        public static Album CreateAlbum(IExecuteSystem es, String title, String groupId = null, String descr = null,
            String privacyView = null, String privacyComment = null, Boolean? uploadByAdmins = null,
            Boolean? commentsDisabled = null)
        {
            var method = new CreateAlbum
            {
                Title = title,
                GroupId = groupId,
                Description = descr,
                PrivacyView = privacyView,
                PrivacyComment = privacyComment,
                UploadByAdmins = uploadByAdmins,
                CommentsDisabled = commentsDisabled
            };

            return es.Execute(method);
        }

        public static List<Album> GetAlbums(IExecuteSystem es, String owner, List<String> ids = null, UInt32? offset = null, UInt32? count = null, Boolean? needSystem = null, Boolean? needCovers = null, Boolean? photoSizes = null)
        {
            var method = new GetAlbums
            {
                OwnerId = owner,
                AlbumIds = ids,
                Offset = offset,
                Count = count,
                NeedSystem = needSystem,
                NeedCovers = needCovers,
                PhotoSizes = photoSizes
            };

            return es.Execute(method);
        }

        public static List<Photo> Get(IExecuteSystem es, String owner, String album, List<String> ids = null,
            Boolean? rev = null, Boolean? extended = null, String feedType = null, DateTime? feed = null,
            Boolean? photoSizes = null, Int32? offset = null, Int32? count = null)
        {
            var method = new Get
            {
                OwnerId = owner,
                AlbumId = album,
                PhotoIds = ids,
                Rev = rev,
                Extended = extended,
                FeedType = feedType,
                Feed = feed,
                PhotoSizes = photoSizes,
                Offset = offset,
                Count = count
            };

            return es.Execute(method);
        }

        public static List<PhotoComment> GetComments(IExecuteSystem es, String owner, String photo,
            Boolean? needLikes = null, Int32? offset = null, Int32? count = null, String sort = null,
            Boolean? extended = null)
        {
            var method = new GetComments
            {
                OwnerId = owner,
                PhotoId = photo,
                NeedLikes = needLikes,
                Offset = offset,
                Count = count,
                Sort = sort,
                Extended = extended
            };
            return es.Execute(method);
        }

        public static String CreateComment(IExecuteSystem es, String owner, String photo, String message,
            List<String> attaches = null, Boolean? fromGroup = null, String replyToComment = null,
            String stickerId = null)
        {
            var method = new CreateComment
            {
                OwnerId = owner,
                PhotoId = photo,
                Message = message,
                Attachments = attaches,
                FromGroup = fromGroup,
                ReplyToComment = replyToComment,
                StickerId = stickerId
            };

            return es.Execute(method);
        }

        public static UploadServerData GetUploadServer(IExecuteSystem es, String albumId, String groupId = null)
        {
            var method = new GetUploadServer
            {
                AlbumId = albumId,
                GroupId = groupId
            };

            return es.Execute(method);
        }

        public static List<Photo> Save(IExecuteSystem es, String albumId, String server, String photosList,
            String hash, String groupId = null, Double? latitude = null, Double? longitude = null,
            String caption = null)
        {
            var method = new Save()
            {
                AlbumId = albumId,
                GroupId = groupId,
                Server = server,
                PhotosList = photosList,
                Hash = hash,
                Latitude = latitude,
                Longitude = longitude,
                Caption = caption
            };

            return es.Execute(method);
        }
    }

}