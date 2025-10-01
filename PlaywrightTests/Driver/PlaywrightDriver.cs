using Microsoft.Playwright;

namespace PlaywrightTests.Driver
{

    public class PlaywrightDriver
    {

        public async Task<IPage> InitializePlaywright()
        {
            var playwrightDriver = await Playwright.CreateAsync();

            var browserOptions = new BrowserTypeLaunchOptions();
            browserOptions.Headless = false;
            browserOptions.Channel = "chrome";

            var chromium = await playwrightDriver["chromium"].LaunchAsync(browserOptions);
            var browserContext = await chromium.NewContextAsync();
            var page = await browserContext.NewPageAsync();

            await page.GotoAsync("https://www.qbe.com");

            return page;
        }
    }
}