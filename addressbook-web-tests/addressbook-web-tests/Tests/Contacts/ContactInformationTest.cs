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
            string fromDetailForm = app.Contacts.GetContactInformationFromInternals(0);
            var fromEditForm = app.Contacts.GetContactInformationFromEditFormHomeWork(0);

            //Assert.IsTrue(fromDetailForm.Contains(fromEditForm.Lastname) && fromDetailForm.Contains(fromEditForm.Firstname));

            Assert.AreEqual(fromDetailForm, fromEditForm);




        } 


    }
}