using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        //protected string firstname = "";
        //protected string lastname = "";

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
            return (Firstname + " " + Lastname).GetHashCode();
        }


        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int result = Lastname.CompareTo(other.Lastname);
                {
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return Firstname.CompareTo(other.Firstname);
                }
            }

        }



        public string Firstname { get; set; }


        public string Lastname { get; set; }

        public string id { get; set; }

    }
}
