using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluxday.Automation.Tests.PageObject.OKRPage.AddNewOKR
{
    public class ObjectiveComponent
    {
        private IWebElement WebElementFromParent { get; }

        public ObjectiveComponent(IWebElement webElementFromParent)
        {
            WebElementFromParent = webElementFromParent;
        }

        protected IWebElement ObjectiveNameInput
        {
            get
            {
                return WebElementFromParent.FindElement(By.CssSelector("input"));
            }
        }

        protected IWebElement ObjectiveDeleteButton
        {
            get
            {
                return WebElementFromParent.FindElement(By.CssSelector(".remove-links"));
            }
        }

        protected IWebElement KeyResultsDiv
        {
            get
            {
                return WebElementFromParent.FindElement(By.Id("key_results"));
            }
        }

        protected IReadOnlyCollection<IWebElement> AllKeyResultsDivs
        {
            get
            {
                return WebElementFromParent.FindElements(By.ClassName("nested-fields"));
            }
        }

        protected IWebElement AddNewKeyResultButton
        {
            get
            {
                return WebElementFromParent.FindElement(By.ClassName("add_fields"));
            }
        }

        public List<KeyResultComponent> GetAllKeyResults()
        {
            return AllKeyResultsDivs.Select(x => new KeyResultComponent(x))
                                    .ToList();
        }

        public int GetAllKeyResultsCount()
        {
            return GetAllKeyResults().Count;
        }

        public void SetInputObjectiveName(string objectiveName)
        {
            ObjectiveNameInput.Click();
            ObjectiveNameInput.Clear();
            ObjectiveNameInput.SendKeys(objectiveName);
        }

        public KeyResultComponent GetKeyResultByIndex(int indexOfKeyResult)
        {
            var allKeyresults = GetAllKeyResults();
            if (indexOfKeyResult >= 0 && indexOfKeyResult < allKeyresults.Count && allKeyresults.Count != 0)
            {
                return allKeyresults[indexOfKeyResult];
            }
            else
            {
                throw new IndexOutOfRangeException($"Index {indexOfKeyResult} is out of range.");
            }
        }

        public void SetObjective(string objectiveName, string[] keyResultNames)
        {
            SetInputObjectiveName(objectiveName);
            var allKeyResults = GetAllKeyResults();
            var allKeyResultCount = allKeyResults.Count();
            if (keyResultNames != null)
            {
                if (keyResultNames.Length <= allKeyResultCount)
                {
                    for (int i = 0; i < keyResultNames.Length; i++)
                    {
                        allKeyResults[i].SetKeyResult(keyResultNames[i]);
                    }
                }
                else
                {
                    throw new ArgumentException($"Length of parameter \"keyResultNames\" is  more, " +
                                                $"then count of inputs for Key Result's names", "keyResultNames");
                }
            }
        }

        public void SetNewObjectiveWithKeyResults(string objectiveName, List<string> keyResultNames)
        {
            SetInputObjectiveName(objectiveName);
            keyResultNames.ForEach(x => ClickOnNewKeyResultButton()
                          .SetKeyResult(x));
        }

        public KeyResultComponent ClickOnNewKeyResultButton()
        {
            AddNewKeyResultButton.Click();
            return GetAllKeyResults().Last();
        }

        public void ClickOnDeleteObjectiveButton()
        {
            ObjectiveDeleteButton.Click();
        }

        public List<KeyResultComponent> DeleteKeyResultByIndex(int indexOfKeyResult)
        {
            var allKeyResult = GetAllKeyResults();
            allKeyResult[indexOfKeyResult].ClickOnDeleteKeyResultButton();
            return GetAllKeyResults();
        }
    }
}
