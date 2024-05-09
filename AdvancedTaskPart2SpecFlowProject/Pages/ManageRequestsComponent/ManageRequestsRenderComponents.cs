using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ManageRequestsComponent
{
    public class ManageRequestsRenderComponents : CommonDriver
    {
        IWebElement? manageRequestTab;
        IWebElement? sentRequestOption;
        IWebElement? receivedRequestOption;
        IWebElement? nextButton;
        IWebElement? searchSkillsIcon;
        IWebElement? searchUserTB;
        IWebElement? userName;
        IWebElement? filterText;
        IWebElement? requiredService;
        IWebElement? requestMessage;
        IWebElement? requestButton;
        IWebElement? messageBox;
        IWebElement? yesButton;
        IWebElement? withdrawButton;
        IWebElement? acceptButton;
        IWebElement? declineButton;
        IWebElement? completeButton;
        IWebElement? reviewButton;
        IWebElement? reviewComment;
        IWebElement? starRating;
        IWebElement? communicationRating;
        IWebElement? serviceRating;
        IWebElement? recommendRating;
        IWebElement? saveButton;
        IWebElement? status;

        string actualMessage = string.Empty;
        string statusMessage = string.Empty;

        int pageCount;
        int requestsCount;
        public void SentAndReceiveOptionsRenderComponents(IWebDriver newDriver)
        {
            try
            {
                var wait = new WebDriverWait(newDriver, new TimeSpan(0, 0, 15));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//section[@class='nav-secondary']//div[contains(text(),'Manage Requests')]")));

                manageRequestTab = newDriver.FindElement(By.XPath("//section[@class='nav-secondary']//div[contains(text(),'Manage Requests')]"));
                receivedRequestOption = newDriver.FindElement(By.XPath("//section[@class='nav-secondary']//a[contains(text(),'Received Requests')]"));
                sentRequestOption = newDriver.FindElement(By.XPath("//section[@class='nav-secondary']//a[contains(text(),'Sent Requests')]"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void LoginDetailsRenderComponents(IWebDriver newDriver, string emailId, string password)
        {
            var wait = new WebDriverWait(newDriver, new TimeSpan(0, 0, 15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")));

            IWebElement SignInButton = newDriver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignInButton.Click();

            wait = new WebDriverWait(newDriver, new TimeSpan(0, 0, 15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@placeholder='Email address']")));

            IWebElement emailIdTextBox = newDriver.FindElement(By.XPath("//*[@placeholder='Email address']"));
            IWebElement passWordTextBox = newDriver.FindElement(By.XPath("//*[@placeholder='Password']"));
            IWebElement loginButton = newDriver.FindElement(By.XPath("//*[text()='Login']"));

            emailIdTextBox?.SendKeys(emailId);
            passWordTextBox?.SendKeys(password);
            loginButton?.Click();
        }
        public void SelectSearchSkill()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//i[@class='search link icon']", 10);
                searchSkillsIcon = driver.FindElement(By.XPath("//i[@class='search link icon']"));
                searchSkillsIcon.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderSearchUserComponents()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='ui search']", 10);
                searchUserTB = driver.FindElement(By.XPath("//div[@class='ui search']"));
                userName = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void SelectFilterTextComponents()
        {
            try
            {
                filterText = driver.FindElement(By.XPath("//div[contains(text(),'Filter')]"));
                filterText.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RequestSkillTradeRenderComponents()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//textarea[@placeholder='I am interested in trading my cooking skills with your coding skills..']", 10);
                requestMessage = driver.FindElement(By.XPath("//textarea[@placeholder='I am interested in trading my cooking skills with your coding skills..']"));
                Wait.WaitToBeVisible("XPath", "//div[@id='service-detail-section']//div[@class='ui teal  button']", 10);
                requestButton = driver.FindElement(By.XPath("//div[@id='service-detail-section']//div[@class='ui teal  button']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void AcceptConfirmationRenderComponents()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//button[@class='ui button ui teal button'][contains(text(),'Yes')]", 10);
                yesButton = driver.FindElement(By.XPath("//button[@class='ui button ui teal button'][contains(text(),'Yes')]"));
                yesButton.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void SelectWithdrawRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='sent-request-section']//tr[1]//td[8]/button[contains(text(),'Withdraw')]", 10);
                withdrawButton = driver.FindElement(By.XPath("//div[@id='sent-request-section']//tr[1]//td[8]/button[contains(text(),'Withdraw')]"));
                withdrawButton.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void AcceptReceivedRequestRenderComponents(IWebDriver newDriver)
        {
            try
            {
                var wait = new WebDriverWait(newDriver, new TimeSpan(0, 0, 10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='received-request-section']//tr[1]//td[8]/button[contains(text(),'Accept')]")));

                acceptButton = newDriver.FindElement(By.XPath("//div[@id='received-request-section']//tr[1]//td[8]/button[contains(text(),'Accept')]"));
                acceptButton.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void DeclineReceivedRequestRenderComponents(IWebDriver newDriver)
        {
            try
            {
                var wait = new WebDriverWait(newDriver, new TimeSpan(0, 0, 10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='received-request-section']//tr[1]//td[8]/button[contains(text(),'Decline')]")));

                declineButton = newDriver.FindElement(By.XPath("//div[@id='received-request-section']//tr[1]//td[8]/button[contains(text(),'Decline')]"));
                declineButton.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RateReceivedRequestRenderComponents(IWebDriver newDriver)
        {
            try
            {
                var wait = new WebDriverWait(newDriver, new TimeSpan(0, 0, 10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='received-request-section']//tr[2]/td[3]//i[4]")));

                starRating = newDriver.FindElement(By.XPath("//div[@id='received-request-section']//tr[2]/td[3]//i[4]"));
                starRating.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void CompleteReceivedRequestRenderComponents(IWebDriver newDriver)
        {
            try
            {
                var wait = new WebDriverWait(newDriver, new TimeSpan(0, 0, 10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='received-request-section']//tr[1]//td[8]/button[contains(text(),'Complete')]")));

                completeButton = newDriver.FindElement(By.XPath("//div[@id='received-request-section']//tr[1]//td[8]/button[contains(text(),'Complete')]"));
                completeButton.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void CompleteSentRequestRenderComponents()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='sent-request-section']//tr[1]//td[8]/button[contains(text(),'Completed')]", 10);
                completeButton = driver.FindElement(By.XPath("//div[@id='sent-request-section']//tr[1]//td[8]/button[contains(text(),'Completed')]"));
                completeButton.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void ReviewSentRequestRenderComponents()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='sent-request-section']//tr[1]//td[8]/button[contains(text(),'Review')]", 10);
                reviewButton = driver.FindElement(By.XPath("//div[@id='sent-request-section']//tr[1]//td[8]/button[contains(text(),'Review')]"));
                reviewButton.Click();
                Wait.WaitToBeVisible("XPath", "//textarea[@placeholder='Leave a Review']", 10);
                reviewComment = driver.FindElement(By.XPath("//textarea[@placeholder='Leave a Review']"));
                reviewComment.SendKeys("Excellent");
                communicationRating = driver.FindElement(By.XPath("//div[@id='communicationRating']/i[3]"));
                communicationRating.Click();
                serviceRating = driver.FindElement(By.XPath("//div[@id='serviceRating']/i[4]"));
                serviceRating.Click();
                recommendRating = driver.FindElement(By.XPath("//div[@id='recommendRating']/i[4]"));
                recommendRating.Click();
                saveButton = driver.FindElement(By.XPath("//div[@class='ui teal button']"));
                saveButton.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public string GetSentRequestStatus()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='sent-request-section']//tr[1]//td[5]", 10);
                status = driver.FindElement(By.XPath("//div[@id='sent-request-section']//tr[1]//td[5]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (status != null)
            {
                statusMessage = status.Text;
                Console.WriteLine(statusMessage);
            }

            return statusMessage;
        }

        public void SelectRequiredService()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//p[@class='row-padded']", 10);
                requiredService = driver.FindElement(By.XPath("//p[@class='row-padded']"));
                requiredService?.Click();
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

            return actualMessage;
        }

        public IWebElement RequestMessageLocator()
        {

            return requestMessage!;
        }
        public IWebElement RequestButtonLocator()
        {

            return requestButton!;
        }

        public IWebElement SearchUserNameLocator()
        {

            return userName!;
        }

        public IWebElement SearchUserTBLocator()
        {

            return searchUserTB!;
        }

        public IWebElement ManageRequestTabLocator()
        {

            return manageRequestTab!;
        }
        public IWebElement ReceivedRequestOptionLocator()
        {

            return receivedRequestOption!;
        }
        public IWebElement SentRequestOptionLocator()
        {

            return sentRequestOption!;
        }
        public int GetSentRequestPageCount()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='sent-request-section']//table", 5);
                pageCount = driver.FindElements(By.XPath("//button[@class='ui button otherPage']")).Count;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return pageCount;
        }
        public int GetReceivedRequestPageCount()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='received-request-section']//table", 5);
                pageCount = driver.FindElements(By.XPath("//button[@class='ui button otherPage']")).Count;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return pageCount;
        }

        public int GetSentRequestsCount()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='sent-request-section']//table", 5);
                requestsCount = driver.FindElements(By.XPath("//div[@id='sent-request-section']//tr")).Count - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return requestsCount;
        }
        public int GetReceivedRequestsCount()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@id='received-request-section']//table", 5);
                requestsCount = driver.FindElements(By.XPath("//div[@id='received-request-section']//tr")).Count - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return requestsCount;
        }
        public void NextButtonRenderComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//button[@class='ui button otherPage'][last()]", 5);
                nextButton = driver.FindElement(By.XPath("//button[@class='ui button otherPage'][last()]"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public IWebElement NextButtonLocator()
        {

            return nextButton!;
        }
    }
}
