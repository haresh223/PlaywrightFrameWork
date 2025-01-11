using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Element
{
    public class WebElement
    {
        public IPage _page;
        public string _selector;

        public WebElement(IPage page, string selector)
        {
            _page = page;
            _selector = selector;
        }

        public async Task Click()
        {
            await _page.Locator(_selector).ClickAsync();
        }

        public async Task<string> GetText()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Get the text content of the element
                return await _element.TextContentAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }
        public async Task<string> GetInnerHtml()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Get the inner HTML of the element
                return await _element.InnerHTMLAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }
        public async Task<string> GetAttributeValue(string attributeName)
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Get the value of the specified attribute
                return await _element.GetAttributeAsync(attributeName);
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Wait for the element to become visible
        public async Task WaitForVisible()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Wait for the element to be visible
                await _element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Wait for the element to become hidden
        public async Task WaitForHidden()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Wait for the element to be hidden
                await _element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Hover over the element
        public async Task Hover()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Hover over the element
                await _element.HoverAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Scroll into view of the element
        public async Task ScrollIntoView()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Scroll the element into view
                await _element.ScrollIntoViewIfNeededAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        public async Task<bool> IsVisible()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Check if the element is visible
                return await _element.IsVisibleAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Check if the element is hidden
        public async Task<bool> IsHidden()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Check if the element is hidden
                return !(await _element.IsVisibleAsync());
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }
    }


    public class WebElements
    {
        public IPage _page;
        public string _selector;

        public WebElements(IPage page, string selector)
        {
            _page = page;
            _selector = selector;
        }

        // Get all matching elements
        private async Task<IEnumerable<ILocator>> GetElementsAsync()
        {
            if (_selector != null)
            {
                // Get all matching elements using the locator
                var elementsLocator = _page.Locator(_selector);

                // Use QuerySelectorAllAsync to get multiple elements
                var elementsCount = await elementsLocator.CountAsync();

                List<ILocator> elements = new List<ILocator>();
                for (int i = 0; i < elementsCount; i++)
                {
                    // Add each element to the list
                    elements.Add(elementsLocator.Nth(i));
                }
                return elements;
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The selector is null.");
            }
        }


        // Click all matching elements
        public async Task ClickAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.ClickAsync();
            }
        }

        // Get text of all matching elements
        public async Task<List<string>> GetTextAll()
        {
            var elements = await GetElementsAsync();
            List<string> texts = new List<string>();
            foreach (var element in elements)
            {
                texts.Add(await element.TextContentAsync());
            }
            return texts;
        }

        // Get inner HTML of all matching elements
        public async Task<List<string>> GetInnerHtmlAll()
        {
            var elements = await GetElementsAsync();
            List<string> innerHtmlList = new List<string>();
            foreach (var element in elements)
            {
                innerHtmlList.Add(await element.InnerHTMLAsync());
            }
            return innerHtmlList;
        }

        // Get attribute value for all matching elements
        public async Task<List<string>> GetAttributeValueAll(string attributeName)
        {
            var elements = await GetElementsAsync();
            List<string> attributeValues = new List<string>();
            foreach (var element in elements)
            {
                attributeValues.Add(await element.GetAttributeAsync(attributeName));
            }
            return attributeValues;
        }

        // Wait for all elements to become visible
        public async Task WaitForVisibleAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            }
        }

        // Wait for all elements to become hidden
        public async Task WaitForHiddenAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            }
        }

        // Hover over all elements
        public async Task HoverAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.HoverAsync();
            }
        }

        // Scroll all elements into view
        public async Task ScrollIntoViewAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.ScrollIntoViewIfNeededAsync();
            }
        }

        // Check if all elements are visible
        public async Task<List<bool>> IsVisibleAll()
        {
            var elements = await GetElementsAsync();
            List<bool> visibilityResults = new List<bool>();
            foreach (var element in elements)
            {
                visibilityResults.Add(await element.IsVisibleAsync());
            }
            return visibilityResults;
        }

        // Check if all elements are hidden
        public async Task<List<bool>> IsHiddenAll()
        {
            var elements = await GetElementsAsync();
            List<bool> hiddenResults = new List<bool>();
            foreach (var element in elements)
            {
                hiddenResults.Add(!(await element.IsVisibleAsync()));
            }
            return hiddenResults;
        }
    }
}


