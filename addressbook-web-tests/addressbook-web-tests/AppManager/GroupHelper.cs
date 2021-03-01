﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }


        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            GroupCount();
            SelectGroup(1);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }



        public GroupHelper Remove()
        {
            manager.Navigator.GoToGroupsPage();
            GroupCount();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Create (GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }



        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }





        public GroupHelper ReturnToGroupsPage()
            {
                driver.FindElement(By.LinkText("group page")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
            return this;
            }

            public GroupHelper SubmitGroupCreation()
            {
                driver.FindElement(By.Name("submit")).Click();
            return this;
            }



            public GroupHelper RemoveGroup()
            {
                driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
            }

            public GroupHelper GroupCount()
            {
            if (IsElementPresent(By.Name("selected[]")))
            {
            }
            else
            {
                GroupData group = new GroupData("321");
                group.Header = "111";
                group.Footer = "";
                manager.Groups.Create(group);
            }
            return this;
            }



            public GroupHelper SelectGroup(int index)
            {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
            }

            public GroupHelper InitGroupModification()
            {
            driver.FindElement(By.Name("edit")).Click();
            return this;
            }

            public GroupHelper InitNewGroupCreation()

            {
            driver.FindElement(By.Name("new")).Click();
            return this;
            }

             public GroupHelper SubmitGroupModification()
             {
             driver.FindElement(By.Name("update")).Click();
             return this;
             }




    }
    }
