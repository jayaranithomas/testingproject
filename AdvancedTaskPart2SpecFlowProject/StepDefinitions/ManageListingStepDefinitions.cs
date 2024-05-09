using System;
using TechTalk.SpecFlow;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using AdvancedTaskPart2SpecFlowProject.Pages.ManageListingComponent;
using AdvancedTaskPart2SpecFlowProject.AssertHelpers;
using AdvancedTaskPart2SpecFlowProject.DataModel;


namespace AdvancedTaskPart2SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ManageListingStepDefinitions : CommonDriver
    {
        public ManageListingRenderComponents manageListingRenderComponents;
        public ManageListingAssertHelper manageListingAssertHelper;
        public AddUpdateViewAndDeleteShareSkillListing addUpdateViewAndDeleteShareSkillListing;
        public List<ShareSkillDM> shareSkillDMList;
        string manageListingTitleName = string.Empty;
        string serviceListingTitleName = string.Empty;
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        string errorMessageString = string.Empty;
        public ManageListingStepDefinitions()
        {
            manageListingRenderComponents = new ManageListingRenderComponents();
            manageListingAssertHelper = new ManageListingAssertHelper();
            addUpdateViewAndDeleteShareSkillListing = new AddUpdateViewAndDeleteShareSkillListing();
            shareSkillDMList = new List<ShareSkillDM>();
        }
        public void ReadJSONData(string testDataPath)
        {
            jsonReaderObj?.SetDataPath(testDataPath);
            shareSkillDMList = jsonReaderObj!.ReadShareSkillJsonData();
        }

        [Given(@"user reads share skill listing test data from '([^']*)'")]
        public void GivenUserReadsShareSkillListingTestDataFrom(string testDataPath)
        {
            ReadJSONData(testDataPath);
        }


        [Given(@"user logs into the Mars Portal")]
        public void GivenUserLogsIntoTheMarsPortal()
        {
            InitialSetUp(2);
        }

        [Given(@"user navigates to the service listing page")]
        public void GivenUserNavigatesToTheServiceListingPage()
        {
            manageListingRenderComponents.SelectShareSkill();
        }

        [When(@"user  enters valid data in all the fields")]
        public void WhenUserEntersValidDataInAllTheFields()
        {
            addUpdateViewAndDeleteShareSkillListing.AddShareSkills(shareSkillDMList[0]);
        }

        [Then(@"user should be navigated to the listing management page with the new share skill listed there")]
        public void ThenUserShouldBeNavigatedToTheListingManagementPageWithTheNewShareSkillListedThere()
        {
            manageListingTitleName = manageListingRenderComponents.GetFirstManageListingsTitle();
            manageListingAssertHelper.AssertAddNewServiceListing(manageListingTitleName, shareSkillDMList[0].title);
        }

        [When(@"user keeps the title text box empty and enters valid data in all other mandatory fields")]
        public void WhenUserKeepsTheTitleTextBoxEmptyAndEntersValidDataInAllOtherMandatoryFields()
        {
            addUpdateViewAndDeleteShareSkillListing.AddShareSkills(shareSkillDMList[1]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            expectedMessage = "Please complete the form correctly.";

        }

        [Then(@"Mars Portal should alert the user and should not save the new share skill listing")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheNewShareSkillListing()
        {
            manageListingAssertHelper.AssertAddServiceListingWithInsufficientData(actualMessage, expectedMessage);
        }

        [When(@"user keeps the description text box empty and enters valid data in all other mandatory fields")]
        public void WhenUserKeepsTheDescriptionTextBoxEmptyAndEntersValidDataInAllOtherMandatoryFields()
        {
            addUpdateViewAndDeleteShareSkillListing.AddShareSkills(shareSkillDMList[2]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            expectedMessage = "Please complete the form correctly.";
        }

        [When(@"user does not select any category but enters valid data in all other mandatory fields")]
        public void WhenUserDoesNotSelectAnyCategoryButEntersValidDataInAllOtherMandatoryFields()
        {
            addUpdateViewAndDeleteShareSkillListing.AddShareSkills(shareSkillDMList[3]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            expectedMessage = "Please complete the form correctly.";
        }

        [When(@"user does not select any subcategory but enters valid data in all other mandatory fields")]
        public void WhenUserDoesNotSelectAnySubcategoryButEntersValidDataInAllOtherMandatoryFields()
        {
            addUpdateViewAndDeleteShareSkillListing.AddShareSkills(shareSkillDMList[4]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureSubcategoryErrorMessage();
            expectedMessage = "Please complete the form correctly.";
        }

        [Given(@"user navigates to the listing management page")]
        public void GivenUserNavigatesToTheListingManagementPage()
        {
            manageListingRenderComponents.ManageListingTabRenderComponent();
        }

        [When(@"user  clicks on the delete icon to the right end of the first share skill listing and accepts confirmation")]
        public void WhenUserClicksOnTheDeleteIconToTheRightEndOfTheFirstShareSkillListingAndAcceptsConfirmation()
        {
            manageListingRenderComponents.SelectShareSkill();
            addUpdateViewAndDeleteShareSkillListing.AddShareSkills(shareSkillDMList[0]);
            manageListingTitleName = manageListingRenderComponents.GetFirstManageListingsTitle();
            addUpdateViewAndDeleteShareSkillListing.DeleteFirstServiceListing();
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            expectedMessage = manageListingTitleName + " has been deleted";

        }

        [Then(@"Mars Portal should alert the user and delete the selected share skill listing")]
        public void ThenMarsPortalShouldAlertTheUserAndDeleteTheSelectedShareSkillListing()
        {
            manageListingAssertHelper.AssertDeleteServiceListing(actualMessage, expectedMessage);
        }


        [Given(@"user  clicks on the pen icon to the right end of the first share skill listing")]
        public void GivenUserClicksOnThePenIconToTheRightEndOfTheFirstShareSkillListing()
        {
            manageListingTitleName = manageListingRenderComponents.GetFirstManageListingsTitle();
            manageListingRenderComponents.PenIconRenderComponent();
            serviceListingTitleName = manageListingRenderComponents.GetServiceListingsTitle();
        }

        [When(@"user updates the selected share skill listing without making any changes in it")]
        public void WhenUserUpdatesTheSelectedShareSkillListingWithoutMakingAnyChangesInIt()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkillWithoutEditing();
        }

        [Then(@"Mars Portal should save the share skill listing and navigate back to the listing management page")]
        public void ThenMarsPortalShouldSaveTheShareSkillListingAndNavigateBackToTheListingManagementPage()
        {
            manageListingAssertHelper.AssertServiceListingUpdated(manageListingTitleName, serviceListingTitleName);

        }
        [When(@"user updates the selected share skill listing by  changing all the mandatory fields")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByChangingAllTheMandatoryFields()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[5]);
            manageListingTitleName = manageListingRenderComponents.GetFirstManageListingsTitle();
            serviceListingTitleName = shareSkillDMList[5].title;
        }
        [When(@"user updates the selected share skill listing without entering title")]
        public void WhenUserUpdatesTheSelectedShareSkillListingWithoutEnteringTitle()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[6]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            expectedMessage = "Please complete the form correctly.";

        }

        [Then(@"Mars Portal should alert the user and should not save updated the share skill listing")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveUpdatedTheShareSkillListing()
        {
            manageListingAssertHelper.AssertUpdateServiceListingWithInsufficientData(actualMessage, expectedMessage);
        }

        [When(@"user updates the selected share skill listing by entering special characters in the title field")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByEnteringSpecialCharactersInTheTitleField()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[7]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            expectedMessage = "Please complete the form correctly.";
        }

        [When(@"user updates the selected share skill listing by entering a title with more than hundred characters")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByEnteringATitleWithMoreThanHundredCharacters()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[8]);
            manageListingTitleName = manageListingRenderComponents.GetFirstManageListingsTitle();
            serviceListingTitleName = shareSkillDMList[8].title;
        }

        [Then(@"Mars Portal should alert the user and save updated share skill listing with the first hundred characters only")]
        public void ThenMarsPortalShouldAlertTheUserAndSaveUpdatedShareSkillListingWithTheFirstHundredCharactersOnly()
        {
            manageListingAssertHelper.AssertUpdateShareSkillWithTitleMoreThan100Characters(manageListingTitleName, serviceListingTitleName);
        }

        [When(@"user updates the selected share skill listing without entering description")]
        public void WhenUserUpdatesTheSelectedShareSkillListingWithoutEnteringDescription()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[9]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            expectedMessage = "Please complete the form correctly.";
        }

        [When(@"user updates the selected share skill listing by entering special characters in the description field")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByEnteringSpecialCharactersInTheDescriptionField()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[10]);
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            expectedMessage = "Please complete the form correctly.";
        }

        [When(@"user updates the selected share skill listing by entering a description with more than six hundred characters")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByEnteringADescriptionWithMoreThanSixHundredCharacters()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[11]);
        }

        [Then(@"Mars Portal should alert the user and save the updated share skill listing with the first six hundred characters only in description")]
        public void ThenMarsPortalShouldAlertTheUserAndSaveTheUpdatedShareSkillListingWithTheFirstSixHundredCharactersOnlyInDescription()
        {
            string actualDescription = addUpdateViewAndDeleteShareSkillListing.GetDescription();
            string expectedDescription = shareSkillDMList[11].description;
            manageListingAssertHelper.AssertUpdateShareSkillWithDescriptionMoreThan600Characters(actualDescription, expectedDescription);
        }


        [When(@"user updates the selected share skill listing by changing category and subcategory")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByChangingCategoryAndSubcategory()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[12]);
        }

        [Then(@"Mars Portal should save the updated share skill listing and navigate back to the listing management page")]
        public void ThenMarsPortalShouldSaveTheUpdatedShareSkillListingAndNavigateBackToTheListingManagementPage()
        {
            string actualCategory = manageListingRenderComponents.GetFirstManageListingsCategory();
            string expectedCategory = shareSkillDMList[12].category;
            manageListingAssertHelper.AssertUpdateShareSkillWithCategory(actualCategory, expectedCategory);

        }

        [When(@"user updates the selected share skill listing by deleting all the tags")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByDeletingAllTheTags()
        {
            addUpdateViewAndDeleteShareSkillListing.DeleteAllTags();
            errorMessageString = manageListingRenderComponents.CaptureErrorMessage();
            actualMessage = errorMessageString;
            expectedMessage = "Please enter a tag";
        }

        [When(@"user updates the selected share skill listing by changing the service type Option")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByChangingTheservicetypeOption()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[13]);
        }

        [Then(@"Mars Portal should save the service type updated share skill listing and navigate back to the listing management page")]
        public void ThenMarsPortalShouldSaveTheServiceTypeUpdatedShareSkillListingAndNavigateBackToTheListingManagementPage()
        {
            string actualServiceType = manageListingRenderComponents.GetFirstManageListingsType();
            string expectedServiceType = "One-off";
            manageListingAssertHelper.AssertUpdateShareSkillWithType(actualServiceType, expectedServiceType);
        }

        [When(@"user updates the selected share skill listing by changing the skill trade Option")]
        public void WhenUserUpdatesTheSelectedShareSkillListingByChangingTheSkillTradeOption()
        {
            addUpdateViewAndDeleteShareSkillListing.UpdateShareSkills(shareSkillDMList[14]);
        }

        [Then(@"Mars Portal should save the skill trade updated share skill listing and navigate back to the listing management page")]
        public void ThenMarsPortalShouldSaveTheSkillTradeUpdatedShareSkillListingAndNavigateBackToTheListingManagementPage()
        {
            string actualSkillTrade = manageListingRenderComponents.GetFirstManageListingsSkillTrade();
            string expectedSkillTrade = "grey remove circle large icon";
            manageListingAssertHelper.AssertUpdateShareSkillWithTrade(actualSkillTrade, expectedSkillTrade);
        }

        [When(@"user  clicks on the eye icon to the right end of the first share skill listing")]
        public void WhenUserClicksOnTheEyeIconToTheRightEndOfTheFirstShareSkillListing()
        {
            manageListingRenderComponents.EyeIconRenderComponent();
        }

        [Then(@"Mars Portal should navigate to the service details page")]
        public void ThenMarsPortalShouldNavigateToTheServiceDetailsPage()
        {
            string actualUser = manageListingRenderComponents.GetUserDetail();
            string expectedUser = "Test100";
            manageListingAssertHelper.AssertViewShareSkillDetails(actualUser, expectedUser);
        }

        [When(@"user  clicks on the delete icon to the right end of the first share skill listing and does not accept the confirmation")]
        public void WhenUserClicksOnTheDeleteIconToTheRightEndOfTheFirstShareSkillListingAndDoesNotAcceptTheConfirmation()
        {
            manageListingRenderComponents.SelectShareSkill();
            addUpdateViewAndDeleteShareSkillListing.AddShareSkills(shareSkillDMList[0]);
            manageListingTitleName = manageListingRenderComponents.GetFirstManageListingsTitle();
            addUpdateViewAndDeleteShareSkillListing.DenyDeleteFirstServiceListing();
        }

        [Then(@"Mars Portal should not delete the selected share skill listing")]
        public void ThenMarsPortalShouldNotDeleteTheSelectedShareSkillListing()
        {
            manageListingAssertHelper.AssertDenyDeleteServiceListing(manageListingTitleName, shareSkillDMList[0].title);
        }

        [When(@"user  clicks on the active button of the first share skill listing")]
        public void WhenUserClicksOnTheActiveButtonOfTheFirstShareSkillListing()
        {
            manageListingRenderComponents.ToggleActiveStatusRenderComponent();
            actualMessage = manageListingRenderComponents.CapturePopupMessage();
        }

        [Then(@"Mars Portal should enable the status if it is already disabled or viceversa")]
        public void ThenMarsPortalShouldEnableTheStatusIfItIsAlreadyDisabledOrViceversa()
        {
            expectedMessage = "Service has been deactivated";
            string expectedMessage2 = "Service has been activated";
            manageListingAssertHelper.AssertToggleActiveStatus(actualMessage, expectedMessage, expectedMessage2);

        }


    }
}
