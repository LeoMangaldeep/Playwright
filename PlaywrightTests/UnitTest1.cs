using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using PlaywrightTests.Config;
using PlaywrightTests.Driver;

namespace PlaywrightTests
{

    public class Tests
    {
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            TestSettings testSettings = new()
            {
                Headless = false,
                Channel = "webkit",
                Devtools = true,
                SlowMo = 1500,
                Args = new string[] { "start-maximized" },
                DriverType = DriverType.Webkit
            };

            var driver = new PlaywrightDriver();
            _page = await driver.InitializePlaywright(testSettings);
        }

        [Test]
        public async Task TestLinkToAustraliaWebsite()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Visit QBE Australia" }).ClickAsync();
        }

        [Test]
        public async Task TestLinkToNewZealandWebsite()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Close" }).ClickAsync();
            await _page.GetByText("About").Nth(1).ClickAsync();
        }
        
        [TearDown] 
        public void TearDown()
        {
            // Cleanup code needed for playwright browser, browserContext
            // and dispose the resources, 
        }

    }
}