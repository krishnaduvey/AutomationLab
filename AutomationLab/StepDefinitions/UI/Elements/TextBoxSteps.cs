using AutomationLab.Common.Helpers;
using AutomationLab.Domains.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationLab.StepDefinitions.UI.Elements

{
    [Binding]
    public class TextBoxSteps
    {
        private readonly TextBoxDomain _domain = new TextBoxDomain();

        [Given("user is on demoqa textbox page")]
        public void GivenUserIsOnPage()
        {
            _domain.Open();
        }

        [When("user submits textbox form")]
        public void WhenUserSubmitsForm()
        {
            _domain.Submit("Krishan", "test@test.com", "India", "Automation Architect");
        }

        [Then("submitted name should be displayed")]
        public void ThenVerify()
        {
            var name = _domain.GetSubmittedName();
            Assert.That(name.Contains("Krishan"));
        }
    }
}
