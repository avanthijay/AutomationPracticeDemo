using System;
using AutomationPracticeDemo.Pages;
using TechTalk.SpecFlow;

namespace AutomationPracticeDemo.StepDefinitions
{
    [Binding]
    public class LoginSteps : BasePage
    {
        private readonly LoginPage _loginPage;
        private readonly AutomationExpPage _automationExpPage;
        private readonly DashboardPage _dashboardPage;

        public LoginSteps()
        {
            _automationExpPage = new AutomationExpPage();
            _loginPage = new LoginPage();
            _dashboardPage = new DashboardPage();
        }

        [Given(@"I am on the landing page")]
        public void GivenIAmOnTheLandingPage()
        {
            _automationExpPage.VisitPage();
        }

        [Given(@"I select to Login automation link")]
        public void GivenISelectToLoginAutomationLink()
        {
            _automationExpPage.GoToAutomationLogin();
        }

        [When(@"I enter valid username and password")]
        public void WhenIEnterValidUsernameAndPassword()
        {
            _loginPage.LogIn();
        }


        [Then(@"I should see the Dashboard")]
        public void ThenIShouldSeeTheDashboard()
        {
            _dashboardPage.VerifyPage();
        }

        [When(@"I enter '(.*)'")]
        public void WhenIEnter(string p0)
        {
            _automationExpPage.Search(p0);
        }

        [Then(@"I should be navigated to the search '(.*)' page")]
        public void ThenIShouldBeNavigatedToTheSearchPage(string p0)
        {
           //WebDriver.Title.Contains(p0);
            WebDriver.PageSource.Contains(p0);
        }

        [When(@"I select '(.*)'")]
        public void WhenISelect(string p0)
        {
            _automationExpPage.ActionContents(p0);
        }

        [Then(@"Contents should be '(.*)'")]
        public void ThenContentsShouldBe(string p0)
        {
            _automationExpPage.VerifyContents(p0);
        }

        [When(@"I click on Content hide")]
        public void WhenIClickOnContentHide()
        {
            _automationExpPage.ActionContents("hide");
        }

        [When(@"I click on COntent show")]
        public void WhenIClickOnCOntentShow()
        {
            _automationExpPage.ActionContents("show");
        }

        [Then(@"Contents should be hidden")]
        public void ThenContentsShouldBeHidden()
        {
            _automationExpPage.VerifyContents("hidden");
        }

        [Then(@"COntent should be shown")]
        public void ThenCOntentShouldBeShown()
        {
            _automationExpPage.VerifyContents("shown");
        }

    }
}
