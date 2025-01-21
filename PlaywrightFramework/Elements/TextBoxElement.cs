using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Element
{
    public class TextBoxElement
    {
        public IPage _page;
        public string _selector;

        public TextBoxElement(IPage page, string selector)
        {
            _page = page;
            _selector = selector;
        }

        public async Task EnterText(string text)
        {
            if (_selector != null)
            {
                // Clear the existing text and enter the new text
                ILocator _element = _page.Locator(_selector);

                // Fill the input field with the provided text
                await _element.FillAsync(text);
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element to enter text is null.");
            }
        }

        public async Task EnterTextAndPressEnter(string text)
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Clear the existing text and enter the new text
                await _element.FillAsync(text);

                // Press the Enter key after entering the text
                await _element.PressAsync("Enter");
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element to enter text is null.");
            }
        }

        public async Task EnterWordsOneByOne(string text, int delayMilliseconds = 500)
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Split the text into words
                var words = text.Split(' ');

                foreach (var word in words)
                {
                    // Type each word and wait for the specified delay
                    await _element.FillAsync(word);
                    await Task.Delay(delayMilliseconds); // Adding delay to mimic typing

                    // Optionally, you can press a space key after each word to simulate a real typing action
                    await _element.PressAsync("Space");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element to enter words is null.");
            }
        }
        public async Task ClearText()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Clear the text in the input field
                await _element.FillAsync("");  // Fill with an empty string to clear
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element to clear text is null.");
            }
        }

        public async Task<string> GetPlaceholderText()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Get the placeholder attribute value
                return await _element.GetAttributeAsync("placeholder");
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        public async Task<bool> IsTextboxEmpty()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Get the text content and check if it's empty
                var textContent = await _element.InputValueAsync();
                return string.IsNullOrWhiteSpace(textContent);
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        public async Task<string> GetCurrentValue()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Retrieve the current value of the input field
                return await _element.InputValueAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }
        public async Task<bool> IsTextboxDisabled()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Check if the input is disabled
                var disabled = await _element.GetAttributeAsync("disabled");
                return disabled != null;
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        public async Task<bool> IsTextboxReadOnly()
        {
            if (_selector != null)

            {
                ILocator _element = _page.Locator(_selector);

                // Check if the input is readonly
                var readonlyAttribute = await _element.GetAttributeAsync("readonly");
                return readonlyAttribute != null;
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

    }

    public class TextElements
    {
        public IPage _page;
        public string _selector;

        public TextElements(IPage page, string selector)
        {
            _page = page;
            _selector = selector;
        }

        // Get all matching text input elements
        public async Task<IEnumerable<ILocator>> GetElementsAsync()
        {
            if (_selector != null)
            {
                var elementsLocator = _page.Locator(_selector);
                var elementsCount = await elementsLocator.CountAsync();

                List<ILocator> elements = new List<ILocator>();
                for (int i = 0; i < elementsCount; i++)
                {
                    elements.Add(elementsLocator.Nth(i));
                }
                return elements;
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The selector is null.");
            }
        }

        // Enter text into all matching elements
        public async Task EnterTextAll(string text)
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.FillAsync(text);
            }
        }

        // Enter text and press Enter in all matching elements
        public async Task EnterTextAndPressEnterAll(string text)
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.FillAsync(text);
                await element.PressAsync("Enter");
            }
        }

        // Clear text in all matching elements
        public async Task ClearTextAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.FillAsync("");
            }
        }

        // Check if all textboxes are empty
        public async Task<List<bool>> IsTextboxEmptyAll()
        {
            var elements = await GetElementsAsync();
            List<bool> results = new List<bool>();
            foreach (var element in elements)
            {
                var text = await element.InputValueAsync();
                results.Add(string.IsNullOrWhiteSpace(text));
            }
            return results;
        }

        // Get current value for all matching elements
        public async Task<List<string>> GetCurrentValueAll()
        {
            var elements = await GetElementsAsync();
            List<string> values = new List<string>();
            foreach (var element in elements)
            {
                values.Add(await element.InputValueAsync());
            }
            return values;
        }
    }
}
