using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [SetUp]
        public void PrepareGroup()
        {
            app.Groups.GroupCount();
        }


        [Test]
        public void GroupRemovalTest()
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }



    }

}









