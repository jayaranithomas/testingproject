using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class SkillSteps : CommonDriver
    {
        string actualMessage;
        string expectedMessage;
        string skillName;
        int cancelFlag;
        SkillsAddAndUpdateComponent skillsAddAndUpdateComponent;
        SkillsRenderingComponent skillsRenderingComponent;
        SkillsAssertHelper skillsAssertHelper;

        public SkillSteps()
        {
            actualMessage = string.Empty;
            expectedMessage = string.Empty;
            skillName = string.Empty;
            cancelFlag = 0;
            skillsAddAndUpdateComponent = new SkillsAddAndUpdateComponent();
            skillsRenderingComponent = new SkillsRenderingComponent();
            skillsAssertHelper = new SkillsAssertHelper();
        }

        public void DeleteSkillRecords()
        {
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            int rowCount = skillsRenderingComponent.GetSkillRecordsCount();
            skillsAssertHelper.AssertDeleteAllSkillRecords(rowCount);

        }
        public void AddNewSkill(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            actualMessage = skillsRenderingComponent.CapturePopupMessage();
            skillName = skillsRenderingComponent.GetLastSkillName();

            if (!string.IsNullOrEmpty(skillName))
                expectedMessage = skillName + " has been added to your skills";
            else
                expectedMessage = "has been added to your skills";
            skillsAssertHelper.AssertAddNewSkill(expectedMessage, actualMessage);

        }
        public void AddNewSkillRecordWithInsufficientData(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            actualMessage = skillsRenderingComponent.CapturePopupMessage();
            expectedMessage = "Please enter skill and experience level";

            skillsAssertHelper.AssertNewSkillNotAddedSuccessfully(expectedMessage, actualMessage);
        }
        public void AddAlreadyExistingSkillRecord(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM);
            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            actualMessage = skillsRenderingComponent.CapturePopupMessage();
            expectedMessage = "This skill is already exist in your skill list.";

            skillsAssertHelper.AssertNewSkillNotAddedSuccessfully(expectedMessage, actualMessage);

        }
        public void AddDuplicateSkillWithDifferentLevel(SkillsDM skillsDM1, SkillsDM skillsDM2)
        {
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM1);
            skillsAddAndUpdateComponent.AddSkill(skillsDM2);

            actualMessage = skillsRenderingComponent.CapturePopupMessage();
            expectedMessage = "Duplicated data";

            skillsAssertHelper.AssertNewSkillNotAddedSuccessfully(expectedMessage, actualMessage);

        }
        public void CancelAddSkillRecord(SkillsDM skillsDM1, SkillsDM skillsDM2)
        {
            cancelFlag = 1;
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM1);
            skillsAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);
            skillsAddAndUpdateComponent.AddSkill(skillsDM2);
            cancelFlag = 0;

            skillName = skillsRenderingComponent.GetLastSkillName();

            if (!skillName.Equals("Testing"))
            {
                Console.WriteLine("Skill record cancelled before adding");
                skillsAssertHelper.AssertCancelSkill(skillName, "Testing");

            }
        }
        public void UpdateExistingSkillRecordWithFieldsEdited(SkillsDM skillsDM1, SkillsDM skillsDM2)
        {
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM1);

            skillsAddAndUpdateComponent.EditSkillRecord(skillsDM2);

            actualMessage = skillsRenderingComponent.CapturePopupMessage();
            skillName = skillsRenderingComponent.GetFirstSkillName();
            if (!string.IsNullOrEmpty(skillName))
                expectedMessage = skillName + " has been updated to your skills";
            else
                expectedMessage = "has been updated to your skills";

            skillsAssertHelper.AssertUpdateSkill(expectedMessage, actualMessage);
        }
        public void UpdateExistingSkillRecordWithNoFieldsEdited(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            skillsRenderingComponent.RenderEditComponent();

            skillsRenderingComponent.RenderUpdateComponents();
            skillsRenderingComponent.UpdateButtonLocator()?.Click();

            actualMessage = skillsRenderingComponent.CapturePopupMessage();

            expectedMessage = "This skill is already added to your skill list.";

            skillsAssertHelper.AssertExistingSkillNotUpdatedSuccessfully(expectedMessage, actualMessage);
        }
        public void UpdateSkillRecordWithInsufficientData(SkillsDM skillsDM1, SkillsDM skillsDM2)
        {
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM1);

            skillsAddAndUpdateComponent.EditSkillRecord(skillsDM2);

            actualMessage = skillsRenderingComponent.CapturePopupMessage();
            expectedMessage = "Please enter skill and experience level";

            skillsAssertHelper.AssertExistingSkillNotUpdatedSuccessfully(expectedMessage, actualMessage);
        }
        public void CancelUpdateSkillRecord(SkillsDM skillsDM1, SkillsDM skillsDM2)
        {
            cancelFlag = 1;
            skillsAddAndUpdateComponent.DeleteAllSkillRecords();
            skillsAddAndUpdateComponent.AddSkill(skillsDM1);

            skillsAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            skillsAddAndUpdateComponent.EditSkillRecord(skillsDM2);
            cancelFlag = 0;


            skillName = skillsRenderingComponent.GetLastSkillName();

            if (!skillName.Equals("Painting"))
            {
                Console.WriteLine("Skill record cancelled before Updating");
                skillsAssertHelper.AssertCancelSkill(skillName, "Painting");

            }
        }
    }
}
