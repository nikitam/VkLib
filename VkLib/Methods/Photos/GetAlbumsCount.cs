using System;
using VkLib.Abstraction;

namespace VkLib.Methods.Photos
{
    public class GetAlbumsCount: IVkMethod<Int32>
    {
        [VkParam("user_id")]
        public String UserId { get; set; }
        [VkParam("group_id")]
        public String GroupId { get; set; }

        public Int32 Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotosGetAlbumsCount(this, data);
        }

        public String Name
        {
            get { return "photos.getAlbumsCount"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }

    }
}