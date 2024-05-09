using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class LanguageSteps
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
        public void DeleteLanguageRecords()
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            int rowCount = languageRenderingComponent.GetLanguageRecordsCount();
            languageAssertHelper.AssertDeleteAllLanguageRecords(rowCount);
        }
        public void AddNewLanguage(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
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
            languageAddAndUpdateComponent.CheckAndMakeSpaceAvailablity();
            languageAddAndUpdateComponent.AddLanguage(languageDM);
            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "Please enter language and level";
            languageAssertHelper.AssertNewLanguageNotAddedSuccessfully(expectedMessage, actualMessage);
        }

        public void AddAlreadyExistingLanguageRecord(LanguageDM languageDM)
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM);
            languageAddAndUpdateComponent.AddLanguage(languageDM);
            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "This language is already exist in your language list.";
            languageAssertHelper.AssertNewLanguageNotAddedSuccessfully(expectedMessage, actualMessage);
        }

        public void AddDuplicateLanguageWithDifferentLevel(LanguageDM languageDM1, LanguageDM languageDM2)
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM1);
            languageAddAndUpdateComponent.AddLanguage(languageDM2);
            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "Duplicated data";
            languageAssertHelper.AssertNewLanguageNotAddedSuccessfully(expectedMessage, actualMessage);
        }
        public void AddFifthLanguage(LanguageDM languageDM1, LanguageDM languageDM2, LanguageDM languageDM3, LanguageDM languageDM4)
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM1);
            languageAddAndUpdateComponent.AddLanguage(languageDM2);
            languageAddAndUpdateComponent.AddLanguage(languageDM3);
            languageAddAndUpdateComponent.AddLanguage(languageDM4);
            Thread.Sleep(2000);
            languageRenderingComponent.AddNewButtonVisibility();
            if (languageRenderingComponent.GetAddNewButtonCount()==0)
             languageAssertHelper.AssertAddFifthLanguage();
            
        }
        public void CancelAddLanguageRecord(LanguageDM languageDM1, LanguageDM languageDM2)
        {
            cancelFlag = 1;
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM1);

            languageAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            languageAddAndUpdateComponent.AddLanguage(languageDM2);
            cancelFlag = 0;

            languageName = languageRenderingComponent.GetLastLanguageName();

            if (!languageName.Equals("Urdu"))
            {
                Console.WriteLine("Language record cancelled before adding");
                languageAssertHelper.AssertCancelLanguage(languageName, "Urdu");

            }
        }
        public void UpdateExistingLanguageRecordWithFieldsEdited(LanguageDM languageDM1, LanguageDM languageDM2)
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM1);

            languageAddAndUpdateComponent.EditLanguageRecord(languageDM2);

            actualMessage = languageRenderingComponent.CapturePopupMessage();
            languageName = languageRenderingComponent.GetFirstLanguageName();

            if (!string.IsNullOrEmpty(languageName))
                expectedMessage = languageName + " has been updated to your languages";
            else
                expectedMessage = "has been updated to your languages";
            languageAssertHelper.AssertUpdateLanguage(expectedMessage, actualMessage);
        }
        public void UpdateExistingLanguageRecordWithNoFieldsEdited(LanguageDM languageDM1)
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM1);


            languageRenderingComponent.RenderEditComponent();
            languageRenderingComponent.EditButtonLocator()?.Click();

            languageRenderingComponent.RenderUpdateComponents();
            languageRenderingComponent.UpdateButtonLocator()?.Click();

            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "This language is already added to your language list.";
            languageAssertHelper.AssertExistingLanguageNotUpdatedSuccessfully(expectedMessage, actualMessage);

        }
        public void UpdateLanguageRecordWithInsufficientData(LanguageDM languageDM1, LanguageDM languageDM2)
        {
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM1);
            languageAddAndUpdateComponent.EditLanguageRecord(languageDM2);

            actualMessage = languageRenderingComponent.CapturePopupMessage();
            expectedMessage = "Please enter language and level";
            languageAssertHelper.AssertExistingLanguageNotUpdatedSuccessfully(expectedMessage, actualMessage);
        }

        public void CancelUpdateLanguageRecord(LanguageDM languageDM1, LanguageDM languageDM2)
        {
            cancelFlag = 1;
            languageAddAndUpdateComponent.DeleteAllLanguageRecords();
            languageAddAndUpdateComponent.AddLanguage(languageDM1);

            languageAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            languageAddAndUpdateComponent.EditLanguageRecord(languageDM2);
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
