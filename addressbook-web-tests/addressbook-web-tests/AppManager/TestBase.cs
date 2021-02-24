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
        public ApplicationManager app;

      //  protected NavigationHelper navigator;
      //  protected LoginHelper loginHelper;
      //  protected GroupHelper groupHelper;
       // protected ContactHelper contactHelper;

       // public IWebDriver driver;
       // public string baseURL;


        [SetUp]
        public void SetupTest()
        {
     //   navigator = new NavigationHelper(driver, baseURL);
    //    loginHelper = new LoginHelper(driver);
    //    groupHelper = new GroupHelper(driver);
     //   contactHelper = new ContactHelper(driver);

      //  driver = new FirefoxDriver();
        app = new ApplicationManager();
       // baseURL = "http://localhost/addressbook/";
        


    }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }



        }


    }


