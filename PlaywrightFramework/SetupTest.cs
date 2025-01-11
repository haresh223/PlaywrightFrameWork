using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework
{
    public class SetupTest
    {
        [SetUp]
        public async Task setupAsync()
        {
            var playwright = await Playwright.CreateAsync();
            //var browser  = await playwright.Chromium.LaunchAsync();  // To run chrome headless

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var page =  await browser.NewPageAsync();
            await page.GotoAsync("https://www.google.co.in/");

        }

        [Test]
        public async Task Test1()
        {
            Console.WriteLine("Hi Test run successfull");
        }

    }
}
