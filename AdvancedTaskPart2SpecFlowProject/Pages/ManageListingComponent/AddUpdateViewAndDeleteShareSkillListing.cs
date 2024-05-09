using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ManageListingComponent
{
    public class AddUpdateViewAndDeleteShareSkillListing : CommonDriver
    {
        public ManageListingRenderComponents manageListingRenderComponents;
        string titleText = string.Empty;
        string descriptionText = string.Empty;
        int count;
        public AddUpdateViewAndDeleteShareSkillListing()
        {
            manageListingRenderComponents = new ManageListingRenderComponents();
        }
        public void AddShareSkills(ShareSkillDM shareSkillsDM)
        {
            manageListingRenderComponents.RenderShareSkillComponents();

            if (!string.IsNullOrEmpty(shareSkillsDM.title))
                manageListingRenderComponents.TitleLocator()?.SendKeys(shareSkillsDM.title);

            if (!string.IsNullOrEmpty(shareSkillsDM.description))
                manageListingRenderComponents.DescriptionLocator()?.SendKeys(shareSkillsDM.description);

            if (!string.IsNullOrEmpty(shareSkillsDM.category))
            {
                manageListingRenderComponents.CategoryLocator()?.SendKeys(shareSkillsDM.category);
                manageListingRenderComponents.RenderSubcategoryComponent();
                if (!string.IsNullOrEmpty(shareSkillsDM.subcategory))
                    manageListingRenderComponents.SubCategoryLocator()?.SendKeys(shareSkillsDM.subcategory);
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.tag))
            {
                manageListingRenderComponents.TagLocator(0).SendKeys(shareSkillsDM.tag);
                manageListingRenderComponents.TagLocator(0).SendKeys(Keys.Enter);
            }

            if (shareSkillsDM.skilltrade.Equals("true"))
            {
                manageListingRenderComponents.SkillTradeTLocator()?.Click();
                manageListingRenderComponents.TagLocator(1).SendKeys(shareSkillsDM.skillexchange);
                manageListingRenderComponents.TagLocator(1).SendKeys(Keys.Enter);
            }
            else
            {
                manageListingRenderComponents.SkillTradeFLocator()?.Click();
                manageListingRenderComponents.RenderCreditComponent();
                manageListingRenderComponents.CreditLocator()?.SendKeys(shareSkillsDM.credit);
            }



            if (!string.IsNullOrEmpty(manageListingRenderComponents.TitleLocator()?.GetAttribute("value")))
                titleText = manageListingRenderComponents.TitleLocator().GetAttribute("value");

            if (!string.IsNullOrEmpty(manageListingRenderComponents.DescriptionLocator()?.Text))
                descriptionText = manageListingRenderComponents.DescriptionLocator().Text;

            manageListingRenderComponents.SaveButtonLocator()?.Click();

        }
        public void UpdateShareSkills(ShareSkillDM shareSkillsDM)
        {
            manageListingRenderComponents.RenderShareSkillComponents();

            if (!string.IsNullOrEmpty(shareSkillsDM.title))
            {
                manageListingRenderComponents.TitleLocator()?.Clear();
                manageListingRenderComponents.TitleLocator()?.SendKeys(shareSkillsDM.title);
            }
            else
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                actions.Click(manageListingRenderComponents.TitleLocator());
                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                actions.Perform();
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.description))
            {
                manageListingRenderComponents.DescriptionLocator()?.Clear();
                manageListingRenderComponents.DescriptionLocator()?.SendKeys(shareSkillsDM.description);
            }
            else
            {
                var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                actions.Click(manageListingRenderComponents.DescriptionLocator());
                actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                actions.Perform();
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.category))
            {
                manageListingRenderComponents.CategoryLocator()?.SendKeys(shareSkillsDM.category);
                manageListingRenderComponents.RenderSubcategoryComponent();
                if (!string.IsNullOrEmpty(shareSkillsDM.subcategory))
                    manageListingRenderComponents.SubCategoryLocator()?.SendKeys(shareSkillsDM.subcategory);
            }


            if (!string.IsNullOrEmpty(shareSkillsDM.tag))
            {
                manageListingRenderComponents.TagLocator(0).SendKeys(shareSkillsDM.tag);
                manageListingRenderComponents.TagLocator(0).SendKeys(Keys.Enter);
            }

            if (shareSkillsDM.servicetype.Equals("1"))
            {
                manageListingRenderComponents.ServiceType1Locator()?.Click();
            }
            else if (shareSkillsDM.servicetype.Equals("0"))
            {
                manageListingRenderComponents.ServiceType0Locator()?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.locationtype))
            {
                manageListingRenderComponents.LocationTypeLocator()?.SendKeys(shareSkillsDM.locationtype);
                manageListingRenderComponents.LocationTypeLocator()?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.startdate))
            {
                manageListingRenderComponents.StartDateLocator()?.SendKeys(shareSkillsDM.startdate);
            }

            if (shareSkillsDM.skilltrade.Equals("true"))
            {
                manageListingRenderComponents.SkillTradeTLocator()?.Click();
                manageListingRenderComponents.TagLocator(1).SendKeys(shareSkillsDM.skillexchange);
                manageListingRenderComponents.TagLocator(1).SendKeys(Keys.Enter);
            }
            else
            {
                manageListingRenderComponents.SkillTradeFLocator()?.Click();
                manageListingRenderComponents.RenderCreditComponent();
                manageListingRenderComponents.CreditLocator()?.SendKeys(shareSkillsDM.credit);
            }


            if (!string.IsNullOrEmpty(manageListingRenderComponents.TitleLocator()?.GetAttribute("value")))
                titleText = manageListingRenderComponents.TitleLocator().GetAttribute("value");

            if (!string.IsNullOrEmpty(manageListingRenderComponents.DescriptionLocator()?.Text))
                descriptionText = manageListingRenderComponents.DescriptionLocator().Text;

            manageListingRenderComponents.SaveButtonLocator()?.Click();

        }

        public string GetTitle()
        {
            return titleText;
        }
        public string GetDescription()
        {
            return descriptionText;
        }
        public void UpdateShareSkillWithoutEditing()
        {
            manageListingRenderComponents.RenderShareSkillComponents();
            manageListingRenderComponents.SaveButtonLocator()?.Click();
        }
        public void DeleteFirstServiceListing()
        {
            IList<IWebElement> removeList = manageListingRenderComponents.RemoveRenderComponents();
            count = removeList.Count;
            if (count >= 1)
            {
                removeList[0].Click();
                manageListingRenderComponents.DeleteConfirmationRenderComponent();
                manageListingRenderComponents.YesButtonLocator()?.Click();
            }
        }
        public void DenyDeleteFirstServiceListing()
        {
            IList<IWebElement> removeList = manageListingRenderComponents.RemoveRenderComponents();
            count = removeList.Count;
            if (count >= 1)
            {
                removeList[0].Click();
                manageListingRenderComponents.DeleteConfirmationRenderComponent();
                manageListingRenderComponents.NoButtonLocator()?.Click();
            }
        }


        public void DeleteAllTags()
        {
            IList<IWebElement> tagList = manageListingRenderComponents.TagRemoveLocator();
            foreach (IWebElement removeTagIcon in tagList)
            {
                removeTagIcon.Click();
                Thread.Sleep(2000);
            }
        }
    }
}
