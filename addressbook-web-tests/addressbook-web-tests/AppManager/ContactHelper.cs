﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            contactCashe = null;
            return this;
        }

        public void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilterForDelete();
            //SelectContactForAdd(contact.id);
            CommitDeleteFromGroup();
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitDeleteFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContactForAdd(contact.id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void ClearGroupFilterForDelete()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("Rick");
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> newCells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = newCells[1].Text;
            string firstname = newCells[2].Text;
            string address = newCells[3].Text;
            string allPhones = newCells[5].Text;
            string allEmails = newCells[4].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

        }

        public string GetContactInformationFromInternals(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(0);
            ContactInternalsView();
            string FIO = driver.FindElement(By.XPath("//div[@id='content']/b[1]")).Text;
           

            return FIO;
        }
 

        public string GetContactInformationFromEditFormHomeWork(int index)
        {
            ContactData contactFromEditForm = new ContactData();
            manager.Navigator.GoToHomePage();
            SelectContact(0);
            InitContactModification();
            contactFromEditForm.Firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            contactFromEditForm.Lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");

            string FIO = contactFromEditForm.Firstname + " " + contactFromEditForm.Lastname;

            return FIO;
        }

        public ContactHelper ContactInternalsView ()
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(0);
            InitContactModification();
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,


            };
        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;

        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        private List<ContactData> contactCashe = null;


        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string firstname = "";
                    string lastname = "";
                    lastname = cells[2].Text;
                    firstname = cells[1].Text;
                    contactCashe.Add(new ContactData(lastname, firstname));
                    
                }
            
            }
            return new List<ContactData>(contactCashe);
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

        public ContactHelper Modify(ContactData contact, ContactData toBeModification)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(toBeModification.id);
            InitContactModification();
            FillContactForm(contact);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }


        public ContactHelper CreateContact(int p, ContactData contact)
        {
            GoToNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
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

        public ContactHelper ContactRemove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.id);
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
                contactCashe = null;
                return this;
            }
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }


        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public ContactHelper SelectContactForAdd(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
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
            contactCashe = null;
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name=\"entry\"]")).Count();
        }



    }
}
