using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightFramework.SetUpClasses
{
    [Binding]
    public class BrowserAsync
    {
        public IBrowser Browser { get; set; }
        public static IPage page {  get; set; }
        public async Task InitilizeAsync()
        {
            // initiate browser
            var browserType = ConfigManager._environmentConfig.browserType;
            var playwright = await Playwright.CreateAsync();
            //Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            //{
            //    Headless = false,
            //});

            switch (browserType.ToLower())
            {
                case "chrome":
                    Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false
                    });
                    break;

                case "firefox":
                    Browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false
                    });
                    break;

                case "webkit":
                    Browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = false
                    });
                    break;

                case "edge":
                    Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Channel = "msedge",
                        Headless = false
                    });
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser type: {browserType}");
            }

            page = await Browser.NewPageAsync();
            
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenarioContext.Set(page);  
        }

        public async Task DisposeAsync()
        {
            //dispose browser
            if(Browser != null)
            {
                await Browser.DisposeAsync();
            }
        }
    }
}
