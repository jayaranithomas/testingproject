using AdvancedTaskPart2SpecFlowProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ManageRequestsComponent
{
    public class ManageRequestsOperations : CommonDriver
    {
        ManageRequestsRenderComponents renderComponents;
        IWebDriver? newDriver;
        int pageCount;
        int requestCount;
        public ManageRequestsOperations()
        {
            renderComponents = new ManageRequestsRenderComponents();
        }
        public void NavigateToSentRequestsPage()
        {
            renderComponents.SentAndReceiveOptionsRenderComponents(driver);
            renderComponents.ManageRequestTabLocator()?.Click();
            Thread.Sleep(1000);
            renderComponents.SentRequestOptionLocator()?.Click();
        }
        public void NavigateToReceivedRequestsPageOfFirstUser()
        {
            renderComponents.SentAndReceiveOptionsRenderComponents(driver);
            renderComponents.ManageRequestTabLocator()?.Click();
            Thread.Sleep(1000);
            renderComponents.ReceivedRequestOptionLocator()?.Click();
        }


        public void GetSentRequestCount()
        {
            pageCount = renderComponents.GetSentRequestPageCount();
            int i = pageCount;
            requestCount = renderComponents.GetSentRequestsCount();
            renderComponents.NextButtonRenderComponent();
            while (i > 1)
            {
                renderComponents.NextButtonLocator()?.Click();
                Thread.Sleep(1000);
                requestCount += renderComponents.GetSentRequestsCount();
                i--;
            }
        }
        public void GetReceivedRequestCount()
        {
            pageCount = renderComponents.GetReceivedRequestPageCount();
            int i = pageCount;
            requestCount = renderComponents.GetReceivedRequestsCount();
            renderComponents.NextButtonRenderComponent();
            while (i > 1)
            {
                renderComponents.NextButtonLocator()?.Click();
                Thread.Sleep(1000);
                requestCount += renderComponents.GetReceivedRequestsCount();
                i--;
            }
        }

        public void NavigateToServiceDetailsPage()
        {
            renderComponents.SelectSearchSkill();
            renderComponents.RenderSearchUserComponents();
            renderComponents.SearchUserTBLocator()?.Click();
            renderComponents.SearchUserNameLocator()?.SendKeys("test4 user");
            Thread.Sleep(4000);
            renderComponents.SearchUserNameLocator()?.SendKeys(Keys.Down);
            Thread.Sleep(2000);
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.KeyDown(Keys.Enter).KeyUp(Keys.Enter);
            actions.Perform();
            renderComponents.SelectFilterTextComponents();
            renderComponents.SelectRequiredService();

        }
        public void SentRequest()
        {
            renderComponents.RequestSkillTradeRenderComponents();
            renderComponents.RequestMessageLocator()?.SendKeys("I am interested.");
            renderComponents.RequestButtonLocator()?.Click();
            renderComponents.AcceptConfirmationRenderComponents();
        }
        public void WithdrawSentRequest()
        {
            renderComponents.SentAndReceiveOptionsRenderComponents(driver);
            renderComponents.ManageRequestTabLocator()?.Click();
            Thread.Sleep(1000);
            renderComponents.SentRequestOptionLocator()?.Click();
            renderComponents.SelectWithdrawRenderComponent();
        }

        public void LoginAsDifferentUser()
        {
            newDriver = new ChromeDriver();
            newDriver.Manage().Window.Maximize();
            newDriver.Navigate().GoToUrl("http://localhost:5000/Home");

            renderComponents.LoginDetailsRenderComponents(newDriver, "testuser4@sample.com", "123456");
        }
        public void NavigateToReceivedRequestsPage()
        {
            renderComponents.SentAndReceiveOptionsRenderComponents(newDriver!);
            renderComponents.ManageRequestTabLocator()?.Click();
            Thread.Sleep(1000);
            renderComponents.ReceivedRequestOptionLocator()?.Click();
        }
        public void DeclineReceivedRequest()
        {
            renderComponents.DeclineReceivedRequestRenderComponents(newDriver!);
        }

        public void AcceptRateAndCompleteReceivedRequest()
        {
            renderComponents.AcceptReceivedRequestRenderComponents(newDriver!);
            renderComponents.RateReceivedRequestRenderComponents(newDriver!);
            renderComponents.CompleteReceivedRequestRenderComponents(newDriver!);
        }
        public void CompleteAndReviewSentRequest()
        {
            renderComponents.CompleteSentRequestRenderComponents();
            renderComponents.CapturePopupMessage();
            renderComponents.ReviewSentRequestRenderComponents();
            renderComponents.CapturePopupMessage();

        }
        public void CloseNewDriver()
        {
            newDriver?.Quit();
        }
        public int GetPageCount()
        {
            return pageCount;
        }
        public int GetRequestsCount()
        {
            return requestCount;
        }

    }
}
