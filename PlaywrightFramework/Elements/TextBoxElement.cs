using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Elements
{
    
    public class TextBoxElement
    {
        public IPage page;
        public string selector;

        public TextBoxElement(IPage page, string selector)
        {
            this.page = page;
            this.selector = selector;
        }

        public async Task EnterText(string text)
        {
            
            ILocator locator = page.Locator(selector);
            await locator.FillAsync(text);
        }
        public async Task EnterTextAndPressEnter(string text)
        {

            ILocator locator = page.Locator(selector);
            await locator.FillAsync(text);
            await locator.PressAsync("Enter");
        }
        public async Task ClearText()
        {

            ILocator locator = page.Locator(selector);
            await locator.FillAsync("");
        }

    }
}
