namespace AutomationLab.Common.Config
{
    public static class EnvironmentConfig
    {
        public static string BaseUrl =>
            Environment.GetEnvironmentVariable("BASE_URL") ?? "https://demoqa.com";
    }
}
