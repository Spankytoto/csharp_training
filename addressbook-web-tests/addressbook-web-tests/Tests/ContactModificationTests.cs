﻿using System;
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

        public void PrepareContact(AccountData account)
        {
            app.Contacts.ContactCount(account);
        }

        [Test]


        public void ContactModificationTest()
        {
            
            ContactData contact = new ContactData();
            contact.Firstname = "MEGA";
            contact.Lastname = "LOL";
            app.Contacts.Modify(1, contact);
        }
    }


}