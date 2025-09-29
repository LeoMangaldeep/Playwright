using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var playwrightDriver = await Playwright.CreateAsync();
        var chromium = await playwrightDriver.Chromium.LaunchAsync();
            }
}