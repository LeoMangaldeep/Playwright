
namespace PlaywrightTests.Config
{
    public class TestSettings
    {
        private float? Timeout { get; set; }
        public bool? Headless { get; set; }
        public bool DevTools { get; set; }
        public string[]? Agrs { get; set; }
        public float? SlowMo { get; set; }
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


