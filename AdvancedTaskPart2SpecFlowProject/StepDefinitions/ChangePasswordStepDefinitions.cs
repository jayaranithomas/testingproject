using AdvancedTaskPart2SpecFlowProject.Utilities;
using AdvancedTaskPart2SpecFlowProject.Pages.AccountMenuComponent;
using System;
using TechTalk.SpecFlow;
using RazorEngine;
using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.AssertHelpers;
using Newtonsoft.Json;

namespace AdvancedTaskPart2SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ChangePasswordStepDefinitions : CommonDriver
    {
        ChangePasswordRenderComponent? changePasswordRenderComponent;
        List<ChangePasswordDM> changePasswordDMList;
        ChangePasswordFeature? changePasswordFeature;
        ChangePasswordAssertHelper? changePasswordAssertHelper;
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;

        public ChangePasswordStepDefinitions()
        {
            changePasswordRenderComponent = new ChangePasswordRenderComponent();
            changePasswordDMList = new List<ChangePasswordDM>();
            changePasswordFeature = new ChangePasswordFeature();
            changePasswordAssertHelper = new ChangePasswordAssertHelper();
        }
        public void ReadJSONData(string path)
        {
            jsonReaderObj?.SetDataPath(path);
            changePasswordDMList = jsonReaderObj!.ReadPJsonData();
        }

        [Given(@"User logs into the Mars Portal Profile Page")]
        public void GivenUserLogsIntoTheMarsPortalProfilePage()
        {
            InitialSetUp(0);
        }

        [Given(@"User selects the Change Password Option")]
        public void GivenUserSelectsTheChangePasswordOption()
        {
            changePasswordRenderComponent?.UserNameMenuRenderComponent();
            changePasswordRenderComponent?.ChangePasswordOptionRenderComponent();
        }

        [Given(@"User reads test data from '([^']*)'")]
        public void GivenUserReadsDataTestDataFrom(string path)
        {
            ReadJSONData(path);        
        }

        [Then(@"Mars portal should alert the user and save the new password for the account")]
        public void ThenMarsPortalShouldAlertTheUserAndSaveTheNewPasswordForTheAccount()
        {
            changePasswordAssertHelper?.AssertPasswordChange(actualMessage, expectedMessage);
        }


        [Then(@"Mars portal should alert the user and should not change the account password")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotChangeTheAccountPassword()
        {
            changePasswordAssertHelper?.AssertPasswordNotChanged(actualMessage, expectedMessage);
        }


        [When(@"User enters valid credentials in all the three fields")]
        public void WhenUserEntersValidCredentialsInAllTheThreeFields()
        {
            changePasswordFeature?.ChangePassword(changePasswordDMList[0]);
            actualMessage = changePasswordRenderComponent!.CapturePopupMessage();
            expectedMessage = "Password Changed Successfully";
            Thread.Sleep(6000);
            changePasswordFeature?.ChangePasswordBack(changePasswordDMList[1]);
        }

        [When(@"User does not enter data in any of the three fields")]
        public void WhenUserDoesNotEnterDataInAnyOfTheThreeFields()
        {
            changePasswordFeature?.ChangePassword(changePasswordDMList[2]);
            actualMessage = changePasswordRenderComponent!.CapturePopupMessage();
            expectedMessage = "Please fill all the details before Submit";
        }

        [When(@"User enters incorrect data in current password field")]
        public void WhenUserEntersIncorrectDataInCurrentPasswordField()
        {
            changePasswordFeature?.ChangePassword(changePasswordDMList[3]);
            actualMessage = changePasswordRenderComponent!.CapturePopupMessage();
            expectedMessage = "Password Verification Failed";
        }

        [When(@"User enters different data in new and confirm password fields")]
        public void WhenUserEntersDifferentDataInNewAndConfirmPasswordFields()
        {
            changePasswordFeature?.ChangePassword(changePasswordDMList[4]);
            actualMessage = changePasswordRenderComponent!.CapturePopupMessage();
            expectedMessage = "Passwords does not match";
        }

        [When(@"User does not enter data in confirm password field")]
        public void WhenUserDoesNotEnterDataInConfirmPasswordField()
        {
            changePasswordFeature?.ChangePassword(changePasswordDMList[5]);
            actualMessage = changePasswordRenderComponent!.CapturePopupMessage();
            expectedMessage = "Please fill all the details before Submit";
        }


    }
}
