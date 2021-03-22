using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using addressbook_web_tests;
using System.Xml;
using System.Xml.Serialization;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Firstname = TestBase.GenerateRandomString(10),
                    Lastname = TestBase.GenerateRandomString(10),
                });


                List<GroupData> groups = new List<GroupData>();
                for (int x = 0; x < count; x++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10),
                    });

                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                    writeContactsToXmlFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();

            }

            static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
            {
                foreach (GroupData group in groups)
                {
                    writer.WriteLine(String.Format("$[0],$[1],$[2]",
                        group.Name, group.Header, group.Footer));
                }
            }

            static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            }

            static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
            {
                foreach (ContactData contact in contacts)
                {
                    writer.WriteLine(String.Format("$[0],$[1],$[2]",
                        contact.Firstname, contact.Lastname));
                }
            }

            static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
            }

        }
    }
}
