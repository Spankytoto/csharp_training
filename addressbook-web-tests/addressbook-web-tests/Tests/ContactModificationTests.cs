using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{

    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        
        [SetUp]
        public void PrepareContact()
        {
            app.Contacts.ContactCount();
        }

        [Test]

        public void ContactModificationTest()
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData contact = new ContactData("MEGA", "LOL");
            //contact.Firstname = "MEGA";
            //contact.Lastname = "LOL";
            app.Contacts.Modify(0, contact);

//            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }


}