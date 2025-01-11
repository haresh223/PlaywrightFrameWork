using Microsoft.Playwright;
using PlaywrightFramework.Element;

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
        public RadioElement FindRadioElement(string selector)
        {
            return new RadioElement(page, selector);
        }

        public CheckboxElement FindCheckboxElement(string selector)
        {
            return new CheckboxElement(page, selector);
        }
        public WebElements FindWebElements(string selector)
        {
            return new WebElements(page, selector);
        }
        public TextElements FindTextElements(string selector)
        {
            return new TextElements(page, selector);
        }
        public RadioElements FindRadioElements(string selector)
        {
            return new RadioElements(page, selector);
        }
        public CheckboxElements FindCheckboxElements(string selector)
        {
            return new CheckboxElements(page, selector);
        }
    }

}