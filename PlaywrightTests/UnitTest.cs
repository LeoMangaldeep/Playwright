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
        public async Task Setup()
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
            await _driver.Page.GotoAsync("https://www.qbe.com/");
        }

        [Test]
        public async Task TestLinkToAustraliaWebsite()
        {
            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Visit QBE Australia" }).ClickAsync();
        }

        [Test]
        public async Task TestLinkToNewZealandWebsite()
        {
            await _driver.Page.GetByRole(AriaRole.Button, new() { Name = "Close" }).ClickAsync();
            await _driver.Page.GetByText("About").Nth(1).ClickAsync();
        }
        
        [TearDown] 
        public async Task TearDown()
        {
            // Cleanup code needed for playwright browser, browserContext
            // and dispose the resources, 

            await _driver.Browser.CloseAsync();
            await _driver.Browser.DisposeAsync();
        }
    }
}