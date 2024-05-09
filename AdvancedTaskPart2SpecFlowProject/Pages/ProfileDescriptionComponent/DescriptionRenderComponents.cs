using AdvancedTaskPart2SpecFlowProject.Pages.ManageListingComponent;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ProfileDescriptionComponent
{
    public class DescriptionRenderComponents : CommonDriver
    {
        IWebElement? editButton;
        IWebElement? saveButton;
        IWebElement? descriptionTB;
        IWebElement? messageBox;
        string actualMessage = string.Empty;
        int descriptionLength = 0;
        public void SelectEditDescriptionRenderComponents()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//h3[contains(text(),'Description')]//i", 15);
                editButton = driver.FindElement(By.XPath("//h3[contains(text(),'Description')]//i"));
                editButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AddAndSaveRenderComponents()
        {
            try
            {
                descriptionTB = driver.FindElement(By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']"));
                saveButton = driver.FindElement(By.XPath("//div[@class='ui twelve wide column']//button[@class='ui teal button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public int GetDescriptionLengthRenderComponents()
        {
            try
            {
                IWebElement? description = driver.FindElement(By.XPath("//span[@style='padding-top: 1em;']"));
                descriptionLength = description.Text.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return descriptionLength;
        }
        public void ClearTextBox()
        {
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.Click(descriptionTB);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
            actions.Perform();

        }
        public IWebElement DescriptionTextBoxLocator()
        {

            return descriptionTB!;
        }

        public IWebElement SaveButtonLocator()
        {

            return saveButton!;
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

            return actualMessage!;
        }


    }
}
