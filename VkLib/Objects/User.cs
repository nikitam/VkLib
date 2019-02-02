using System;
using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class User : VkPrincipal
    {
        public const Int32 DefaultYear = 1900;

        public String FirstName { get; set; }
        public String LastName { get; set; }

        public UserSex Sex { get; set; }
        public DateTime? BirthDay { get; set; }
        public Boolean? Online { get; set; }

        public City City { get; set; }

        public User()
        {
            this.Sex = UserSex.NotDefined;
        }

        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitUser(this, data);
        }

        public override String DisplayName
        {
            get { return $"{this.FirstName} {this.LastName}"; }
        }

        public Int32? Age
        {
            get
            {
                if (this.BirthDay == null)
                {
                    return null;
                }

                if (this.BirthDay.Value.Year == User.DefaultYear)
                {
                    return null;
                }

                return DateTime.Today.Year - this.BirthDay.Value.Year;
            }
        }

        public String CityTitle
        {
            get
            {
                return City?.Title.ToLower();
            }
        }
    }

    public enum UserSex
    {
        NotDefined = 0,
        Female = 1,
        Male = 2
    }
}