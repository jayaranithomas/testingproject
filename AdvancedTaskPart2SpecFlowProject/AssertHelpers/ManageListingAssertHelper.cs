using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.AssertHelpers
{
    public class ManageListingAssertHelper
    {
        public void AssertAddNewServiceListing(string manageListingTitle, string expectedTitle)
        {
            Console.WriteLine(manageListingTitle);
            Assert.That(manageListingTitle.Equals(expectedTitle), "Share skill listing not added successfully");
        }
        public void AssertAddServiceListingWithInsufficientData(String actual, String expected)
        {

            Assert.That(actual.Equals(expected), "The service listing has been added successfully");

        }
        public void AssertServiceListingUpdated(String actual, String expected)
        {
            Console.WriteLine(actual);
            Assert.That(actual.Equals(expected), "The service listing has not been updated successfully");

        }
        public void AssertDeleteServiceListing(String actual, String expected)
        {
            Assert.That(actual.Equals(expected), "The service listing has not been deleted successfully");

        }
        public void AssertDenyDeleteServiceListing(String actual, String expected)
        {
            Assert.That(actual.Equals(expected), "The service listing has been deleted successfully");

        }

        public void AssertUpdateServiceListingWithInsufficientData(String actual, String expected)
        {

            Assert.That(actual.Equals(expected), "The service listing has been updated successfully");

        }
        public void AssertUpdateShareSkillWithTitleMoreThan100Characters(String actual, String expected)
        {
            Console.WriteLine("The length of the Title is: " + actual.Length);
            Assert.That(!expected.Equals(actual), "The service listing with more than 100 characters title has been added");

        }
        public void AssertUpdateShareSkillWithDescriptionMoreThan600Characters(String actual, String expected)
        {
            Console.WriteLine("The length of the Description is: " + actual.Length);
            Assert.That(!expected.Equals(actual), "The service listing with more than 100 characters description has been added");

        }
        public void AssertUpdateShareSkillWithCategory(String actual, String expected)
        {
            Console.WriteLine(actual);
            Assert.That(actual.Equals(expected), "The service listing has not been updated successfully");

        }
        public void AssertUpdateShareSkillWithType(String actual, String expected)
        {
            Console.WriteLine(actual);
            Assert.That(actual.Equals(expected), "The service listing has not been updated successfully");

        }
        public void AssertUpdateShareSkillWithTrade(String actual, String expected)
        {
            Console.WriteLine(actual);
            Assert.That(actual.Equals(expected), "The service listing has not been updated successfully");

        }
        public void AssertViewShareSkillDetails(String actual, String expected)
        {
            Console.WriteLine(actual);
            Assert.That(actual.Equals(expected), "The service listing has not been viewed successfully");

        }
        public void AssertToggleActiveStatus(String actual, String expected1, String expected2)
        {
            Console.WriteLine(actual);
            Assert.That(actual.Equals(expected1) || actual.Equals(expected2), "The active status of service listing has not been toggled successfully");

        }



    }
}
