using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.Driver;

namespace PlaywrightTests
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            PlaywrightDriver driver = new PlaywrightDriver();
            var page = await driver.InitializePlaywright();
            //await page.GetByRole(AriaRole.Link, new() { Name = "Visit QBE Australia" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Close" }).ClickAsync();

        }

        [Test]
        public async Task LaunchingBrowserInAnotherOption()
        {
            var playwrightDriver = await Playwright.CreateAsync();

            var browserOptions = new BrowserTypeLaunchOptions();
            browserOptions.Headless = false;
            browserOptions.Channel = "chrome";

            var chromium = await playwrightDriver["chromium"].LaunchAsync(browserOptions);
            var browserContext = await chromium.NewContextAsync();
            var page = await browserContext.NewPageAsync();

            await page.GotoAsync("https://www.qbe.com");

        }
    }
}