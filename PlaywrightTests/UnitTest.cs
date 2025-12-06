using Microsoft.Playwright;
using NUnit.Framework.Internal;
using PlaywrightTests.Config;
using PlaywrightTests.Driver;

namespace PlaywrightTests
{

    public class Tests
    {
        private PlaywrightDriver _driver;
        private PlaywrightDriverInitializer _playwrightDriverInitializer;

        [SetUp]
        public void Setup()
        {
            TestSettings testSettings = new TestSettings
            {
                Headless = false,
                DevTools = true,
                SlowMo = 1500,
                DriverType = DriverType.Edge
            };
            _playwrightDriverInitializer = new PlaywrightDriverInitializer();
            _driver = new PlaywrightDriver(testSettings, _playwrightDriverInitializer);
        }

        [Test]
        public async Task TestLinkToAustraliaWebsite()
        {
            var page = await _driver.Page;
            await page.GotoAsync("https://www.qbe.com/");
            await page.GetByRole(AriaRole.Link, new() { Name = "Visit QBE Australia" }).ClickAsync();
        }

        [Test]
        public async Task TestLinkToNewZealandWebsite()
        {
            var page = await _driver.Page;
            await page.GotoAsync("https://www.qbe.com/");
            await page.GetByRole(AriaRole.Button, new() { Name = "Close" }).ClickAsync();
            await page.GetByText("About").Nth(1).ClickAsync();
        }
        
        [TearDown] 
        public async Task TearDown()
        {
            // Cleanup code needed for playwright browser, browserContext
            // and dispose the resources, 
            var browser = await _driver.Browser;
            await browser.CloseAsync();
            await browser.DisposeAsync();
        }
    }
}