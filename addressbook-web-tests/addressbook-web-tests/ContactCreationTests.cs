using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToNewContactPage();
            ContactData contact = new ContactData();
            contact.Firstname = "Ivan";
            contact.Lastname = "Ivanov";
            FillContactForm(contact);
            SubmitContactCreation();
            BackToHomePage();
            Logout();
        }

     }
 }

