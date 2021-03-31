﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDateProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i <5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100),
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
               string [] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize
                (new StreamReader(@"groups.xml"));
        }







        [Test, TestCaseSource ("GroupDataFromXmlFile")]
        public void GroupCreationTest(GroupData groups)
        {

            List<GroupData> oldGroups = GroupData.GetAll();
            app.Auth.Login(new AccountData("admin", "secret"));

            app.Groups.Create(groups);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(groups);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "123";
            group.Footer = "123";

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]

        public void TestDBconnectivity()
        {
            Thread.Sleep(2000);
            app.Auth.Login(new AccountData("admin", "secret"));
            foreach (ContactData contact in GroupData.GetAll()[0].GetContacts())
            {
                
                System.Console.Out.WriteLine(contact);
            }
        }

        /*[Test]

        public void TestDBconnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.Write(end.Subtract(start));


            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.Write(end.Subtract(start));
        } */


    }

}
  
 


