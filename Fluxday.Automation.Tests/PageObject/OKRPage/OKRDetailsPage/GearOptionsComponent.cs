using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.OKRDetailsPage
{
    public class GearOptionsComponent
    {
        private IWebElement WebElementParent { get; }

        public GearOptionsComponent(IWebElement webElementParent)
        {
            WebElementParent = webElementParent;
        }

        protected IReadOnlyCollection<IWebElement> Items
        {
            get
            {
                return WebElementParent.FindElements(By.CssSelector("li"));
            }
        }

        public void ItemClick(string itemTitle)
        {
            var searchItem = Items.FirstOrDefault(x => x.Text.ToUpper() == itemTitle.ToUpper())
                ?? throw new NoSuchElementException($"Item not found: {itemTitle}");
            searchItem.Click();
        }
    }
}
