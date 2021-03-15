using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        protected string firstname = "";
        protected string lastname = "";

    public ContactData (string firstname, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return firstname.GetHashCode();
        }


        public override string ToString()
        {
            return firstname;
        }

        public int CompareTo(ContactData other)
        {

            lastname.CompareTo(other.Lastname);

            if (Object.ReferenceEquals(other, null))

            {
                return 1;
            }
            
            else 
            {
                firstname.CompareTo(other.Firstname);
            }
            return 0;

        }



        public string Firstname { get; set; }


        public string Lastname { get; set; }

        public string id { get; set; }

    }
}
