using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager) { 
        }
       
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("user"),account.Username);
            Type(By.Name("pass"),account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            Thread.Sleep(2000);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
            throw new NotImplementedException();
        }

        public void Logout()
        {
            if (IsLoggedIn()) 
            { 
            driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;

        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        
        }
    }
}
