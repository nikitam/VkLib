using System;
using System.Collections.Generic;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Methods.Board;
using VkLib.Methods.Friends;
using VkLib.Methods.Groups;
using VkLib.Methods.Messages;
using VkLib.Methods.Photos;
using VkLib.Objects;
using VkLib.Objects.ServiceObjects;
using Get = VkLib.Methods.Friends.Get;

namespace VkLib.Abstraction
{

    public abstract class VkMethodVisitor<T>: IBoardMethodsVisitor<T>, IFriendMethodsVisitor<T>, IGroupMethodsVisitor<T>, IMessageMethodsVisitor<T>,
        IPhotoMethodsVisitor<T>, IUserMethodsVisitor<T>
    {
        public T Data { get; }
        protected ExecuteEnvironment Environment { get; }

        private readonly IBoardMethodsVisitor<T> boardVisitor;
        private readonly IFriendMethodsVisitor<T> friendVisitor;
        private readonly IGroupMethodsVisitor<T> groupVisitor;
        private readonly IMessageMethodsVisitor<T> messageVisitor;
        private readonly IPhotoMethodsVisitor<T> photoVisitor;
        private readonly IUserMethodsVisitor<T> userVisitor;

        protected IVkObjectVisitor<T> ObjectsVisitor { get; }

        protected VkMethodVisitor(T data, ExecuteEnvironment env)
        {
            this.Data = data;
            this.Environment = env;

            this.ObjectsVisitor = this.CreateVkObjectVisitor();

            this.boardVisitor = this.CreateBoardMethodsVisitor();
            this.friendVisitor = this.CreateFriendMethodsVisitor();
            this.groupVisitor = this.CreateGroupMethodsVisitor();
            this.messageVisitor = this.CreateMessageMethodsVisitor();
            this.photoVisitor = this.CreatePhotoMethodsVisitor();
            this.userVisitor = this.CreateUserMethodsVisitor();
        }

        protected abstract IBoardMethodsVisitor<T> CreateBoardMethodsVisitor();
        protected abstract IFriendMethodsVisitor<T> CreateFriendMethodsVisitor();
        protected abstract IGroupMethodsVisitor<T> CreateGroupMethodsVisitor();
        protected abstract IMessageMethodsVisitor<T> CreateMessageMethodsVisitor();
        protected abstract IPhotoMethodsVisitor<T> CreatePhotoMethodsVisitor();
        protected abstract IUserMethodsVisitor<T> CreateUserMethodsVisitor();

        protected abstract Error ParseError();

        protected abstract IVkObjectVisitor<T> CreateVkObjectVisitor();

        public Error GetError()
        {
            var error = this.ParseError();
            if (error != null)
            {
                switch (error.ErrorCode)
                {
                    case 14:
                        error.IsCritical = false;
                        this.Environment.NeedResend = true;
                        var captchaValue = this.Environment.CheckCaptcha(error.ErrorParameters["captcha_img"]);
                        var cid = error.ErrorParameters["captcha_sid"];
                        this.Environment.PrepareParametersExtension = dictionary =>
                        {
                            dictionary["captcha_sid"] = cid;
                            dictionary["captcha_key"] = captchaValue;
                        };
                        break;
                    case 9:
                        error.IsCritical = false;
                        this.Environment.NeedResend = true;
                        break;
                }
            }
            return error;
        }

        #region Implementation of IBoardMethodsVisitor<T>

        public String VisitAddTopic(AddTopic method, T data)
        {
            return this.boardVisitor.VisitAddTopic(method, data);
        }

        public String VisitAddComment(AddComment method, T data)
        {
            return this.boardVisitor.VisitAddComment(method, data);
        }

        #endregion

        #region Implementation of IFriendMethodsVisitor<T>

        public List<User> VisitFriendsGet(Get method, T data)
        {
            return this.friendVisitor.VisitFriendsGet(method, data);
        }

        public String VisitFriendsAdd(Add method, T data)
        {
            return this.friendVisitor.VisitFriendsAdd(method, data);
        }

        #endregion

        #region Implementation of IGroupMethodsVisitor<T>

        public List<Group> VisitGroupsGet(Methods.Groups.Get method, T data)
        {
            return this.groupVisitor.VisitGroupsGet(method, data);
        }

        public List<IsMemberResult> VisitGroupsIsMember(IsMember method, T data)
        {
            return this.groupVisitor.VisitGroupsIsMember(method, data);
        }

        #endregion

        #region Implementation of IMessageMethodsVisitor<T>

        public String VisitMessageSend(Send method, T data)
        {
            return this.messageVisitor.VisitMessageSend(method, data);
        }

        #endregion

        #region Implementation of IPhotoMethodsVisitor<T>

        public Album VisitPhotosCreateAlbum(CreateAlbum method, T data)
        {
            return this.photoVisitor.VisitPhotosCreateAlbum(method, data);
        }

        public List<Album> VisitPhotosGetAlbums(GetAlbums method, T data)
        {
            return this.photoVisitor.VisitPhotosGetAlbums(method, data);
        }

        public List<Photo> VisitPhotosGet(Methods.Photos.Get method, T data)
        {
            return this.photoVisitor.VisitPhotosGet(method, data);
        }

        public List<PhotoComment> VisitPhotoGetComments(GetComments method, T data)
        {
            return this.photoVisitor.VisitPhotoGetComments(method, data);
        }

        public String VisistPhotoCreateComment(CreateComment method, T data)
        {
            return this.photoVisitor.VisistPhotoCreateComment(method, data);
        }

        public UploadServerData VisitPhotosGetUploadServer(GetUploadServer method, T data)
        {
            return this.photoVisitor.VisitPhotosGetUploadServer(method, data);
        }

        public List<Photo> VisitPhotosSave(Save method, T data)
        {
            return this.photoVisitor.VisitPhotosSave(method, data);
        }

        public Int32 VisitPhotosGetAlbumsCount(GetAlbumsCount method, T data)
        {
            return this.photoVisitor.VisitPhotosGetAlbumsCount(method, data);
        }

        public Int32 VisitPhotosDeleteAlbum(DeleteAlbum method, T data)
        {
            return this.photoVisitor.VisitPhotosDeleteAlbum(method, data);
        }

        #endregion

        #region Implementation of IUserMethodsVisitor<T>

        public User VisitUsersGet(Methods.Users.Get method, T data)
        {
            return this.userVisitor.VisitUsersGet(method, data);
        }

        #endregion
    }
}