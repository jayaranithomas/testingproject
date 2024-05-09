using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents
{

    public class SkillsRenderingComponent : CommonDriver
    {
        IWebElement? skillTextBox;
        IWebElement? chooseLevelDD;

        IWebElement? addButton;
        IWebElement? updateButton;
        IWebElement? cancelButton;
        IWebElement? deleteButton;
        IWebElement? addNewButton;
        IWebElement? editButton;
        IWebElement? skillNameTextBox;
        IWebElement? messageBox;
        string actualMessage = string.Empty;
        string skillName = string.Empty;

        public void RenderAddComponents()
        {
            try
            {
                skillTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void RenderUpdateComponents()
        {
            try
            {
                skillTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                updateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Update']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderAddNewComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@data-tab='second']//div[contains(text(),'Add New')]", 8);
                addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[contains(text(),'Add New')]"));
                addNewButton?.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderEditComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']", 8);
                editButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']"));
                editButton?.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void RenderDeleteComponent()
        {
            try
            {
                deleteButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public IWebElement SkillsTBLocator()
        {

            return skillTextBox!;
        }
        public IWebElement SkillLevelLocator()
        {

            return chooseLevelDD!;
        }
        public IWebElement AddButtonLocator()
        {

            return addButton!;
        }
        public IWebElement CancelButtonLocator()
        {

            return cancelButton!;
        }
        public IWebElement UpdateButtonLocator()
        {

            return updateButton!;
        }
        public string CapturePopupMessage()
        {

            Thread.Sleep(1000);
            try
            {
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (messageBox != null)
            {
                actualMessage = messageBox.Text;
                Console.WriteLine(actualMessage);
            }

            return actualMessage;
        }
        //To get the last entered Language
        public string GetLastSkillName()
        {
            try
            {
                skillNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]//td[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (skillNameTextBox != null)
                skillName = skillNameTextBox.Text;

            return skillName;
        }
        //To get the first entered Language
        public string GetFirstSkillName()
        {

            try
            {
                skillNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//td[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (skillNameTextBox != null)
                skillName = skillNameTextBox.Text;

            return skillName;
        }
        public int GetSkillRecordsCount()
        {
            int rowCount = driver.FindElements(By.XPath("//div[@data-tab='second']//tbody")).Count;

            return rowCount;

        }


    }
}
