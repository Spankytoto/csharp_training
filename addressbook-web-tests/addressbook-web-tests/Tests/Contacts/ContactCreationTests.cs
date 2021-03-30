using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Xml;
using System.Xml.Serialization;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDateProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    Lastname = GenerateRandomString(100),
                }); ;
            }

            return contacts;

        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Firstname = parts[0],
                    Lastname = parts[1]
                });
            }
            return contacts;
        }



        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize
                (new StreamReader(@"contacts.xml"));
        }


        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            
            List<ContactData> oldContacts = ContactData.GetAll();
            app.Auth.Login(new AccountData("admin", "secret"));


            app.Contacts.CreateContact(0, contact);
            app.Auth.Logout();

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List <ContactData> newContacts = ContactData.GetAll();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts); 
        }

        [Test]

        public void TestDBconnectivityForContacts()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUI = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.Write(end.Subtract(start));


            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();
            end = DateTime.Now;
            System.Console.Out.Write(end.Subtract(start));
        }

    }

 }

