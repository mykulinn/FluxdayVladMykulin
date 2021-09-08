using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject
{
    public static class PageObjectExtensions
    {
        public static void FillInInput(this IWebElement iWebElement, string inputText)
        {
            iWebElement.Click();
            iWebElement.Clear();
            iWebElement.SendKeys(inputText);
        }
    }
}
