using AdvancedTaskPart2SpecFlowProject.AssertHelpers;
using AdvancedTaskPart2SpecFlowProject.Pages.ManageRequestsComponent;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskPart2SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ManageRequestsStepDefinitions : CommonDriver
    {
        ManageRequestsRenderComponents manageRequestsRenderComponents;
        ManageRequestsOperations manageRequestsOperations;
        ManageRequestAssertHelper manageRequestAssertHelper;
        string actualMessage;
        string expectedMessage;

        public ManageRequestsStepDefinitions()
        {
            manageRequestsRenderComponents = new ManageRequestsRenderComponents();
            manageRequestsOperations = new ManageRequestsOperations();
            manageRequestAssertHelper = new ManageRequestAssertHelper();
            actualMessage = string.Empty;
            expectedMessage = string.Empty;
        }
        [Given(@"user logs into the Mars Portal as Abcd")]
        public void GivenUserLogsIntoTheMarsPortalAsAbcd()
        {
            InitialSetUp(1);
        }

        [When(@"user  navigates to the Sent Request page")]
        public void WhenUserNavigatesToTheSentRequestPage()
        {
            manageRequestsOperations.NavigateToSentRequestsPage();
        }

        [Then(@"user should be able to view all the requests sent by Abcd pagewise")]
        public void ThenUserShouldBeAbleToViewAllTheRequestsSentByAbcdPagewise()
        {
            manageRequestsOperations.GetSentRequestCount();
            int pageCount = manageRequestsOperations.GetPageCount();
            int requestCount = manageRequestsOperations.GetRequestsCount();
            manageRequestAssertHelper.AssertViewSentRequests(pageCount, requestCount);
        }

        [When(@"user  navigates to the received Request page")]
        public void WhenUserNavigatesToTheReceivedRequestPage()
        {
            manageRequestsOperations.NavigateToReceivedRequestsPageOfFirstUser();
        }

        [Then(@"user should be able to view all the requests received by Abcd pagewise")]
        public void ThenUserShouldBeAbleToViewAllTheRequestsReceivedByAbcdPagewise()
        {
            manageRequestsOperations.GetReceivedRequestCount();
            int pageCount = manageRequestsOperations.GetPageCount();
            int requestCount = manageRequestsOperations.GetRequestsCount();
            manageRequestAssertHelper.AssertViewReceivedRequests(pageCount, requestCount);
        }

        [Given(@"user  navigates to the interested service details page")]
        public void GivenUserNavigatesToTheInterestedServiceDetailsPage()
        {
            manageRequestsOperations.NavigateToServiceDetailsPage();
        }

        [When(@"user sends a skill trade request to the intended user")]
        public void WhenUserSendsASkillTradeRequestToTheIntendedUser()
        {
            manageRequestsOperations.SentRequest();
            actualMessage = manageRequestsRenderComponents.CapturePopupMessage();
            expectedMessage = "Request sent";
        }

        [When(@"user withdraws the sent request")]
        public void WhenUserWithdrawsTheSentRequest()
        {
            manageRequestsOperations.WithdrawSentRequest();
        }

        [Then(@"user should be able to successfully sent the request and withdraw it")]
        public void ThenUserShouldBeAbleToSuccessfullySentTheRequestAndWithdrawIt()
        {
            string actualWithdrawMessage = manageRequestsRenderComponents.CapturePopupMessage();
            string expectedWithdrawMessage = "Request has been withdrawn";
            manageRequestAssertHelper.AssertSentAndWithdrawRequests(actualMessage, expectedMessage, actualWithdrawMessage, expectedWithdrawMessage);
        }

        [Given(@"user sends a skill trade request to the intended user")]
        public void GivenUserSendsASkillTradeRequestToTheIntendedUser()
        {
            manageRequestsOperations.SentRequest();
        }

        [When(@"received user accepts rates and completes the received request")]
        public void WhenReceivedUserAcceptsRatesAndCompletesTheReceivedRequest()
        {
            manageRequestsOperations.LoginAsDifferentUser();
            manageRequestsOperations.NavigateToReceivedRequestsPage();
            manageRequestsOperations.AcceptRateAndCompleteReceivedRequest();
            manageRequestsOperations.CloseNewDriver();
        }

        [When(@"sent user completes and reviews the skill trade sent request")]
        public void WhenSentUserCompletesAndReviewsTheSkillTradeSentRequest()
        {
            manageRequestsOperations.NavigateToSentRequestsPage();
            manageRequestsOperations.CompleteAndReviewSentRequest();
        }

        [Then(@"sent user should be able to successfully complete the skill trade request")]
        public void ThenSentUserShouldBeAbleToSuccessfullyCompleteTheSkillTradeRequest()
        {
            string actualStatus = manageRequestsRenderComponents.GetSentRequestStatus();
            string expectedStatus = "Completed";
            manageRequestAssertHelper.AssertCompleteSkillTradeRequest(actualStatus, expectedStatus);
        }

        [When(@"received user declines the new skill trade request")]
        public void WhenReceivedUserDeclinesTheNewSkillTradeRequest()
        {
            manageRequestsOperations.LoginAsDifferentUser();
            manageRequestsOperations.NavigateToReceivedRequestsPage();
            manageRequestsOperations.DeclineReceivedRequest();
            manageRequestsOperations.CloseNewDriver();
            manageRequestsOperations.NavigateToSentRequestsPage();
        }

        [Then(@"sent user should be able to see the skill trade request in declined status")]
        public void ThenSentUserShouldBeAbleToSeeTheSkillTradeRequestInDeclinedStatus()
        {
            string actualStatus = manageRequestsRenderComponents.GetSentRequestStatus();
            string expectedStatus = "Declined";
            manageRequestAssertHelper.AssertDeclineSkillTradeRequest(actualStatus, expectedStatus);
        }

    }
}
