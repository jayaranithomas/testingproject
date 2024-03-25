using OpenQA.Selenium;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using Microsoft.CodeAnalysis;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents
{

    public class LanguageRenderingComponent : CommonDriver
    {
        IWebElement? languageTextBox;
        IWebElement? chooseLevelDD;

        IWebElement? addButton;
        IWebElement? addNewButton;
        IWebElement? editButton;
        IWebElement? updateButton;
        IWebElement? cancelButton;
        IWebElement? deleteButton;
        IWebElement? messageBox;
        IWebElement? closeMessageIcon;
        IWebElement? languageNameField;
        string actualMessage = string.Empty;

        public void RenderAddComponents()
        {
            try
            {
                languageTextBox = driver.FindElement(By.Name("name"));
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
                languageTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                updateButton = driver.FindElement(By.XPath("//div[@data-tab='first']//input[@value='Update']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderDeleteComponents()
        {
            try
            {
                deleteButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();
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
                addNewButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[contains(text(),'Add New')]"));
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
                editButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//i[@class='outline write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement AddNewButtonLocator()
        {
            
            return addNewButton!;
        }
        public IWebElement EditButtonLocator()
        {
           
            return editButton!;
        }
       
        public string CapturePopupMessage()
        {

            Thread.Sleep(1000);
            try
            {
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
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

            closeMessageIcon?.Click();
            return actualMessage;
        }

        public string GetLastLanguageName()
        {
            try
            {
                languageNameField = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//td[1]"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            string languageName = languageNameField!.Text;
            return languageName;
        }
        public string GetFirstLanguageName()
        {
            try
            {
                languageNameField = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//td[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            string languageName = languageNameField!.Text;
            return languageName;
        }
       
        public IWebElement LanguageTBLocator()
        {

            return languageTextBox!;
        }
        public IWebElement LanguageLevelLocator()
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



    }
}