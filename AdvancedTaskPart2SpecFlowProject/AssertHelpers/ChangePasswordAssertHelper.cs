using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.AssertHelpers
{
    public class ChangePasswordAssertHelper
    {
        public void AssertPasswordChange(string actual, string expected)
        {
            Assert.That(actual.Equals(expected), "Password Not Changed Successfully");

        }
        public void AssertPasswordNotChanged(string actual, string expected)
        {
            Assert.That(actual.Equals(expected), "Password Changed Successfully");

        }
    }
}
