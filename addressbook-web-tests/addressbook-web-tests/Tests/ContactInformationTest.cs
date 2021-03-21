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
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);


            //verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }


        [Test]
        public void TestContactInformationForHomework()
        {
            ContactData fromInternal = app.Contacts.GetContactInformationFromInternals(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditFormHomeWork(0);


            Assert.AreEqual(fromInternal, fromForm);
            Assert.AreEqual(fromInternal.firstName, fromForm.firstName);
            Assert.AreEqual(fromInternal.lastName, fromForm.lastName);
            

        }


    }
}