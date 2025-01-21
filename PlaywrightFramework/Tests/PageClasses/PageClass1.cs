using PlaywrightFramework.Element;
using PlaywrightFramework.Elements;
using PlaywrightFramework.SetUpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework.Tests.PageClasses
{
    public class PageClass1
    {
        public Browser browser => new Browser(BrowserAsync.page);

        public TextBoxElement textBoxElement => browser.FindTextBoxElement("input[type='email']");
        internal async Task EnterTextInTextBox()
        {
           await textBoxElement.EnterText("bhutramohit");
        }
    }
}
