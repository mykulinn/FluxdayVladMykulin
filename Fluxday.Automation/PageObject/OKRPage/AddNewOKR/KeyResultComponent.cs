using OpenQA.Selenium;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.AddNewOKR
{
    public class KeyResultComponent
    {
        private IWebElement WebElementParent { get; }

        public KeyResultComponent(IWebElement webElementParent)
        {
            WebElementParent = webElementParent;
        }

        protected IWebElement InputKeyResultName
        {
            get
            {
                return WebElementParent.FindElement(By.CssSelector("input"));
            }
        }

        protected IWebElement DeleteButtonKeyResult
        {
            get
            {
                return WebElementParent.FindElement(By.XPath("//*[@id='key_results']/div[1]/div/div[1]/child :: a"));
            }
        }

        public void SetKeyResult(string keyResultName)
        {
            InputKeyResultName.Click();
            InputKeyResultName.Clear();
            InputKeyResultName.SendKeys(keyResultName);
        }

        public void ClickOnDeleteKeyResultButton()
        {
            DeleteButtonKeyResult.Click();
        }

        public void ClearKeyResultName()
        {
            InputKeyResultName.Clear();
        }
    }
}
