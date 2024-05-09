using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class AboutMeSteps
    {
        string actualMessage;
        string expectedMessage;

        AboutMeEditComponent aboutMeEditComponent;
        AboutMeRenderingComponent aboutMeRenderingComponent;
        AboutMeAssertHelper aboutMeAssertHelper;
        public AboutMeSteps()
        {
            actualMessage = string.Empty;
            expectedMessage = string.Empty;
            aboutMeEditComponent = new AboutMeEditComponent();
            aboutMeRenderingComponent = new AboutMeRenderingComponent();
            aboutMeAssertHelper = new AboutMeAssertHelper();
        }

        public void SelectAvailabilityOption(string option, int flag)
        {
            aboutMeEditComponent.EditAvailabilityProfile(option, flag);
            if (flag == 0)
            {
                actualMessage = aboutMeRenderingComponent.CapturePopupMessage();
                expectedMessage = "Availability updated";
                aboutMeAssertHelper.AssertSelectAvailabilityOption(expectedMessage, actualMessage);
            }
            else
            {
                aboutMeAssertHelper.AssertCancelAvailabilityOption(); 
            }

        }
        public void SelectHoursOption(string option, int flag)
        {
            aboutMeEditComponent.EditHoursProfile(option, flag);
            if (flag == 0)
            {
                actualMessage = aboutMeRenderingComponent.CapturePopupMessage();
                expectedMessage = "Availability updated";
                aboutMeAssertHelper.AssertSelectHoursOption(expectedMessage, actualMessage);
            }
            else
            {
                aboutMeAssertHelper.AssertCancelAvailabilityOption();
            }

        }
        public void SelectTargetOption(string option, int flag)
        {
            aboutMeEditComponent.EditTargetProfile(option, flag);
            if (flag == 0)
            {
                actualMessage = aboutMeRenderingComponent.CapturePopupMessage();
                expectedMessage = "Availability updated";
                aboutMeAssertHelper.AssertSelectTargetOption(expectedMessage, actualMessage);
            }
            else
            {
                aboutMeAssertHelper.AssertCancelAvailabilityOption();
            }

        }
    }
}
