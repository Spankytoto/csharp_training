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
    public class ContactRemovalTests : AuthTestBase
    {
        
        [SetUp]
        public void PrepareContact()
        {
            app.Contacts.ContactCount();
        }


        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.ContactRemove(1);
        }
    }
}




