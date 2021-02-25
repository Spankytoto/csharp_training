using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{

    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            
            ContactData contact = new ContactData();
            contact.Firstname = "Anton";
            contact.Lastname = "Antonov";
            app.Contacts.Modify(1, contact);
        }
    }


}