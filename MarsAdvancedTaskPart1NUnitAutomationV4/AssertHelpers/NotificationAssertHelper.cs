using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers
{
    public class NotificationAssertHelper
    {
        
        public void AssertVisibleNotifications(int notificationCount)
        {
            Console.WriteLine("Number of notifications visible is " + notificationCount + "");
            Assert.That(notificationCount > 0, "The notification is not visible");
        }
        public void AssertEmptyNotifications(int notificationCount)
        {
            Console.WriteLine("No Notifications Present");
            Assert.That(notificationCount == 0, " Notifications are present");
        }
        public void AssertAllNotificationsSelected()
        {
            Assert.Pass("All Notifications Selected");
        }
        public void AssertAllNotificationsUnSelected()
        {
            Assert.Pass("All Notifications UnSelected");
        }
        public void AssertMarkAsRead(String expected, String actual)
        {
            Assert.That(actual.Equals(expected), "Notifications Not Marked Read");
        }
        public void AssertSelectedDelete(String expected, String actual)
        {
            Assert.That(actual.Equals(expected), "Notification Not Deleted");
        }
    }
}
