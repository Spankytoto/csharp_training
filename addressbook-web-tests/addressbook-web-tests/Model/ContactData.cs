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
            this.firstname = firstname;
            this.lastname = lastname;
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

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            lastname.CompareTo(other.Lastname);

            if (other.Lastname == lastname)
            {
            firstname.CompareTo(other.Firstname);
            }
            return lastname.CompareTo(other.Lastname) + firstname.CompareTo(other.Firstname);

        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
    }
}
