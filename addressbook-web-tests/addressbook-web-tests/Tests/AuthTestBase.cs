using System;
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
    public class AuthTestBase : TestBase
    {

        [SetUp]
        public void SetupLogin()
        {

            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));

        }
    }
}
