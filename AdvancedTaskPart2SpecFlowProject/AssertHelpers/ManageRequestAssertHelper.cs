using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.AssertHelpers
{
    public class ManageRequestAssertHelper
    {
        public void AssertViewSentRequests(int pageCount, int requestCount)
        {
            Console.WriteLine("Page Count is: " + pageCount + " and Request Count is: " + requestCount + "");
            Assert.That(pageCount > 0, "No Requests to List");
        }
        public void AssertViewReceivedRequests(int pageCount, int requestCount)
        {
            Console.WriteLine("Page Count is: " + pageCount + " and Request Count is: " + requestCount + "");
            Assert.That(pageCount > 0, "No Requests to List");
        }

        public void AssertSentAndWithdrawRequests(string actualSentMessage, string expectedSentMessage, string actualWithdrawMessage, string expectedWithdrawMessage)
        {
            Assert.That(actualSentMessage.Equals(expectedSentMessage) && actualWithdrawMessage.Equals(expectedWithdrawMessage), "Request Not sent and Withdrawn");
        }
        public void AssertCompleteSkillTradeRequest(string actual, string expected)
        {
            Assert.That(actual.Equals(expected), "Request Not Completed Successfully");
        }
        public void AssertDeclineSkillTradeRequest(string actual, string expected)
        {
            Assert.That(actual.Equals(expected), "Request Not declined Successfully");
        }

    }
}
