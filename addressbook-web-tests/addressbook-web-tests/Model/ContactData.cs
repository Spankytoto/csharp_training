using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Threading;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        public string FIO;
        //protected string firstname = "";
        //protected string lastname = "";
        

    public ContactData (string firstname, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;
        }

    public ContactData ()
        {

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
            return "firstname = " + Firstname + "/nlastname = " + Lastname;

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

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
                }
            }

            set
            {
                AllPhones = value;
            }
        }

        private string Cleanup(string phone)
        {
          if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string AllPhones { get; set; }


        private string CleanUP(string allEmails)
        {
            if (allEmails == null || allEmails == "")
            {
                return "";
            }
            return Regex.Replace(allEmails, "[ -()]", "") + "\r\n";
        }

        public string AllEmails { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUP(Email) + CleanUP(Email2) + CleanUP(Email3)).Trim();
                }
            }

            set
            {
                AllEmails = value;
            }
        }

            public static List<ContactData> GetAll()
        {
            Thread.Sleep(2000);
            using (AddressBookDB db = new AddressBookDB())
            {

                return (from s in db.Contacts select s).ToList();
            }
        }
    }






    }

