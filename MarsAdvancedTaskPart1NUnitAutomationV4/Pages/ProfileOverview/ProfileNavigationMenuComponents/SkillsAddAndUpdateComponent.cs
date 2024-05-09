using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents
{
    public class SkillsAddAndUpdateComponent : CommonDriver
    {
        int cancelFlag;
        SkillsRenderingComponent skillsRenderingComponent;
        public SkillsAddAndUpdateComponent()
        {
            skillsRenderingComponent = new SkillsRenderingComponent();
            cancelFlag = 0;
        }
        public void SetCancelFlag(int flag)
        {
            cancelFlag = flag;
        }


        public void AddSkill(SkillsDM skillDM)
        {
            skillsRenderingComponent.RenderAddNewComponent();
            skillsRenderingComponent.RenderAddComponents();

            if (!string.IsNullOrEmpty(skillDM.skill))
            {
                skillsRenderingComponent.SkillsTBLocator()?.Click();
                skillsRenderingComponent.SkillsTBLocator()?.SendKeys(skillDM.skill);
            }
            if (!string.IsNullOrEmpty(skillDM.level))
            {
                skillsRenderingComponent.SkillLevelLocator()?.Click();
                skillsRenderingComponent.SkillLevelLocator()?.SendKeys(skillDM.level);
            }

            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                skillsRenderingComponent.AddButtonLocator()?.Click();
            }
            else
            { cancelFlag = 0; skillsRenderingComponent.CancelButtonLocator()?.Click(); }
        }

        public void EditSkillRecord(SkillsDM skillDM)
        {
            skillsRenderingComponent.RenderEditComponent();
            skillsRenderingComponent.RenderUpdateComponents();

            if (!skillDM.skill.Equals("No Change"))
            {
                if (string.IsNullOrEmpty(skillDM.skill))
                {
                    var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                    actions.Click(skillsRenderingComponent.SkillsTBLocator());
                    actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                    actions.Perform();
                }
                else
                {
                    skillsRenderingComponent.SkillsTBLocator()?.Clear();
                    skillsRenderingComponent.SkillsTBLocator()?.SendKeys(skillDM.skill);
                }
            }
            if (!skillDM.level.Equals("No Change"))
            {
                skillsRenderingComponent.SkillLevelLocator()?.Click();
                if (!string.IsNullOrEmpty(skillDM.level))
                    skillsRenderingComponent.SkillLevelLocator()?.SendKeys(skillDM.level);

                else
                    skillsRenderingComponent.SkillLevelLocator()?.SendKeys("Skill Level");
                skillsRenderingComponent.SkillLevelLocator()?.Click();
            }


            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {

                skillsRenderingComponent.UpdateButtonLocator()?.Click();
            }
            else
            { cancelFlag = 0; skillsRenderingComponent.CancelButtonLocator()?.Click(); }

        }
        public void DeleteAllSkillRecords()
        {
            int rowCount = skillsRenderingComponent.GetSkillRecordsCount();

            for (int i = 1; i <= rowCount;)
            {
                skillsRenderingComponent.RenderDeleteComponent();
                rowCount--;
                Thread.Sleep(2000);
            }
        }
    }
}
