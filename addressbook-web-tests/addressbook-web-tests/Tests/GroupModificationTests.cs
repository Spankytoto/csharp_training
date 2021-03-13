using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{

    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [SetUp]
        public void PrepareGroup()
        {
            app.Groups.GroupCount();

        }

        [Test]
        public void GroupModificationTest() {

            GroupData newData = new GroupData("zzz");
                newData.Header = "123";
                newData.Footer = "321";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        }
    }


