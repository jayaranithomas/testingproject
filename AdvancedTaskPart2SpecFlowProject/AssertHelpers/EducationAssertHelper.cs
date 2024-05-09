using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.AssertHelpers
{
    public class EducationAssertHelper
    {
        public void AssertDeleteAllEducationRecords(int rowCount)
        {
            if (rowCount == 0) { Console.WriteLine("All Education Records Deleted"); }
            Assert.That(rowCount == 0, "The education records has not been deleted successfully");

        }
        public void assertAddNewEducation(String actual, String expected)
        {

            Assert.That(actual.Equals(expected), "The education record has not been added successfully");

        }
        public void assertAddNewEducationRecordWithInsufficientData(String actual, String expected)
        {

            Assert.That(actual.Equals(expected), "The education record has not been added successfully");

        }
        public void assertCancelAddNewEducationRecord(String lastCollegeName)
        {
            if (!lastCollegeName.Equals("Monach"))
            { Console.WriteLine("Education record cancelled before adding"); }
            Assert.That(!lastCollegeName.Equals("Monach"), "The education record not cancelled successfully");

        }
    }
}
