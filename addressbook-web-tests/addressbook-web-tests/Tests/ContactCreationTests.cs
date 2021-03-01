using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData();
            contact.Firstname = "123";
            contact.Lastname = "321";
            app.Contacts.GoToNewContactPage()
                        .FillContactForm(contact)
                        .SubmitContactCreation();
            app.Navigator.BackToHomePage();
            app.Auth.Logout();
        }

    }

 }

