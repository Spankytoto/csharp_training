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
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            //app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("CCC");
            group.Header = "ddd";
            group.Footer = "bbb";
            app.Groups.Create(group);
        }


        [Test]
        public void EpmtyGroupCreationTest()
        {
            //app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);

        }


    }
      
 }
  
 


