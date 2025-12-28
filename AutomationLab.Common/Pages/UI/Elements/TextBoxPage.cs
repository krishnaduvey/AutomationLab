using OpenQA.Selenium;

namespace AutomationLab.Common.Pages.UI.Elements
{
    /// <summary>
    /// Pure locator abstraction for DEMOQA TextBox page.
    /// </summary>
    public class TextBoxPage
    {
        public By TextBoxMenu => By.Id("item-0");
        public By FullName => By.Id("userName");
        public By Email => By.Id("userEmail");
        public By CurrentAddress => By.Id("currentAddress");
        public By PermanentAddress => By.Id("permanentAddress");
        public By SubmitButton => By.Id("submit");
        public By OutputName => By.Id("name");
    }
}
