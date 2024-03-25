using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
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

    public class LanguageSteps : CommonDriver
    {
        string actualMessage;
        string expectedMessage;
        string languageName;
        LanguageAddAndUpdateComponent languageAddAndUpdateComponent;
        LanguageRenderingComponent languageRenderingComponent;
        LanguageAssertHelper languageAssertHelper;
        int cancelFlag;

        public LanguageSteps()
        {
            actualMessage = string.Empty;
            expectedMessage = string.Empty;
            languageName = string.Empty;
            cancelFlag = 0;
            languageAddAndUpdateComponent = new LanguageAddAndUpdateComponent();
            languageAssertHelper = new LanguageAssertHelper();
            languageRenderingComponent = new LanguageRenderingComponent();

        }
        public void DeleteAllLanguageRecords()
        {
            int rowCount = languageAddAndUpdateComponent.GetLanguageRecordsCount();
            for (int i = 1; i <= rowCount;)
            {
                languageName = languageRenderingComponent.GetLastLanguageName();
                languageRenderingComponent.RenderDeleteComponents();
                rowCount--;

                actualMessage = languageRenderingComponent.CapturePopupMessage();

                if (!string.IsNullOrEmpty(languageName))
                    expectedMessage = languageName + " has been deleted from your languages";
                else
                    expectedMessage = "has been deleted from your languages";

                languageAssertHelper.AssertDeleteAllLanguageRecords(expectedMessage, actualMessage);
                Thread.Sleep(2000);

            }
        }
        public void AddNewLanguage(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.AddLanguage(languageDM);
            actualMessage = languageRenderingComponent.CapturePopupMessage();
            languageName = languageRenderingComponent.GetLastLanguageName();

            if (!string.IsNullOrEmpty(languageName))
                expectedMessage = languageName + " has been added to your languages";
            else
                expectedMessage = "has been added to your languages";
            languageAssertHelper.AssertAddNewLanguage(expectedMessage, actualMessage);

        }       

        public void AddNewLanguageRecordWithInsufficientData(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.AddLanguage(languageDM);
            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "Please enter language and level";
            languageAssertHelper.AssertNewLanguageNotAddedSuccessfully(expectedMessage, actualMessage);
        }

        public void AddAlreadyExistingLanguageRecord(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.AddLanguage(languageDM);
            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "This language is already exist in your language list.";
            languageAssertHelper.AssertNewLanguageNotAddedSuccessfully(expectedMessage, actualMessage);
        }

        public void AddDuplicateLanguageWithDifferentLevel(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.AddLanguage(languageDM);
            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "Duplicated data";
            languageAssertHelper.AssertNewLanguageNotAddedSuccessfully(expectedMessage, actualMessage);
        }
        public void AddFifthLanguage()
        {
            int rowcount = languageAddAndUpdateComponent.GetLanguageRecordsCount();

            if (rowcount == 4)
            {
                try
                {
                    languageRenderingComponent.RenderAddNewComponent();
                }
                catch (Exception ex)
                {
                    Assert.Pass(ex.Message);
                }
            }

        }
        public void CancelAddLanguageRecord(LanguageDM languageDM)
        {
            cancelFlag = 1;

            int rowcount = languageAddAndUpdateComponent.GetLanguageRecordsCount();

            if (rowcount == 4)
            {
                languageRenderingComponent.RenderDeleteComponents();
            }

            languageAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            languageAddAndUpdateComponent.AddLanguage(languageDM);
            cancelFlag = 0;

            languageName = languageRenderingComponent.GetLastLanguageName();

            if (!languageName.Equals("Urdu"))
            {
                Console.WriteLine("Language record cancelled before adding");
                languageAssertHelper.AssertCancelLanguage(languageName,"Urdu");

            }
        }
        public void UpdateExistingLanguageRecordWithFieldsEdited(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.EditLanguageRecord(languageDM);

            actualMessage = languageRenderingComponent.CapturePopupMessage();
            languageName = languageRenderingComponent.GetFirstLanguageName();

            if (!string.IsNullOrEmpty(languageName))
                expectedMessage = languageName + " has been updated to your languages";
            else
                expectedMessage = "has been updated to your languages";
            languageAssertHelper.AssertUpdateLanguage(expectedMessage, actualMessage);
        }
        public void UpdateExistingLanguageRecordWithNoFieldsEdited()
        {
            languageRenderingComponent.RenderEditComponent();
            languageRenderingComponent.EditButtonLocator()?.Click();

            languageRenderingComponent.RenderUpdateComponents();
            languageRenderingComponent.UpdateButtonLocator()?.Click();

            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "This language is already added to your language list.";
            languageAssertHelper.AssertExistingLanguageNotUpdatedSuccessfully(expectedMessage, actualMessage);

        }
        public void UpdateLanguageRecordWithInsufficientData(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.EditLanguageRecord(languageDM);

            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "Please enter language and level";
            languageAssertHelper.AssertExistingLanguageNotUpdatedSuccessfully(expectedMessage, actualMessage);
        }
        public void UpdateExistingLanguageRecordWithExistingLanguageName(LanguageDM languageDM1, LanguageDM languageDM2)
        {
            int rowcount = languageAddAndUpdateComponent.GetLanguageRecordsCount();

            if (rowcount == 4)
            {
                languageRenderingComponent.RenderDeleteComponents();
            }
            languageAddAndUpdateComponent.AddLanguage(languageDM1);
            Thread.Sleep(3000);
            UpdateExistingLanguageRecordWithFieldsEdited(languageDM2);

        }
        public void CancelUpdateLanguageRecord(LanguageDM languageDM)
        {
            cancelFlag = 1;

            languageAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            languageAddAndUpdateComponent.EditLanguageRecord(languageDM);
            cancelFlag = 0;

            languageName = languageRenderingComponent.GetLastLanguageName();

            if (!languageName.Equals("Japanese"))
            {
                Console.WriteLine("Language record cancelled before updating");
                languageAssertHelper.AssertCancelLanguage(languageName, "Japanese");

            }

        }

    }
}
