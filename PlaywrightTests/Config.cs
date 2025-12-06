
namespace PlaywrightTests.Config
{
    public class TestSettings
    {
        public bool Headless { get; set; }
        public string? Channel { get; set; }
        public bool Devtools { get; set; }
        public int SlowMo { get; set; }
        public string[]? Args { get; set; }
        public DriverType DriverType { get; set; }
    }

    public enum DriverType
    {
        Chromium,
        Firefox,
        Webkit,
        Edge,
        Chrome
    }
}


