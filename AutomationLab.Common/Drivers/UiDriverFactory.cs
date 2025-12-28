using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace AutomationLab.Common.Drivers
{
    public static class UiDriverFactory
    {
        public static IWebDriver Create()
        {
            var browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome";

            return browser.ToLower() switch
            {
                "edge" => CreateEdge(),
                _ => CreateChrome()
            };
        }

        public static IWebDriver CreateEdge() {
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-extensions");
            return new EdgeDriver(options);
        }

        public static IWebDriver CreateChrome() {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
