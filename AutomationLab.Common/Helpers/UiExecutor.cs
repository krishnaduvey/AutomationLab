using AutomationLab.Common.Config;
using AutomationLab.Common.Drivers;
using OpenQA.Selenium;
using AutomationLab.Common.Config;

namespace AutomationLab.Common.Helpers
{
    /// <summary>
    /// Central execution engine for all UI actions.
    /// Handles waits, retries, logging, screenshots and stability.
    /// </summary>
    public static class UiExecutor
    {
        private const int MaxRetry = 3;

        private static IWebDriver driver => DriverManager.Get<IWebDriver>();

        public static void Click(By locator)
        {
            Execute(() =>
            {
                var element = WaitEngine.UntilClickable(driver, locator);
                element.Click();
            });
        }

        public static void Type(By locator, string text)
        {
            Execute(() =>
            {
                var element = WaitEngine.UntilVisible(driver, locator);
                element.Clear();
                element.SendKeys(text);
            });
        }

        public static string GetText(By locator)
        {
            return Execute(() =>
            {
                var element = WaitEngine.UntilVisible(driver, locator);
                return element.Text;
            });
        }

        public static void ScrollIntoView(By locator)
        {
            var driver = DriverManager.Get<IWebDriver>();
            var element = WaitEngine.UntilVisible(driver, locator);

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView({block:'center'});", element);
        }

        private static void Execute(Action action)
        {
            for (int attempt = 1; attempt <= MaxRetry; attempt++)
            {
                try
                {
                    action();
                    return;
                }
                catch (StaleElementReferenceException) when (attempt < MaxRetry) { }
                catch (ElementClickInterceptedException) when (attempt < MaxRetry) { }
                catch (Exception) { }
            }
            action();
        }

        private static T Execute<T>(Func<T> func)
        {
            for (int attempt = 1; attempt <= MaxRetry; attempt++)
            {
                try
                {
                    return func();
                }
                catch (StaleElementReferenceException) when (attempt < MaxRetry) { }
                catch (ElementClickInterceptedException) when (attempt < MaxRetry) { }
                catch (Exception) { }
            }
            return func();
        }

        public static void NavigateTo(string relativeUrl)
        {
            var driver = DriverManager.Get<IWebDriver>();
            driver.Navigate().GoToUrl(EnvironmentConfig.BaseUrl + relativeUrl);
        }
    }
}
