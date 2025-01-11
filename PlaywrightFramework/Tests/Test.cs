using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightFramework.Element;
using PlaywrightFramework.Elements;
using PlaywrightFramework.SetUpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Tests
{
    internal class Test
    {
        public IPage page = BrowserAsync.page;
        public Browser browser => new Browser(page);

         public WebElement element => browser.FindWebElement("button[type='submit']");   // buttons or divisions etc so our main motive here to click or get text
        public TextBoxElement textElement => browser.FindTextBoxElement("input[type='email']");  // insert text or clear text or insert value and press enter etc


        [Test]
        public async Task test2()
        {
            await browser.NavigateToURL("https://uat-members.sacsconsult.com.au/login");
            await textElement.EnterTextAndPressEnter("some Text");
            await textElement.ClearText();
            var elementText = await element.GetText();   // to get text
            await element.Click();

            //  how to find selectors in playwright
             await page.Locator("input[type='email']").FillAsync("some Text");
             

        }
    }
}
