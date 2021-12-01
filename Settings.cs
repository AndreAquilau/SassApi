namespace SassApi
{
    public static class Settings
    {
        public static string Secret = Environment.ExpandEnvironmentVariables("%SECRET_TOKEN%").ToString();
    }
}
