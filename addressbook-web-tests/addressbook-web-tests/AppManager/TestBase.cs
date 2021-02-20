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
    public class TestBase
    {
        protected ApplicationManager app;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        protected IWebDriver driver;
        protected string baseURL;


        [SetUp]
        public void SetupTest()
        {
        driver = new FirefoxDriver();
        app = new ApplicationManager();
        baseURL = "http://localhost/addressbook/";
        
        loginHelper = new LoginHelper(driver);
        navigator = new NavigationHelper(driver, baseURL);
        groupHelper = new GroupHelper(driver);
        contactHelper = new ContactHelper(driver);

    }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }



        }


    }


