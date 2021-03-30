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
             app.Auth.Login(new AccountData("admin", "secret"));

            List<ContactData> oldContacts = ContactData.GetAll();


             ContactData contact = new ContactData("Maga", "Lezgin");

             ContactData toBeModified = oldContacts[0];




             app.Contacts.Modify(contact, toBeModified);



             List<ContactData> newContacts = ContactData.GetAll();
             oldContacts[0] = contact;
             oldContacts.Sort();
             newContacts.Sort();
             Assert.AreEqual(oldContacts, newContacts);

        } 
     } 

  }

