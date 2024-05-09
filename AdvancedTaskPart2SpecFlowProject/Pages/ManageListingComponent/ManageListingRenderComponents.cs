using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ManageListingComponent
{
    public class ManageListingRenderComponents : CommonDriver
    {
        IWebElement? manageListingTab;
        IWebElement? penIcon;
        IWebElement? titleListing;
        IWebElement? shareSkillButton;
        IWebElement? title;
        IWebElement? description;
        IWebElement? category;
        IWebElement? subcategory;
        IWebElement? servicetype0;
        IWebElement? servicetype1;
        IWebElement? locationtype;
        IWebElement? startdate;
        IWebElement? skilltradeT;
        IWebElement? skilltradeF;
        IWebElement? credit;
        IList<IWebElement>? tagList;
        IList<IWebElement>? tagRemoveList;
        IWebElement? saveButton;
        IWebElement? messageBox;
        IWebElement? errorMessage;
        IWebElement? yesButton;
        IWebElement? noButton;
        IWebElement? eyeIcon;
        IWebElement? userDetail;
        IWebElement? activeButton;
        IWebElement? manageListingCategory;
        IWebElement? manageListingType;
        IWebElement? manageListingSkillTrade;
        IList<IWebElement>? removeList;
        string actualMessage = string.Empty;
        string errorMessageString = string.Empty;

        public void RenderShareSkillComponents()
        {
            try
            {
                Wait.WaitToBeVisible("Name", "title", 20);
                title = driver.FindElement(By.Name("title"));
                description = driver.FindElement(By.Name("description"));
                category = driver.FindElement(By.Name("categoryId"));
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
                servicetype0 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='0']"));
                servicetype1 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='1']"));
                locationtype = driver.FindElement(By.Name("locationType"));
                startdate = driver.FindElement(By.Name("startDate"));
                skilltradeT = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='true']"));
                skilltradeF = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='false']"));
                saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
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
        public void ManageListingTabRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@href = '/Home/ListingManagement']", 5);
                manageListingTab = driver.FindElement(By.XPath("//a[@href = '/Home/ListingManagement']"));
                manageListingTab.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void PenIconRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id = 'listing-management-section']//tbody", 5);
                penIcon = driver.FindElement(By.XPath("//div[@id = 'listing-management-section']//tr[1]//i[@class='outline write icon']"));
                penIcon.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void EyeIconRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id = 'listing-management-section']//tbody", 5);
                eyeIcon = driver.FindElement(By.XPath("//div[@id='listing-management-section']//i[@class='eye icon']"));
                eyeIcon.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string GetUserDetail()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='user-info']//h3", 15);
                userDetail = driver.FindElement(By.XPath("//div[@class='user-info']//h3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            string userName = userDetail!.Text;
            return userName;
        }

        public void DeleteConfirmationRenderComponent()
        {
            try
            {
                yesButton = driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
                noButton = driver.FindElement(By.XPath("//button[@class='ui negative button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ToggleActiveStatusRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='listing-management-section']//tbody", 15);
                activeButton = driver.FindElement(By.XPath("//div[@id='listing-management-section']//input[@name='isActive']"));
                activeButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement YesButtonLocator()
        {

            return yesButton!;
        }
        public IWebElement NoButtonLocator()
        {

            return noButton!;
        }
        public IList<IWebElement> RemoveRenderComponents()
        {

            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id = 'listing-management-section']//tbody", 5);
                removeList = driver.FindElements(By.XPath("//div[@id='listing-management-section']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return removeList!;
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
        public IWebElement StartDateLocator()
        {

            return startdate!;
        }

        public IWebElement SkillTradeTLocator()
        {

            return skilltradeT!;
        }
        public IWebElement SkillTradeFLocator()
        {

            return skilltradeF!;
        }
        public IWebElement SaveButtonLocator()
        {

            return saveButton!;
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
        public IList<IWebElement> TagRemoveLocator()
        {
            try
            {
                tagRemoveList = driver.FindElements(By.XPath("//a[@class='ReactTags__remove']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tagRemoveList!;
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
        public string GetFirstManageListingsTitle()
        {
            string titleName = string.Empty;
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id = 'listing-management-section']//tbody", 5);
                titleListing = driver.FindElement(By.XPath("//div[@id = 'listing-management-section']//tr[1]/td[3]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            titleName = titleListing!.Text;
            return titleName;
        }
        public string GetFirstManageListingsType()
        {
            string typeName = string.Empty;
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id = 'listing-management-section']//tbody", 5);
                manageListingType = driver.FindElement(By.XPath("//div[@id = 'listing-management-section']//tr[1]/td[5]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            typeName = manageListingType!.Text;
            return typeName;
        }
        public string GetFirstManageListingsSkillTrade()
        {
            string skillTradeName = string.Empty;
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id = 'listing-management-section']//tbody", 5);
                manageListingSkillTrade = driver.FindElement(By.XPath("//div[@id = 'listing-management-section']//tr[1]/td[6]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            skillTradeName = manageListingSkillTrade!.GetAttribute("class");
            return skillTradeName;
        }
        public string GetFirstManageListingsCategory()
        {
            string categoryName = string.Empty;
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id = 'listing-management-section']//tbody", 5);
                manageListingCategory = driver.FindElement(By.XPath("//div[@id = 'listing-management-section']//tr[1]/td[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            categoryName = manageListingCategory!.Text;
            return categoryName;
        }

        public string GetServiceListingsTitle()
        {
            string titleName = string.Empty;
            try
            {
                Wait.WaitToBeVisible("Name", "title", 20);
                titleListing = driver.FindElement(By.Name("title"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            titleName = titleListing!.GetAttribute("value");
            return titleName;
        }
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
        public int GetServiceListingCount()
        {
            int rowCount = driver.FindElements(By.XPath("//div[@id='listing-management-section']//tr")).Count;
            return rowCount - 1;
        }
    }
}
