using Microsoft.Playwright;
using PlaywrightTests.Config;


namespace PlaywrightTests.Driver
{
    public class PlaywrightDriver
    {
        private readonly Task<IBrowser> _browser;
        private readonly Task<IBrowserContext> _browserContext;
        private readonly TestSettings _testSettings;
        private readonly Task<IPage> _page;
        private readonly IPlaywrightDriverInitializer _playwrightDriverInitializer;


        public PlaywrightDriver(TestSettings testSettings, IPlaywrightDriverInitializer playwrightDriverInitializer)
        {
            _testSettings = testSettings;
            _playwrightDriverInitializer = playwrightDriverInitializer;
            _browser = Task.Run(InitializePlaywrightAsync);
            _browserContext = Task.Run(CreateBrowserContext);
            _page = Task.Run(CreatePageAsync);
        }
        public IPage Page => _page.Result;
        public IBrowser Browser => _browser.Result;
        public IBrowserContext BrowserContext => _browserContext.Result;

        private async Task<IBrowser> InitializePlaywrightAsync()
        {
            return _testSettings.DriverType switch
            {
                DriverType.Chromium => await _playwrightDriverInitializer.GetChromiumDriverAsync(_testSettings),
                DriverType.Firefox => await _playwrightDriverInitializer.GetFirefoxDriverAsync(_testSettings),
                DriverType.Webkit => await _playwrightDriverInitializer.GetWebKitDriverAsync(_testSettings),
                DriverType.Chrome => await _playwrightDriverInitializer.GetChromeDriverAsync(_testSettings),
                DriverType.Edge => await _playwrightDriverInitializer.GetEdgeDriverAsync(_testSettings),
                _ => await _playwrightDriverInitializer.GetChromiumDriverAsync(_testSettings)
            };
        }
        private async Task<IBrowserContext> CreateBrowserContext()
        {
            return await (await _browser).NewContextAsync();
        }
        private async Task<IPage> CreatePageAsync()
        {
            return await (await _browserContext).NewPageAsync();
        }
    }
}