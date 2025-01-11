using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Elements
{
    public class WebElement
    {
        public string selector;
        public IPage page;
        public WebElement(IPage _page,string _selector)
        {
            selector = _selector;
            page = _page;
        }

        public async Task Click()
        {
            //page , selector
            // for click playwright use ClickAsync  
            await page.Locator(selector).ClickAsync();
        }

        public async Task<string> GetText()
        {
            ILocator locator = page.Locator(selector);
            return await locator.TextContentAsync();
        }
    }
}
