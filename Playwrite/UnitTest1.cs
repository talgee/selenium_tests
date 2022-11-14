using Microsoft.Playwright;

namespace Playwrite
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
            using var playwrite = await Playwright.CreateAsync();
            await using var browser = await playwrite.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new string[] { "--start-maximized" }
            }) ;
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://www.asos.com");
            await page.Locator("//span[@type='accountUnfilled']").ClickAsync();
            await page.Locator("//a[@data-testid='signup-link']").ClickAsync();
            await page.FillAsync("id=Email", "abc123@gmail.com");
            await page.FillAsync("id=FirstName", "testFirst");
            await page.FillAsync("id=LastName", "testLast");
            await page.FillAsync("id=Password", "Aa1234567890");

            Thread.Sleep(10);
        }


    }
}