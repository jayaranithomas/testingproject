using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers
{
    public class ShareSkillAssertHelper
    {
        public void AssertAddNewShareSkill(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The service listing has not been added successfully");

        }
        public void AssertAddShareSkillWithInsufficientData(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The service listing has been added successfully");

        }
        public void AssertAddShareSkillWithSpecialCharacters(String expected)
        {
            Assert.That(expected.Equals("Special characters are not allowed.") || expected.Equals("First character must be an alphabet character or a number."), "The service listing has been added successfully");

        }
        public void AssertAddShareSkillWithTitleMoreThan100Characters(String expected, String actual)
        {
            Console.WriteLine("The length of the Title is: " + actual.Length);
            Assert.That(!expected.Equals(actual), "The service listing with more than 100 characters title has been added");

        }
        public void AssertAddShareSkillWithDescriptionMoreThan600Characters(String expected, String actual)
        {
            Console.WriteLine("The length of the Description is: " + actual.Length);
            Assert.That(!expected.Equals(actual), "The service listing with more than 600 characters description has been added");

        }
        public void AssertAddShareSkillWithMultipleTags(int tagCount)
        {

            Console.WriteLine("Multiple tags can be entered and the number of tags entered is: " + tagCount);

            Assert.That(tagCount == 10, "The service listing with multiple tags cannot be added");

        }
        public void AssertAddShareSkillWithDuplicateTags(int tagCount)
        {

            Console.WriteLine("Duplicate tags cannot be entered and the number of tags entered is: " + tagCount);

            Assert.That(tagCount == 1, "The service listing with duplicate tags can be added");
        }
        public void AssertAddShareSkillWithSpecialCharactersInTags(int tagCount)
        {

            Console.WriteLine("Duplicate tags cannot be entered and the number of tags entered is: " + tagCount);

            Assert.That(tagCount == 1, "The service listing with duplicate tags can be added");
        }
        public void AssertAddShareSkillWithSpacesOnlyInTags(int tagCount)
        {

            Console.WriteLine("Tags with spaces alone cannot be entered and the number of tags is: " + tagCount);

            Assert.That(tagCount == 0, "The service listing with tags having spaces only can be added");
        }

        public void AssertDeleteShareSkillListingTags(int tagCount)
        {

            Console.WriteLine("Tag entered has been removed and the number of tags is: " + tagCount);

            Assert.That(tagCount == 0, "The tag was not deleted");
        }
        public void AssertCancelShareSkillListing()
        {

            Assert.Pass("Service Listing cancelled");
        }
    }
    
}
