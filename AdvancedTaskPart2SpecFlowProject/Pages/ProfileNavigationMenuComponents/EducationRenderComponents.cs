using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ProfileNavigationMenuComponents
{
    public class EducationRenderComponents : CommonDriver
    {
        IWebElement? educationTab;
        IWebElement? deleteButton;
        IWebElement? addNewButton;
        IWebElement? collegeTextBox;
        IWebElement? chooseCountryDD;
        IWebElement? chooseTitleDD;
        IWebElement? degreeTextBox;
        IWebElement? chooseYearDD;
        IWebElement? addButton;
        IWebElement? cancelButton;
        IWebElement? messageBox;
        IWebElement? lastRecord;
        string actualMessage = string.Empty;
        string lastCollegeName = string.Empty;


        public void RenderAddComponents()
        {
            try
            {
                Wait.WaitToBeClickable("XPath", "//div[@data-tab='third']//div[contains(text(),'Add New')]", 5);

                addNewButton = driver.FindElement(By.XPath("//div[@data-tab='third']//div[contains(text(),'Add New')]"));
                addNewButton.Click();

                collegeTextBox = driver.FindElement(By.Name("instituteName"));
                chooseCountryDD = driver.FindElement(By.Name("country"));
                chooseTitleDD = driver.FindElement(By.Name("title"));
                degreeTextBox = driver.FindElement(By.Name("degree"));
                chooseYearDD = driver.FindElement(By.Name("yearOfGraduation"));
                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement CollegeTextBoxLocator()
        {

            return collegeTextBox!;
        }
        public IWebElement ChooseCountryDDLocator()
        {

            return chooseCountryDD!;
        }
        public IWebElement ChooseTitleDDLocator()
        {

            return chooseTitleDD!;
        }
        public IWebElement DegreeTextBoxLocator()
        {

            return degreeTextBox!;
        }
        public IWebElement ChooseYearDDLocator()
        {

            return chooseYearDD!;
        }
        public IWebElement AddButtonLocator()
        {

            return addButton!;
        }
        public IWebElement CancelButtonLocator()
        {

            return cancelButton!;
        }
        public string GetLastRecordCollegeName()
        {

            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@data-tab='third']//tbody[last()]/tr/td[2]", 2);
                lastRecord = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[last()]/tr/td[2]"));
                lastCollegeName = lastRecord.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return lastCollegeName;
        }
        public void EducationTabRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@data-tab='third']", 2);
                educationTab = driver.FindElement(By.XPath("//a[@data-tab='third']"));
                educationTab.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public int GetEducationRecordsCount()
        {
            Wait.WaitToBeVisible("XPath", "//div[@data-tab='third']//tr", 5);

            int rowCount = driver.FindElements(By.XPath("//div[@data-tab='third']//tbody")).Count;

            return rowCount;

        }
        public void RenderDeleteComponents()
        {
            try
            {
                deleteButton = driver.FindElement(By.XPath("//div[@data-tab='third']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

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
