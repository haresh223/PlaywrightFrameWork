using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Elements
{
    public class Browser
    {
        public IPage page;
        public Browser(IPage _page)
        {
            page = _page;
        }

        public async Task NavigateToURL(string url)
        {
            await page.GotoAsync(url);
        }

        public WebElement FindWebElement(string selector)
        {
            return new WebElement(page, selector);
        }

        public TextBoxElement FindTextBoxElement(string selector)
        {
            return new TextBoxElement(page, selector);
        }

    }
}