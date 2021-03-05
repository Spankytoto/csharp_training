using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }



        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;

        }



        public ContactHelper GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text, element.Text));
            }

            return contacts;
        }

        public ContactHelper Modify(int p, ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(0);
            InitContactModification();
            FillContactForm(contact);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper ContactRemove(int f)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(f);
            ContactRemove();
            ReturnToContactsPage();
            return this;
        }



        public ContactHelper ContactCount()
        {
            manager.Navigator.GoToHomePage();
            if (IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
            }
            else
            { 
            ContactData contact = new ContactData("123", "321");
            //contact.Firstname = "123";
            //contact.Lastname = "321";
            manager.Contacts.GoToNewContactPage()
            .FillContactForm(contact)
            .SubmitContactCreation();
            manager.Navigator.BackToHomePage();
             }
            return this;
             }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }


        public ContactHelper ContactRemove()
        {
            {
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                driver.SwitchTo().Alert().Accept();
                return this;
            }
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }



    }
}
