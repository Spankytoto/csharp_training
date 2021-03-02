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
            app.Groups.Remove(1);
        }



    }

}









