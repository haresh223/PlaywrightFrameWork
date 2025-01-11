using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaywrightFramework.Element
{
    public class CheckboxElement
    {
        private readonly IPage _page;
        private readonly string _selector;

        public CheckboxElement(IPage page, string selector)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page), "Page cannot be null.");
            _selector = selector ?? throw new ArgumentNullException(nameof(selector), "Selector cannot be null.");
        }

        private async Task<ILocator> GetLocatorAsync()
        {
            return _page.Locator(_selector);
        }

        public async Task Check()
        {
            var element = await GetLocatorAsync();

            if (!await element.IsCheckedAsync())
            {
                await element.CheckAsync();  // Check the checkbox if it's unchecked
            }
        }

        public async Task Uncheck()
        {
            var element = await GetLocatorAsync();

            if (await element.IsCheckedAsync())
            {
                await element.UncheckAsync();  // Uncheck the checkbox if it's checked
            }
        }

        public async Task<bool> IsChecked()
        {
            var element = await GetLocatorAsync();
            return await element.IsCheckedAsync();
        }

        public async Task<string> GetLabelText()
        {
            var element = await GetLocatorAsync();
            var label = await element.Locator("xpath=./following-sibling::label").TextContentAsync();
            return label ?? throw new InvalidOperationException("Label text could not be found.");
        }
    }

    public class CheckboxElements
    {
        private readonly IPage _page;
        private readonly string _selector;

        public CheckboxElements(IPage page, string selector)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page), "Page cannot be null.");
            _selector = selector ?? throw new ArgumentNullException(nameof(selector), "Selector cannot be null.");
        }

        private async Task<IEnumerable<ILocator>> GetElementsAsync()
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

        // Check all checkboxes
        public async Task CheckAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                if (!await element.IsCheckedAsync())
                {
                    await element.CheckAsync();  // Check the checkbox if it's unchecked
                }
            }
        }

        // Uncheck all checkboxes
        public async Task UncheckAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                if (await element.IsCheckedAsync())
                {
                    await element.UncheckAsync();  // Uncheck the checkbox if it's checked
                }
            }
        }

        // Get whether each checkbox is checked
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

        // Get labels of all checkboxes
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

        // Check if all checkboxes are visible
        public async Task<bool> AreVisibleAll()
        {
            var elements = await GetElementsAsync();
            List<bool> visibilityResults = new List<bool>();
            foreach (var element in elements)
            {
                visibilityResults.Add(await element.IsVisibleAsync());
            }
            return visibilityResults.All(v => v);  // Check if all are visible
        }

        // Wait for all checkboxes to be checked
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

        // Wait for all checkboxes to be unchecked
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

        // Wait for all checkboxes to be visible
        public async Task WaitForVisibleAll()
        {
            var elements = await GetElementsAsync();
            foreach (var element in elements)
            {
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            }
        }

        // Wait for all checkboxes to be hidden
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
