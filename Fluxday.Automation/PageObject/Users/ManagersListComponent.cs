using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.Users
{
    public class ManagersListComponent
    {
        private IWebElement ParentElement { get; }

        public ManagersListComponent(IWebElement parentElement)
        {
            ParentElement = parentElement;
        }

        protected IReadOnlyCollection<IWebElement> ManagersList
        {
            get
            {
                return ParentElement.FindElements(By.XPath("//*[@id='select2-drop']/ul/li[not(contains(@class, 'selected'))]/div"));
            }
        }

        public void SelectManager(string manager)
        {
            var desiredManager = ManagersList.FirstOrDefault(x => x.Text.ToUpper() == manager.ToUpper())
                ?? throw new NoSuchElementException($"No such manager found:{manager}");
            desiredManager.Click();
        }

        // We are trying to choose the desired manager name according to the Test Case.
        // In the absence of the desired manager in the list, we select any first manager
        // from the list. In the case of an empty list, we leave the manager name empty "".
        public string ManagerNameFromList(string desiredName)
        {
            return ManagersList.Any()
                       ? (ManagersList.Any(x => x.Text == desiredName)
                              ? desiredName
                              : ManagersList.FirstOrDefault().Text)
                       : "";
        }

        public void FillInManager(string manager)
        {
            if (manager != "")
            {
                SelectManager(manager);
            }
        }
    }
}