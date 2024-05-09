using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ProfileNavigationMenuComponents
{
    public class CertificationRenderComponents : CommonDriver
    {
        IWebElement? certificationTab;
        IWebElement? addNewButton;
        IWebElement? certificationTextBox;
        IWebElement? certifiedFromTextBox;
        IWebElement? chooseYearDD;
        IWebElement? addButton;
        IWebElement? cancelButton;
        IWebElement? deleteButton;
        IWebElement? messageBox;
        IWebElement? lastRecord;
        string lastCertificateName = string.Empty;
        string actualMessage = string.Empty;

        public void CertificationTabRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@data-tab='fourth']", 5);
                certificationTab = driver.FindElement(By.XPath("//a[@data-tab='fourth']"));
                certificationTab.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderAddComponents()
        {
            try
            {
                Wait.WaitToBeClickable("XPath", "//div[@data-tab='fourth']//div[contains(text(),'Add New')]", 5);

                addNewButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//div[contains(text(),'Add New')]"));
                addNewButton.Click();

                certificationTextBox = driver.FindElement(By.Name("certificationName"));
                certifiedFromTextBox = driver.FindElement(By.Name("certificationFrom"));
                chooseYearDD = driver.FindElement(By.Name("certificationYear"));
                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement CertificationTextBoxLocator()
        {

            return certificationTextBox!;
        }
        public IWebElement CertifiedFromTextBoxLocator()
        {

            return certifiedFromTextBox!;
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
        public int GetCertificationRecordsCount()
        {
            Wait.WaitToBeVisible("XPath", "//div[@data-tab='fourth']//tr", 5);

            int rowCount = driver.FindElements(By.XPath("//div[@data-tab='fourth']//tbody")).Count;

            return rowCount;

        }
        public void RenderDeleteComponents()
        {
            try
            {
                deleteButton = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public string GetLastRecordCertificateName()
        {

            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@data-tab='fourth']//tbody", 5);
                lastRecord = driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[last()]/tr/td[1]"));
                lastCertificateName = lastRecord.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return lastCertificateName;
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
