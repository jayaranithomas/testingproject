using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.AssertHelpers
{
    public class CertificationAssertHelper
    {
        public void AssertDeleteAllCertificationRecords(int rowCount)
        {
            if (rowCount == 0) { Console.WriteLine("All Certification Records Deleted"); }
            Assert.That(rowCount == 0, "The certification records has not been deleted successfully");

        }
        public void AssertAddNewCertification(String actual, String expected)
        {

            Assert.That(actual.Equals(expected), "The certification record has not been added successfully");

        }
        public void AssertAddNewCertificationWithInsufficientData(String actual, String expected)
        {

            Assert.That(actual.Equals(expected), "The certification record has been added successfully");

        }
        public void assertCancelAddNewCerificationRecord(String lastCertificationName)
        {
            if (!lastCertificationName.Equals("CyberSecurity Fundamentals"))
            { Console.WriteLine("Certification record cancelled before adding"); }
            Assert.That(!lastCertificationName.Equals("CyberSecurity Fundamentals"), "The certification record not cancelled successfully");

        }

    }
}
