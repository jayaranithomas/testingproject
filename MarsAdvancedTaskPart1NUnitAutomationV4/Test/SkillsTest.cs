﻿using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.ReportClass;
using MarsAdvancedTaskPart1NUnitAutomation.Steps;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Test
{

    [TestFixture]
    public class SkillsTest : CommonDriver
    {

        List<SkillsDM> skillList;
        SkillSteps skillStepsObj;
        ProfileNavigationTabs profileNavigationTabsObj;
        public SkillsTest()
        {
            skillList = new List<SkillsDM>();
            skillStepsObj = new SkillSteps();
            profileNavigationTabsObj = new ProfileNavigationTabs();
            ReadJSON();
        }

        public void ReadJSON()
        {
            jsonObj.SetDataPath("skills");
            skillList = jsonObj.ReadSJsonData();
        }
        [SetUp]
        public void SetUp() 
        {
            profileNavigationTabsObj?.SelectSkillsTab();

        }

        [Test, Order(1), Description("This test deletes all Skill Records")]
        public void TestDeleteAllSkillRecords()
        {
            //ReadJSON();
            skillStepsObj.DeleteAllSkillRecords();

        }
        [Test, Order(2), Description("This test adds a new Skill Record")]
        public void TestCreateNewSkillRecord()
        {
            skillStepsObj.AddNewSkill(skillList[0]);

        }
        [Test, Order(3), Description("This test adds new Skill Record with NULL data in both fields")]
        public void TestCreateNewSkillRecordWithAllNullData()
        {
            skillStepsObj.AddNewSkillRecordWithInsufficientData(skillList[1]);
        }
        [Test, Order(4), Description("This test adds new Skill Record without selecting any level and providing valid data in skill text box")]
        public void TestCreateNewSkillRecordWithLevelNotSelected()
        {
            skillStepsObj.AddNewSkillRecordWithInsufficientData(skillList[2]);
        }
        [Test, Order(5), Description("This test adds new Skill Record without entering any skill in text box and selecting a valid level from dropdown")]
        public void TestCreateNewSkillRecordWithValidLevelAndEmptyTextBox()
        {

            skillStepsObj.AddNewSkillRecordWithInsufficientData(skillList[3]);

        }
        [Test, Order(6), Description("This test adds an already existing Skill Record")]
        public void TestCreateAlreadyExistingSkillRecord()
        {
            skillStepsObj.AddAlreadyExistingSkillRecord(skillList[0]);

        }
        [Test, Order(7), Description("This test adds a duplicate Skill with different level")]
        public void TestCreateDuplicateSkillWithDifferentLevel()
        {
            skillStepsObj.AddDuplicateSkillWithDifferentLevel(skillList[4]);

        }
        [Test, Order(8), Description("This test adds a new Skill Name with Special Characters and Numbers")]
        public void TestCreateSkillRecordWithSpecialCharactersAndNumbers()
        {
            skillStepsObj.AddNewSkill(skillList[5]);

        }
        [Test, Order(9), Description("This test adds a new Skill with more than 500 characters")]
        public void TestCreateSkillRecordWithlLongName()
        {
            skillStepsObj.AddNewSkill(skillList[6]);

        }
        [Test, Order(10), Description("This test adds a new Skill with Only Spaces")]
        public void TestCreateLanguageRecordWithOnlySpacesInSkillTextBox()
        {
            skillStepsObj.AddNewSkill(skillList[7]);

        }
        [Test, Order(11), Description("This test Cancels a Skill record before adding")]
        public void TestCancelAddSkillRecord()
        {
            skillStepsObj.CancelAddSkillRecord(skillList[8]);

        }
        [Test, Order(12), Description("This test updates an existing Skill Record with both fields edited")]
        public void TestUpdateSkillRecordWithBothFieldsEdited()
        {
            skillStepsObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[8]);

        }
        [Test, Order(13), Description("This test updates an existing Skill Record without editing any fields")]
        public void TestUpdateSkillRecordWithNoFieldsEdited()
        {
            skillStepsObj.UpdateExistingSkillRecordWithNoFieldsEdited();

        }
        [Test, Order(14), Description("This test updates existing Skill Record with NULL data in both fields")]
        public void TestUpdateSkillRecordWithAllNullData()
        {
            skillStepsObj.UpdateSkillRecordWithInsufficientData(skillList[1]);

        }
        [Test, Order(15), Description("This test updates existing Skill Record by deleting the skill in text box and not changing the level")]
        public void TestUpdateSkillRecordWithValidLevelAndEmptyTextBox()
        {
            skillStepsObj.UpdateSkillRecordWithInsufficientData(skillList[9]);

        }
        [Test, Order(16), Description("This test updates existing Skill Record without editing skill in text box and not selecting any level")]
        public void TestUpdateSkillRecordWithoutSelectingLevel()
        {
            skillStepsObj.UpdateSkillRecordWithInsufficientData(skillList[10]);

        }
        [Test, Order(17), Description("This test updates existing Skill Record by changing only the skill")]
        public void TestUpdateSkillRecordByChangingOnlySkill()
        {
            skillStepsObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[11]);

        }
        [Test, Order(18), Description("This test updates existing Skill Record by changing only level")]
        public void TestUpdateSkillRecordByChangingOnlyLevel()
        {
            skillStepsObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[12]);

        }
        [Test, Order(19), Description("This test updates existing Skill Record with an existing skill name with different level")]
        public void TestUpdateSkillRecordWithExistingSkillName()
        {
            skillStepsObj.UpdateExistingSkillRecordWithExistingSkillName(skillList[13], skillList[14]);

        }
        [Test, Order(20), Description("This test updates existing Skill Record with Special Characters and Numbers")]
        public void TestUpdateSkillRecordWithSpecialCharacters()
        {
            skillStepsObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[15]);

        }
        [Test, Order(21), Description("This test updates existing Skill Record with more than 500 characters")]
        public void TestUpdateLanguageRecordWithLongLanguageName()
        {
            skillStepsObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[16]);

        }
        [Test, Order(22), Description("This test updates existing Skill Record with only Spaces")]

        public void TestUpdateSkillRecordWithOnlySpacesInSkill()
        {
            skillStepsObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[17]);

        }
        [Test, Order(23), Description("This test Cancels a Skill record before updating")]
        public void TestCancelUpdateSkillRecord()
        {
            skillStepsObj.CancelUpdateSkillRecord(skillList[18]);

        }

    }
}
