using AutomationLab.Common.Config;
using AutomationLab.Common.Helpers;
using AutomationLab.Common.Pages.UI.Elements;

namespace AutomationLab.Domains.Elements
{
    /// <summary>
    /// Business workflow for DEMOQA TextBox capability.
    /// </summary>
    public class TextBoxDomain
    {
        private readonly TextBoxPage _page = new TextBoxPage();

        public void Open()
        {
            UiExecutor.NavigateTo(Routes.Elements);
            UiExecutor.Click(_page.TextBoxMenu);
        }

        public void Submit(string fullName, string email, string currentAddress, string permanentAddress)
        {
            UiExecutor.Type(_page.FullName, fullName);
            UiExecutor.Type(_page.Email, email);
            UiExecutor.Type(_page.CurrentAddress, currentAddress);
            UiExecutor.Type(_page.PermanentAddress, permanentAddress);
            UiExecutor.ScrollIntoView(_page.SubmitButton);
            UiExecutor.Click(_page.SubmitButton);
        }

        public string GetSubmittedName()
        {
            return UiExecutor.GetText(_page.OutputName);
        }
    }
}
