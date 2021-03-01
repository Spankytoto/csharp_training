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
    public class GroupCreationTests : AuthTestBase
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
            GroupData group = new GroupData("123");
            group.Header = "123";
            group.Footer = "123";
            app.Groups.Create(group);

        }


    }
      
 }
  
 


