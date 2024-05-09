using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers
{
    public class SkillsAssertHelper
    {
        public void AssertDeleteAllSkillRecords(int rowCount)
        {
            if (rowCount == 0) { Console.WriteLine("All Skill Records are Deleted"); }
            Assert.That(rowCount == 0, "The Skill records has not been deleted successfully");

        }
        public void AssertAddNewSkill(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The skill record has not been added successfully");

        }
        public void AssertNewSkillNotAddedSuccessfully(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The skill record has been added successfully");

        }
        public void AssertCancelSkill(String expected, String actual)
        {
            Assert.That(!expected.Equals(actual), "Skill record not cancelled successfully");

        }
        public void AssertUpdateSkill(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The Skill record has not been updated successfully");

        }
        public void AssertExistingSkillNotUpdatedSuccessfully(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The Skill record has been updated successfully");

        }
    }
}
