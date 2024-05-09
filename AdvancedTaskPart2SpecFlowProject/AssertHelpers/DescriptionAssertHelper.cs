using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.AssertHelpers
{
    public class DescriptionAssertHelper
    {
        public void AssertAddDescription(string actual, string expected)
        {
            Assert.That(actual.Equals(expected), "The description has not been added successfully");

        }
        public void AssertDescriptionNotChanged(string actual, string expected)
        {
            Assert.That(actual.Equals(expected), "The description has been added successfully");

        }

    }
}
