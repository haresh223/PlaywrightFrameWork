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
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
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
