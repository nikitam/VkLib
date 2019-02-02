using System;
using System.Collections.Generic;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class Error: VkObject
    {
        public Boolean IsCritical { get; set; }

        public Int32 ErrorCode { get; set; }

        public String ErrorMsg { get; set; }

        public Dictionary<String, String> ErrorParameters { get; private set; }

        public Error()
        {
            this.IsCritical = true;
            this.ErrorParameters = new Dictionary<String, String>();
        }
        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitError(this, data);
        }
    }
}