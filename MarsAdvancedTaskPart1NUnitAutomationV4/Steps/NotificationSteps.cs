using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsNotificationComponent;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class NotificationSteps
    {
        string actualMessage;
        string expectedMessage;

        int notificationCount;
        NotificationRenderingComponent notificationsRendering;
        NotificationAssertHelper notificationAssertHelper;
        public NotificationSteps()
        {
            notificationsRendering = new NotificationRenderingComponent();
            notificationAssertHelper = new NotificationAssertHelper();
            actualMessage = string.Empty;
            expectedMessage = string.Empty;
            
        }
        

        public void CheckNotificationsVisibility()
        {
            notificationCount = notificationsRendering.NotificationCount();
            if (notificationCount > 0)
            {
                notificationAssertHelper.AssertVisibleNotifications(notificationCount);
            }
            else
            {
                notificationAssertHelper.AssertEmptyNotifications(notificationCount);
            }
        }
        public void CheckLoadMoreButtonFunctionality()
        {
            notificationsRendering.RenderLoadMoreButton();
            Thread.Sleep(3000);
            notificationCount = notificationsRendering.NotificationCount();
            if (notificationCount > 0)
            {
                notificationAssertHelper.AssertVisibleNotifications(notificationCount);
            }
            else
            {
                notificationAssertHelper.AssertEmptyNotifications(notificationCount);
            }
        }
        public void CheckShowLessButtonFunctionality()
        {
            notificationsRendering.RenderLoadMoreButton();
            notificationsRendering.RenderShowLessButton();
            Thread.Sleep(3000);
            notificationCount = notificationsRendering.NotificationCount();
            if (notificationCount > 0)
            {
                notificationAssertHelper.AssertVisibleNotifications(notificationCount);
            }
            else
            {
                notificationAssertHelper.AssertEmptyNotifications(notificationCount);
            }
        }
        public void CheckSelectAllButtonFunctionality()
        {
            notificationsRendering.RenderSelectAllButton();
            notificationAssertHelper.AssertAllNotificationsSelected();

        }
        public void CheckUnSelectAllButtonFunctionality()
        {
            notificationsRendering.RenderUnSelectAllButton();
            notificationAssertHelper.AssertAllNotificationsUnSelected();

        }
        public void CheckMarkAsReadFunctionality()
        {
            notificationsRendering.RenderMarkAsReadComponent();
            actualMessage = notificationsRendering.CapturePopupMessage();
            expectedMessage = "Notification updated";
            notificationAssertHelper.AssertMarkAsRead(expectedMessage, actualMessage);
        }
        public void CheckSelectedDeleteFunctionality()
        {
            notificationsRendering.RenderSelectFirstComponent();
            notificationsRendering.RenderDeleteComponent();
            actualMessage = notificationsRendering.CapturePopupMessage();
            expectedMessage = "Notification updated";
            notificationAssertHelper.AssertSelectedDelete(expectedMessage, actualMessage);

        }

    }
}
