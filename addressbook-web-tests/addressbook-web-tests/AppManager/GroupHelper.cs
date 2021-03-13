using System;
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
            SelectGroup(1);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }



        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }


        private List<GroupData> groupCashe = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                List<GroupData> groups = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupData(element.Text));
                }

            }

            return new List<GroupData>(groupCashe);
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

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
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
                //driver.FindElement(By.LinkText("Logout")).Click();
            return this;
            }

            public GroupHelper SubmitGroupCreation()
            {
                driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
            }



            public GroupHelper GroupCount()
            {
            manager.Navigator.GoToGroupsPage();

            if (IsElementPresent(By.Name("selected[]")))
            {
            }
            else
            {
                GroupData group = new GroupData("321");
                group.Header = "111";
                group.Footer = "";
                manager.Groups.Create(group);
                //manager.Navigator.GoToHomePage();
            }
            return this;
            }

             public GroupHelper RemoveGroup()
             {
             driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
             groupCashe = null;
             return this;
             }

        public GroupHelper SelectGroup(int index)
            {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
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
             groupCashe = null;
             return this;
             }




    }
    }
