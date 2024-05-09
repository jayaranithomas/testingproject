using AdvancedTaskPart2SpecFlowProject.Pages.ProfileNavigationMenuComponents;
using AdvancedTaskPart2SpecFlowProject.AssertHelpers;
using System;
using TechTalk.SpecFlow;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.Pages.AccountMenuComponent;

namespace AdvancedTaskPart2SpecFlowProject.StepDefinitions
{
    [Binding]
    public class EducationStepDefinitions : CommonDriver
    {
        public EducationRenderComponents educationRenderComponents;
        public EducationAddAndDeleteComponent educationAddAndDeleteComponent;
        public EducationAssertHelper educationAssertHelper;
        List<EducationDM> educationDMList;
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        public EducationStepDefinitions()
        {
            educationRenderComponents = new EducationRenderComponents();
            educationAddAndDeleteComponent = new EducationAddAndDeleteComponent();
            educationAssertHelper = new EducationAssertHelper();
            educationDMList = new List<EducationDM>();
        }
        public void ReadJSONData(string testDataPath)
        {
            jsonReaderObj?.SetDataPath(testDataPath);
            educationDMList = jsonReaderObj!.ReadEJsonData();
        }

        [Given(@"user logs into the Mars Portal Profile Page")]
        public void GivenUserLogsIntoTheMarsPortalProfilePage()
        {
            InitialSetUp(1);
        }

        [Given(@"user selects the Education tab")]
        public void GivenUserSelectsTheEducationTab()
        {
            educationRenderComponents.EducationTabRenderComponent();
        }

        [Given(@"User reads education test data from '([^']*)'")]
        public void GivenUserReadsEducationTestDataFrom(string testDataPath)
        {
            ReadJSONData(testDataPath);
        }

        [When(@"user deletes all the education records one by one")]
        public void WhenUserDeletesAllTheEducationRecordsOneByOne()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
        }

        [Then(@"Mars portal should not have any Education records for the logged in account")]
        public void ThenMarsPortalShouldNotHaveAnyEducationRecordsForTheLoggedInAccount()
        {
            int rowCount = educationRenderComponents.GetEducationRecordsCount();
            educationAssertHelper.AssertDeleteAllEducationRecords(rowCount);
        }

        [When(@"user enters valid data in all the fields")]
        public void WhenUserEntersValidDataInAllTheFields()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[0]);
            educationAddAndDeleteComponent.AddEducation(educationDMList[1]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Education has been added";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [Then(@"Mars portal should alert the user and save the new education record")]
        public void ThenMarsPortalShouldAlertTheUserAndSaveTheNewEducationRecord()
        {
            educationAssertHelper.assertAddNewEducation(actualMessage, expectedMessage);
        }

        [When(@"user does not enter data in any of the available fields")]
        public void WhenUserDoesNotEnterDataInAnyOfTheAvailableFields()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[2]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Please enter all the fields";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [Then(@"Mars portal should alert the user and should not save the new education record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheNewEducationRecord()
        {
            educationAssertHelper.assertAddNewEducationRecordWithInsufficientData(actualMessage, expectedMessage);
        }

        [When(@"user does not select any options from the dropdowns")]
        public void WhenUserDoesNotSelectAnyOptionsFromTheDropdowns()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[3]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Please enter all the fields";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user does not enter any data in both the Text Boxes")]
        public void WhenUserDoesNotEnterAnyDataInBothTheTextBoxes()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[4]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Please enter all the fields";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user adds an already existing education record")]
        public void WhenUserAddsAnAlreadyExistingEducationRecord()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[0]);
            educationAddAndDeleteComponent.AddEducation(educationDMList[0]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "This information is already exist.";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user adds an education record with already existing data in Text Boxes and selecting different dropdown options")]
        public void WhenUserAddsAnEducationRecordWithAlreadyExistingDataInTextBoxesAndSelectingDifferentDropdownOptions()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[0]);
            educationAddAndDeleteComponent.AddEducation(educationDMList[5]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Education has been added";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user adds an education record with new data in Text Boxes and selecting already existing dropdowns")]
        public void WhenUserAddsAnEducationRecordWithNewDataInTextBoxesAndSelectingAlreadyExistingDropdowns()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[5]);
            educationAddAndDeleteComponent.AddEducation(educationDMList[6]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Education has been added";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user adds an education record with Special Characters and numbers in College TextBox")]
        public void WhenUserAddsAnEducationRecordWithSpecialCharactersAndNumbersInCollegeTextBox()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[7]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Education has been added";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user adds an education record with very long data in Degree TextBox")]
        public void WhenUserAddsAnEducationRecordWithVeryLongDataInDegreeTextBox()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[8]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Education has been added";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user adds an education record with only Spaces in TextBoxes")]
        public void WhenUserAddsAnEducationRecordWithOnlySpacesInTextBoxes()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[9]);
            actualMessage = educationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Education information was invalid";
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

        [When(@"user cancels an Education record without adding")]
        public void WhenUserCancelsAnEducationRecordWithoutAdding()
        {
            educationAddAndDeleteComponent.DeleteAllEducationRecords();
            educationAddAndDeleteComponent.AddEducation(educationDMList[0]);
            educationAddAndDeleteComponent.SetCancelFlag(1);
            educationAddAndDeleteComponent.AddEducation(educationDMList[10]);
        }

        [Then(@"Mars portal should not save the cancelled education record")]
        public void ThenMarsPortalShouldNotSaveTheCancelledEducationRecord()
        {
            string lastCollegeName = educationRenderComponents.GetLastRecordCollegeName();
            educationAssertHelper.assertCancelAddNewEducationRecord(lastCollegeName);
            educationAddAndDeleteComponent.DeleteAllEducationRecords();

        }

    }
}
