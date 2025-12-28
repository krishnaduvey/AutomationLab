using AutomationLab.Common.Drivers;
using AutomationLab.Common.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationLab
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void Start()
        {
            var driver = UiDriverFactory.Create();
            DriverManager.Set<IWebDriver>(driver);
        }

        [AfterScenario]
        public void End()
        {
            var driver = DriverManager.Get<IWebDriver>();
            driver.Quit();

            DriverManager.Clear();
            UiContext.Clear();
        }
    }
}
