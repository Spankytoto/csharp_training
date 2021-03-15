using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData contact = new ContactData("PUPER", "SUPER");
            //contact.Firstname = "123";
            //contact.Lastname = "321";


            app.Contacts.CreateContact(0, contact);
            app.Auth.Logout();

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List <ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }

 }

