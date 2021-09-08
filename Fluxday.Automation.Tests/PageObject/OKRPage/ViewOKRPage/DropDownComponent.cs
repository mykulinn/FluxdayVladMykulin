using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.ViewOKRPage
{
    public class DropDownComponent
    {
        private IWebElement WebElementParent { get; }

        public DropDownComponent(IWebElement webElementParent)
        {
            WebElementParent = webElementParent;
        }

        protected IWebElement DropDownInput
        {
            get
            {
                return WebElementParent.FindElement(By.CssSelector(".select2-search>input"));
            }
        }

        protected IReadOnlyCollection<IWebElement> DropDownItems
        {
            get
            {
                return WebElementParent.FindElements(By.CssSelector(".select2-results>li"));
            }
        }

        public void FillDropDownInput(string searchItem)
        {
            DropDownInput.Click();
            DropDownInput.Clear();
            DropDownInput.SendKeys(searchItem);
            DropDownInput.SendKeys(Keys.Enter);
        }

        public void DropDownItemClick(string item)
        {
            var searchTeamMember = DropDownItems.FirstOrDefault(x => x.Text.ToUpper() == item.ToUpper())
                 ?? throw new NoSuchElementException($"Item not found: {item}");
            searchTeamMember.Click();
        }
    }
}
