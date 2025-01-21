using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Element
{
    public class RadioElement
    {
        public IPage _page;
        public string _selector;

        public RadioElement(IPage page, string selector)
        {
            _page = page;
            _selector = selector;
        }
        public async Task Select()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Check if it's already selected, if not, select it
                var isSelected = await _element.IsCheckedAsync();
                if (!isSelected)
                {
                    await _element.CheckAsync();  // Select the radio button
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element to select is null.");
            }
        }

        // Deselect the radio button
        // Although typically radio buttons can't be deselected manually by the user, 
        // this can be used in some specific cases where you want to uncheck it programmatically.
        public async Task Deselect()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Check if it's already selected, if so, unselect it
                var isSelected = await _element.IsCheckedAsync();
                if (isSelected)
                {
                    await _element.UncheckAsync();  // Unselect the radio button (if possible)
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element to deselect is null.");
            }
        }

        // Get the current state (checked or unchecked) of the radio button
        public async Task<bool> IsChecked()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Return whether the radio button is selected
                return await _element.IsCheckedAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Wait for the radio button to be checked (selectable)
        public async Task WaitForChecked()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Wait until the radio button is checked
                while (!await _element.IsCheckedAsync())
                {
                    await Task.Delay(100); // Poll every 100ms until checked
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Wait for the radio button to be unchecked (deselectable)
        public async Task WaitForUnchecked()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Wait until the radio button is unchecked
                while (await _element.IsCheckedAsync())
                {
                    await Task.Delay(100); // Poll every 100ms until unchecked
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Get the value of the radio button (useful when dealing with forms)
        public async Task<string> GetValue()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Get the value of the selected radio button
                return await _element.GetAttributeAsync("value");
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Get the label text associated with the radio button
        public async Task<string> GetLabelText()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Get the label for the radio button, assuming the label is nearby
                var label = await _element.Locator("xpath=./following-sibling::label").TextContentAsync();
                return label;
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Hover over the radio button (useful for UI testing)
        public async Task Hover()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Hover over the radio button element
                await _element.HoverAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Wait for the radio button to be visible
        public async Task WaitForVisible()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Wait for the radio button to be visible
                await _element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }

        // Wait for the radio button to be hidden
        public async Task WaitForHidden()
        {
            if (_selector != null)
            {
                ILocator _element = _page.Locator(_selector);

                // Wait for the radio button to be hidden
                await _element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            }
            else
            {
                throw new ArgumentNullException(nameof(_selector), "The element is null.");
            }
        }
    }

    public class RadioElements
    {
        public IPage _page;
        public string _selector;

        public RadioElements(IPage page, string selector)
        {
            _page = page;
            _selector = selector;
        }

        // Get all matching radio button elements
        private async Task<IEnumerable<ILocator>> GetElementsAsync()
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

        // Select all matching radio buttons
        public async Task SelectAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                var isSelected = await element.IsCheckedAsync();
                if (!isSelected)
                {
                    await element.CheckAsync();
                }
            }
        }

        // Deselect all matching radio buttons
        public async Task DeselectAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                var isSelected = await element.IsCheckedAsync();
                if (isSelected)
                {
                    await element.UncheckAsync();  // Unselect the radio button (if possible)
                }
            }
        }

        // Check if all radio buttons are selected
        public async Task<List<bool>> AreCheckedAll()
        {
            var elements = await GetElementsAsync();
            List<bool> results = new List<bool>();
            foreach (var element in elements)
            {
                results.Add(await element.IsCheckedAsync());
            }
            return results;
        }

        // Wait for all radio buttons to be checked
        public async Task WaitForCheckedAll()

        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                while (!await element.IsCheckedAsync())
                {
                    await Task.Delay(100); // Poll every 100ms until checked
                }
            }
        }

        // Wait for all radio buttons to be unchecked
        public async Task WaitForUncheckedAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                while (await element.IsCheckedAsync())
                {
                    await Task.Delay(100); // Poll every 100ms until unchecked
                }
            }
        }

        // Get values of all radio buttons
        public async Task<List<string>> GetValuesAll()
        {
            var elements = await GetElementsAsync();
            List<string> values = new List<string>();
            foreach (var element in elements)
            {
                values.Add(await element.GetAttributeAsync("value"));
            }
            return values;
        }

        // Get labels of all radio buttons
        public async Task<List<string>> GetLabelTextsAll()
        {
            var elements = await GetElementsAsync();
            List<string> labels = new List<string>();
            foreach (var element in elements)
            {
                var label = await element.Locator("xpath=./following-sibling::label").TextContentAsync();
                labels.Add(label);
            }
            return labels;
        }

        // Hover over all radio buttons
        public async Task HoverAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.HoverAsync();
            }
        }

        // Wait for all radio buttons to be visible
        public async Task WaitForVisibleAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            }
        }

        // Wait for all radio buttons to be hidden
        public async Task WaitForHiddenAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            }
        }
    }
}
