using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsShareSkillComponent;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class ShareSkillSteps
    {
        string actualMessage;
        string expectedMessage;
        string errorMessageString;
        string actualTitle;
        string actualDescription;
        int subCategoryFlag = 0;
        IWebElement? tag;

        ShareSkillsAddComponent shareSkillsAddComponent;
        ShareSkillRenderingComponent shareSkillRenderingComponent;
        ShareSkillAssertHelper shareSkillAssertHelper;
        public ShareSkillSteps()
        {
            shareSkillsAddComponent = new ShareSkillsAddComponent();
            shareSkillRenderingComponent = new ShareSkillRenderingComponent();
            shareSkillAssertHelper = new ShareSkillAssertHelper();
            actualMessage = string.Empty;
            expectedMessage = string.Empty;
            errorMessageString = string.Empty;
            actualTitle = string.Empty;
            actualDescription = string.Empty;
        }

        public void SetSubCategoryFlag()
        {
            subCategoryFlag = 1;
        }

        public void AddNewShareSkill(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);
            string expectedUrl = "http://localhost:5000/Home/ListingManagement";
            string actualUrl = shareSkillRenderingComponent.GetCurrentUrl();
            shareSkillAssertHelper.AssertAddNewShareSkill(expectedUrl, actualUrl);

        }
        public void AddShareSkillWithInsufficientData(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            actualMessage = shareSkillRenderingComponent.CapturePopupMessage();

            if (subCategoryFlag == 0)
                errorMessageString = shareSkillRenderingComponent.CaptureErrorMessage();
            else
            {
                errorMessageString = shareSkillRenderingComponent.CaptureSubcategoryErrorMessage();
                subCategoryFlag = 0;
            }

            expectedMessage = "Please complete the form correctly.";

            shareSkillAssertHelper.AssertAddShareSkillWithInsufficientData(expectedMessage, actualMessage);
        }
        public void AddShareSkillWithSpecialCharacters(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            actualMessage = shareSkillRenderingComponent.CapturePopupMessage();
            errorMessageString = shareSkillRenderingComponent.CaptureErrorMessage();
            shareSkillAssertHelper.AssertAddShareSkillWithSpecialCharacters(errorMessageString);

        }
        public void AddShareSkillWithTitleMoreThan100Characters(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            actualTitle = shareSkillsAddComponent.GetTitle();
            shareSkillAssertHelper.AssertAddShareSkillWithTitleMoreThan100Characters(shareSkillDM.title, actualTitle);

        }
        public void AddShareSkillWithDescriptionMoreThan600Characters(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            actualDescription = shareSkillsAddComponent.GetDescription();
            shareSkillAssertHelper.AssertAddShareSkillWithDescriptionMoreThan600Characters(shareSkillDM.description, actualDescription);

        }
        public void AddShareSkillWithMultipleTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);
            for (int i = 1; i <= 10; i++)
            {
                tag?.SendKeys("tag" + i.ToString() + "");
                tag?.SendKeys(Keys.Enter);
            }
            var tagCount = shareSkillRenderingComponent.GetTagCount();
            shareSkillAssertHelper.AssertAddShareSkillWithMultipleTags(tagCount);

        }
        public void AddShareSkillWithDuplicateTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);
            for (int i = 1; i <= 2; i++)
            {
                tag?.SendKeys("tag");
                tag?.SendKeys(Keys.Enter);
            }
            var tagCount = shareSkillRenderingComponent.GetTagCount();
            shareSkillAssertHelper.AssertAddShareSkillWithDuplicateTags(tagCount);

        }
        public void AddShareSkillWithSpecialCharactersInTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);

            tag?.SendKeys("$^%$%^FHGFHGFG7655");
            tag?.SendKeys(Keys.Enter);

            var tagCount = shareSkillRenderingComponent.GetTagCount();
            shareSkillAssertHelper.AssertAddShareSkillWithSpecialCharactersInTags(tagCount);

        }
        public void AddShareSkillWithSpacesOnlyInTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);

            tag?.SendKeys("             ");
            tag?.SendKeys(Keys.Enter);

            var tagCount = shareSkillRenderingComponent.GetTagCount();
            shareSkillAssertHelper.AssertAddShareSkillWithSpacesOnlyInTags(tagCount);

        }
        public void DeleteShareSkillListingTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);
            tag?.SendKeys("T1");
            tag?.SendKeys(Keys.Enter);
            tag = shareSkillRenderingComponent.TagRemoveLocator(index);
            tag?.Click();
            var tagCount = shareSkillRenderingComponent.GetTagCount();
            shareSkillAssertHelper.AssertDeleteShareSkillListingTags(tagCount);

        }
        public void CancelShareSkillListing(ShareSkillsDM shareSkillDM)
        {
            shareSkillsAddComponent.SetCancelFlag(1);
            shareSkillsAddComponent.AddShareSkills(shareSkillDM);
            shareSkillAssertHelper.AssertCancelShareSkillListing();

        }
    }
}