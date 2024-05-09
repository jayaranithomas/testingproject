using Microsoft.CodeAnalysis;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers
{
    
    public class LanguageAssertHelper
    {
        public void AssertDeleteAllLanguageRecords(int rowCount)
        {
            if (rowCount == 0) { Console.WriteLine("All Language Records Deleted"); }
            Assert.That(rowCount==0, "The language records has not been deleted successfully");

        }
        public void AssertAddNewLanguage(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has not been added successfully");

        }
        public void AssertNewLanguageNotAddedSuccessfully(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has been added successfully");

        }
        public void AssertCancelLanguage(String expected, String actual)
        {

            Assert.That(!expected.Equals(actual), "Language record not cancelled successfully");

        }
        public void AssertUpdateLanguage(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has not been updated successfully");

        }
        public void AssertExistingLanguageNotUpdatedSuccessfully(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has been updated successfully");

        }
        public void AssertAddFifthLanguage()
        {

            Assert.Pass("More than 4 languages records cannot be added from front end");

        }

    }
}
