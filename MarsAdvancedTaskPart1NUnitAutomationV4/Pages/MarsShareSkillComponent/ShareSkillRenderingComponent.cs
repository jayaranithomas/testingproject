using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsShareSkillComponent
{

    public class ShareSkillRenderingComponent : CommonDriver
    {
        IWebElement? title;
        IWebElement? description;
        IWebElement? category;
        IWebElement? subcategory;
        IList<IWebElement>? tagList;
        IList<IWebElement>? tagRemoveList;
        IWebElement? servicetype0;
        IWebElement? servicetype1;
        IWebElement? locationtype;
        IWebElement? startdate;
        IWebElement? enddate;
        IWebElement? skilltradeT;
        IWebElement? skilltradeF;
        IWebElement? credit;
        IWebElement? worksamples;
        IWebElement? activeT;
        IWebElement? activeF;
        IWebElement? shareSkillButton;
        IWebElement? saveButton;
        IWebElement? cancelButton;
        IWebElement? messageBox;
        IWebElement? errorMessage;
        string actualMessage = string.Empty;
        string errorMessageString = string.Empty;
        int tagCount;

        //To navigate to ServiceListing Page
        public void SelectShareSkill()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@href='/Home/ServiceListing']", 3);
                shareSkillButton = driver.FindElement(By.XPath("//a[@href='/Home/ServiceListing']"));
                shareSkillButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public void RenderShareSkillComponents()
        {
            try
            {
                Wait.WaitToBeVisible("Name", "title", 15);
                title = driver.FindElement(By.Name("title"));
                description = driver.FindElement(By.Name("description"));
                category = driver.FindElement(By.Name("categoryId"));
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
                servicetype0 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='0']"));
                servicetype1 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='1']"));
                locationtype = driver.FindElement(By.Name("locationType"));
                startdate = driver.FindElement(By.Name("startDate"));
                enddate = driver.FindElement(By.Name("endDate"));
                skilltradeT = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='true']"));
                skilltradeF = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='false']"));
                worksamples = driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
                activeT = driver.FindElement(By.XPath("//input[@name='isActive'][@value='true']"));
                activeF = driver.FindElement(By.XPath("//input[@name='isActive'][@value='false']"));
                saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
                cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderSubcategoryComponent()
        {
            try
            {
                subcategory = driver.FindElement(By.Name("subcategoryId"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderCreditComponent()
        {
            try
            {
                credit = driver.FindElement(By.Name("charge"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement TagLocator(int index)
        {
            try
            {
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tagList![index];
        }
        public IWebElement TagRemoveLocator(int index)
        {
            try
            {
                tagRemoveList = driver.FindElements(By.XPath("//a[@class='ReactTags__remove']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tagRemoveList![index];
        }
        public IWebElement CreditLocator()
        {

            return credit!;
        }
        public IWebElement DescriptionLocator()
        {

            return description!;
        }
        public IWebElement TitleLocator()
        {

            return title!;
        }
        public IWebElement CategoryLocator()
        {

            return category!;
        }
        public IWebElement SubCategoryLocator()
        {

            return subcategory!;
        }
        public IWebElement ServiceType0Locator()
        {

            return servicetype0!;
        }
        public IWebElement ServiceType1Locator()
        {

            return servicetype1!;
        }
        public IWebElement LocationTypeLocator()
        {

            return locationtype!;
        }
        public IWebElement StartDateLocator()
        {

            return startdate!;
        }
        public IWebElement EndDateLocator()
        {

            return enddate!;
        }
        public IWebElement SkillTradeTLocator()
        {

            return skilltradeT!;
        }
        public IWebElement SkillTradeFLocator()
        {

            return skilltradeF!;
        }
        public IWebElement WorkSamplesLocator()
        {

            return worksamples!;
        }
        public IWebElement ActiveTLocator()
        {

            return activeT!;
        }
        public IWebElement ActiveFLocator()
        {

            return activeF!;
        }
        public IWebElement SaveButtonLocator()
        {

            return saveButton!;
        }
        public IWebElement CancelButtonLocator()
        {

            return cancelButton!;
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
        public string CaptureErrorMessage()
        {
            Thread.Sleep(1000);
            try
            {
                errorMessage = driver.FindElement(By.XPath("//div[@class='ui basic red prompt label transition visible']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (errorMessage != null)
            {
                errorMessageString = errorMessage.Text;
                Console.WriteLine(errorMessageString);
            }

            return errorMessageString;

        }
        public string CaptureSubcategoryErrorMessage()
        {
            Thread.Sleep(1000);
            try
            {
                errorMessage = driver.FindElement(By.XPath("//div[@class='ui red basic label']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (errorMessage != null)
            {
                errorMessageString = errorMessage.Text;
                Console.WriteLine(errorMessageString);
            }

            return errorMessageString;

        }
        public int GetTagCount()
        {
            Thread.Sleep(1000);
            try
            {
                tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return tagCount;
        }
        public string GetCurrentUrl()
        {
            Wait.WaitToBeVisible("XPath", "//h2[contains(text(),'Manage Listings')]", 10);
            string currentUrl = driver.Url;
            return currentUrl;
        }

    }
}
