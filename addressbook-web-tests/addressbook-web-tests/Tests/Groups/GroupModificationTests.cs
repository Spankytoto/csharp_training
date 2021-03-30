using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{

    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {

        [SetUp]
        public void PrepareGroup()
        {
            app.Groups.GroupCount();

        }

        [Test]
        public void GroupModificationTest() {

            app.Auth.Login(new AccountData("admin", "secret"));

            GroupData newData = new GroupData("zzz");
                newData.Header = "123";
                newData.Footer = "321";

            List<GroupData> oldGroups = GroupData.GetAll();
            

            GroupData toBeModification = oldGroups[0];

            app.Groups.Modify(newData, toBeModification);



            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.id == toBeModification.id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
        }
    }


/*[Test]
public void GroupModificationTest()
{

    GroupData newData = new GroupData("zzz");
    newData.Header = "123";
    newData.Footer = "321";

    List<GroupData> oldGroups = GroupData.GetAll();
    GroupData oldData = oldGroups[0];

    app.Groups.Modify(0, newData);

    Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

    List<GroupData> newGroups = GroupData.GetAll();
    oldGroups[0].Name = newData.Name;
    oldGroups.Sort();
    newGroups.Sort();
    Assert.AreEqual(oldGroups, newGroups);

    foreach (GroupData group in newGroups)
    {
        if (group.id == oldData.id)
        {
            Assert.AreEqual(newData.Name, group.Name);
        }
    } */