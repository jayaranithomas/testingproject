using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers
{
    public class AboutMeAssertHelper
    {
        public void AssertSelectAvailabilityOption(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The Availability Option is not updated successfully");

        }
        public void AssertCancelAvailabilityOption()
        {

            Assert.Pass("Selection Cancelled");

        }
        public void AssertSelectHoursOption(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The Hours Option is not updated successfully");

        }
        public void AssertSelectTargetOption(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The Target Option is not updated successfully");

        }
    }
}
