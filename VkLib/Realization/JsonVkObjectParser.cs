using System;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction.Domain;
using VkLib.Objects;
using VkLib.Objects.ServiceObjects;

namespace VkLib.Realization
{
    public class JsonVkObjectParser : IVkObjectVisitor<JToken>
    {
        public void VisitGroup(Group obj, JToken data)
        {
            obj.Id = $"-{data.SafeGetValue<String>("id")}";
            obj.Name = data.SafeGetValue<String>("name");
            obj.ScreenName = data.SafeGetValue<String>("screen_name");
            obj.IsClosed = data.SafeGetValue<Boolean>("is_closed");
            obj.Type = data.SafeGetValue<String>("group");
            obj.IsAdmin = data.SafeGetValue<Boolean>("is_admin");
            obj.AdminLevel = data.SafeGetValue<String>("admin_level");
            obj.IsMember = data.SafeGetValue<Boolean>("is_member");
            obj.Photo50 = data.SafeGetValue<String>("photo_50");
            obj.Photo100 = data.SafeGetValue<String>("photo_100");
            obj.Photo200 = data.SafeGetValue<String>("photo_200");
        }

        public void VisitAlbum(Album obj, JToken data)
        {
            obj.Id = data.SafeGetValue<String>("id");
            obj.ThumbId = data.SafeGetValue<String>("thumb_id");
            obj.OwnerId = data.SafeGetValue<String>("owner_id");
            obj.Title = data.SafeGetValue<String>("title");
            obj.Description = data.SafeGetValue<String>("description");
            obj.Created = data.SafeGetValue<Int64>("created").ToDateTimeFromUnixTime();
            var updated = data.SafeGetValue<Int64?>("updated");
            if (updated.HasValue)
            {
                obj.Updated = updated.Value.ToDateTimeFromUnixTime();
            }
            obj.CanUpload = data.SafeGetValue<Boolean>("can_upload");
            obj.UploadOnlyAdmins = data.SafeGetValue<Boolean>("upload_by_admins_only");
            obj.CommentsDisabled = data.SafeGetValue<Boolean>("comments_disabled");
            obj.Size = data.SafeGetValue<Int32>("size");
            var thumbSrc = data.SafeGetValue<String>("thumb_src");
            if (!String.IsNullOrEmpty(thumbSrc))
            {
                obj.ThumbSource = thumbSrc;
            }
        }

        public void VisitPhoto(Photo obj, JToken data)
        {
            obj.Id = data.SafeGetValue<String>("id");
            obj.AlbumId = data.SafeGetValue<String>("album_id");
            obj.OwnerId = data.SafeGetValue<String>("owner_id");
            obj.Photo75 = data.SafeGetValue<String>("photo_75");
            obj.Photo130 = data.SafeGetValue<String>("photo_130");
            obj.Photo604 = data.SafeGetValue<String>("photo_604");
            obj.Photo807 = data.SafeGetValue<String>("photo_807");
            obj.Photo1280 = data.SafeGetValue<String>("photo_1280");
            obj.Photo2560 = data.SafeGetValue<String>("photo_2560");
            obj.Text = data.SafeGetValue<String>("text");
            obj.InsertDate = data.SafeGetValue<Int64>("date").ToDateTimeFromUnixTime();
            var commentsToken = data["comments"];
            if (commentsToken != null)
            {
                obj.Comments = data["comments"].SafeGetValue<Int32>("count");
            }
        }

        public void VisitMessage(Message obj, JToken data)
        {
        }

        public void VisitPhotoComment(PhotoComment obj, JToken data)
        {
            obj.Id = data.SafeGetValue<String>("id");
            obj.FromId = data.SafeGetValue<String>("from_id");
            obj.CanEdit = data.SafeGetValue<Boolean>("can_edit");
            obj.Date = data.SafeGetValue<Int64>("date").ToDateTimeFromUnixTime();
            obj.Text = data.SafeGetValue<String>("text");
        }

        public void VisitUser(User obj, JToken data)
        {
            obj.Id = data.SafeGetValue<String>("id");
            obj.FirstName = data.SafeGetValue<String>("first_name");
            obj.LastName = data.SafeGetValue<String>("last_name");
            obj.ScreenName = data.SafeGetValue<String>("screen_name");
            obj.Photo50 = data.SafeGetValue<String>("photo_50");
            obj.Photo100 = data.SafeGetValue<String>("photo_100");
            obj.Online = data.SafeGetValue<Boolean?>("online");

            var cityData = data["city"];
            if (cityData != null)
            {
                var city = new City();
                city.Accept(this, data["city"]);
                obj.City = city;
            }


            var userSex = data.SafeGetValue<String>("sex");
            if (!String.IsNullOrEmpty(userSex))
            {
                switch (userSex)
                {
                    case "1":
                        obj.Sex = UserSex.Female;
                        break;
                    case "2":
                        obj.Sex = UserSex.Male;
                        break;
                }
            }

            try
            {
                var bData = data.SafeGetValue<String>("bdate");
                if (!String.IsNullOrEmpty(bData))
                {
                    // Формат DD.MM
                    if (bData.Length == 5)
                    {
                        var tokens = bData.Split('.');
                        var month = Int32.Parse(tokens[1]);
                        var day = Int32.Parse(tokens[0]);
                        obj.BirthDay = new DateTime(User.DefaultYear, month, day);
                    }
                    // Формат DD.MM.YYYY
                    if (bData.Length == 10)
                    {
                        var tokens = bData.Split('.');
                        var year = Int32.Parse(tokens[2]);
                        var month = Int32.Parse(tokens[1]);
                        var day = Int32.Parse(tokens[0]);
                        obj.BirthDay = new DateTime(year, month, day);
                    }
                }
            }
            catch (Exception ex)
            {
                // залогировать
            }
        }

        public void VisitError(Error obj, JToken data)
        {
            obj.ErrorCode = data.SafeGetValue<int>("error_code");
            obj.ErrorMsg = data.SafeGetValue<string>("error_msg");

            switch (obj.ErrorCode)
            {
                case 14:
                    var sid = data.SafeGetValue<string>("captcha_sid");
                    var img = data.SafeGetValue<string>("captcha_img");
                    obj.ErrorParameters.Add("captcha_sid", sid);
                    obj.ErrorParameters.Add("captcha_img", img);
                    break;
            }
        }

        public void VisitCity(City obj, JToken data)
        {
            obj.Id = data.SafeGetValue<String>("id");
            obj.Title = data.SafeGetValue<String>("title");
        }

        public void VisitUploadServerData(UploadServerData obj, JToken data)
        {
            obj.UploadUrl = data.SafeGetValue<String>("upload_url");
            obj.AlbumId = data.SafeGetValue<String>("album_id");
            obj.UserId = data.SafeGetValue<String>("user_id");
        }
    }
}