using Microsoft.Playwright;
using NUnit.Framework.Internal;
using PlaywrightTests.Config;
using System.Threading.Tasks;

namespace PlaywrightTests.Driver
{

    public class PlaywrightDriver
    {
        public IBrowser? Browser;
        public IBrowserContext? BrowserContext;
        public async Task<IPage> InitializePlaywright(TestSettings testSettings)
        {
            Browser = await GetBrowserAsync(testSettings);
            var BrowserContext = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = null,
            });
            var page = await BrowserContext.NewPageAsync();

            await page.GotoAsync("https://www.qbe.com");

            return page;
        }
        public async Task<IBrowser> GetBrowserAsync(TestSettings testSettings)
        {
            var playwrightDriver = await Playwright.CreateAsync();

            var browserOptions = new BrowserTypeLaunchOptions
            {
                Headless = testSettings.Headless,
                Channel = testSettings.Channel,
                SlowMo = testSettings.SlowMo
            };

            return testSettings.DriverType switch
            {
                DriverType.Chromium => await playwrightDriver.Chromium.LaunchAsync(browserOptions),
                DriverType.Firefox => await playwrightDriver.Firefox.LaunchAsync(browserOptions),
                DriverType.Webkit => await playwrightDriver.Webkit.LaunchAsync(browserOptions),
                DriverType.Chrome => await playwrightDriver["chrome"].LaunchAsync(browserOptions),
                DriverType.Edge => await playwrightDriver.Chromium.LaunchAsync(browserOptions),
                _ => await playwrightDriver.Chromium.LaunchAsync(browserOptions)
            };
        }
    }
}