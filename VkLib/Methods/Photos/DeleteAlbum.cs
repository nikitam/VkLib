// File: DeleteAlbum.cs
// Author: nikitam
// Created: 13:04 - 25.02.2017

using System;
using VkLib.Abstraction;

namespace VkLib.Methods.Photos
{
    public class DeleteAlbum: IVkMethod<Int32>
    {
        [VkParam("album_id")]
        public String AlbumId { get; set; }
        [VkParam("group_id")]
        public String GroupId { get; set; }

        public Int32 Accept<T>(VkMethodVisitor<T> visitor, T data)
        {
            return visitor.VisitPhotosDeleteAlbum(this, data);
        }

        public String Name
        {
            get { return "photos.deleteAlbum"; }
        }

        public Boolean NeedAuthentication
        {
            get { return true; }
        }


    }
}