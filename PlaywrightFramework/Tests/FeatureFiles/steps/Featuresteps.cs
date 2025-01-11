using Microsoft.Playwright;
using PlaywrightFramework.Elements;
using PlaywrightFramework.Tests.PageClasses;
using Portal.Automation.Framework.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PlaywrightFramework.Tests.FeatureFiles.steps
{
    [Binding]
    public class Featuresteps
    {
        private readonly IPage _page;
        private readonly Browser _browser;
        private PageClass1 _pageClass1;
        private EnvironmentConfig _environmentConfig;
        // Constructor to initialize page and browser
        public Featuresteps(ScenarioContext scenarioContext,PageClass1 pageClass1,EnvironmentConfig environmentConfig)
        {
            _page = scenarioContext.Get<IPage>();
            _browser = new Browser(_page);  
            _pageClass1 = pageClass1;
            _environmentConfig = ConfigManager._environmentConfig;
        }
        [Given(@"User Navigate to login page")]
        public async Task GivenUserNavigateToLoginPage()
        {
            await _browser.NavigateToURL(_environmentConfig.baseUrl);
            Report.Instance.LogStepInfo("User navigate to URL");
        }

        [When(@"User enter spme value in login box")]
        public async Task WhenUserEnterSpmeValueInLoginBox()
        {
            await _pageClass1.EnterTextInTextBox();
        }



    }
}
