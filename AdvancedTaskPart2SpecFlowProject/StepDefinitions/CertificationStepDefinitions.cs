using AdvancedTaskPart2SpecFlowProject.AssertHelpers;
using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.Pages.ProfileNavigationMenuComponents;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskPart2SpecFlowProject.StepDefinitions
{
    [Binding]
    public class CertificationStepDefinitions : CommonDriver
    {
        public CertificationRenderComponents certificationRenderComponents;
        public CertificationAddAndDeleteComponent certificationAddAndDeleteComponent;
        public CertificationAssertHelper certificationAssertHelper;
        List<CertificationDM> certificationDMList;
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        public CertificationStepDefinitions()
        {
            certificationRenderComponents = new CertificationRenderComponents();
            certificationAddAndDeleteComponent = new CertificationAddAndDeleteComponent();
            certificationAssertHelper = new CertificationAssertHelper();
            certificationDMList = new List<CertificationDM>();
        }
        public void ReadJSONData(string testDataPath)
        {
            jsonReaderObj?.SetDataPath(testDataPath);
            certificationDMList = jsonReaderObj!.ReadCertificationJsonData();
        }

        [Given(@"user selects the certification tab")]
        public void GivenUserSelectsTheCertificationTab()
        {
            certificationRenderComponents.CertificationTabRenderComponent();
        }

        [Given(@"User reads certification test data from '([^']*)'")]
        public void GivenUserReadsCertificationTestDataFrom(string testDataPath)
        {
            ReadJSONData(testDataPath);
        }


        [When(@"user deletes all the certification records one by one")]
        public void WhenUserDeletesAllTheCertificationRecordsOneByOne()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
        }

        [Then(@"Mars portal should not have any certification records for the logged in account")]
        public void ThenMarsPortalShouldNotHaveAnyCertificationRecordsForTheLoggedInAccount()
        {
            int rowCount = certificationRenderComponents.GetCertificationRecordsCount();
            certificationAssertHelper.AssertDeleteAllCertificationRecords(rowCount);
        }

        [When(@"user enters valid data in all the required fields")]
        public void WhenUserEntersValidDataInAllTheRequiredFields()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[0]);
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[1]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = certificationDMList[1].certificateName + " has been added to your certification";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [Then(@"Mars portal should alert the user and save the new certification record")]
        public void ThenMarsPortalShouldAlertTheUserAndSaveTheNewCertificationRecord()
        {
            certificationAssertHelper.AssertAddNewCertification(actualMessage, expectedMessage);
        }

        [When(@"user does not enter data in any of the available certification fields")]
        public void WhenUserDoesNotEnterDataInAnyOfTheAvailableCertificationFields()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[2]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Please enter Certification Name, Certification From and Certification Year";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [Then(@"Mars portal should alert the user and should not save the new certification record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheNewCertificationRecord()
        {
            certificationAssertHelper.AssertAddNewCertificationWithInsufficientData(actualMessage, expectedMessage);
        }

        [When(@"user does not select any options from the year dropdown")]
        public void WhenUserDoesNotSelectAnyOptionsFromTheYearDropdown()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[3]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Please enter Certification Name, Certification From and Certification Year";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [When(@"user does not enter any data in both the certification Text Boxes")]
        public void WhenUserDoesNotEnterAnyDataInBothTheCertificationTextBoxes()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[4]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Please enter Certification Name, Certification From and Certification Year";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
        }

        [When(@"user adds an already existing certification record")]
        public void WhenUserAddsAnAlreadyExistingCertificationRecord()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[0]);
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[0]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = "This information is already exist.";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [When(@"user adds an education record with already existing data in Text Boxes and selecting different year from dropdown")]
        public void WhenUserAddsAnEducationRecordWithAlreadyExistingDataInTextBoxesAndSelectingDifferentYearFromDropdown()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[1]);
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[5]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = "Duplicated data";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [When(@"user adds an certification record with new data in Text Boxes and selecting already existing year from dropdown")]
        public void WhenUserAddsAnCertificationRecordWithNewDataInTextBoxesAndSelectingAlreadyExistingYearFromDropdown()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[1]);
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[6]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = certificationDMList[6].certificateName + " has been added to your certification";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [When(@"user adds a certification record with Special Characters and numbers in certification name TextBox")]
        public void WhenUserAddsACertificationRecordWithSpecialCharactersAndNumbersInCertificationNameTextBox()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[7]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = certificationDMList[7].certificateName + " has been added to your certification";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [When(@"user adds a certification record with very long data in CertifiedFrom TextBox")]
        public void WhenUserAddsACertificationRecordWithVeryLongDataInCertifiedFromTextBox()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[8]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = certificationDMList[8].certificateName + " has been added to your certification";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [When(@"user adds a certification record with only Spaces in TextBoxes")]
        public void WhenUserAddsACertificationRecordWithOnlySpacesInTextBoxes()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[9]);
            actualMessage = certificationRenderComponents!.CapturePopupMessage();
            expectedMessage = "has been added to your certification";
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

        [When(@"user cancels a certification record without adding")]
        public void WhenUserCancelsACertificationRecordWithoutAdding()
        {
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[0]);
            certificationAddAndDeleteComponent.SetCancelFlag(1);
            certificationAddAndDeleteComponent.AddCertification(certificationDMList[10]);

        }

        [Then(@"Mars portal should not save the cancelled certification record")]
        public void ThenMarsPortalShouldNotSaveTheCancelledCertificationRecord()
        {
            string lastCertificationeName = certificationRenderComponents.GetLastRecordCertificateName();
            certificationAssertHelper.assertCancelAddNewCerificationRecord(lastCertificationeName);
            certificationAddAndDeleteComponent.DeleteAllCertificationRecords();

        }

    }
}
