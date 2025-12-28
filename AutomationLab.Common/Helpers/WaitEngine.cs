using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationLab.Common.Helpers
{
    public static class WaitEngine
    {
        private static readonly TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(10);

        public static IWebElement UntilVisible(IWebDriver driver, By locator)
        {
            return new WebDriverWait(driver,DefaultTimeOut)
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement UntilClickable(IWebDriver driver, By locator)
        {
            return new WebDriverWait(driver, DefaultTimeOut)
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void UntilUrlContains(IWebDriver driver, string partial)
        {
            new WebDriverWait(driver, DefaultTimeOut)
                .Until(ExpectedConditions.UrlContains(partial));
        }
    }
}
