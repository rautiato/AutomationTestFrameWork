using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WordpressAutomation
{
    public class MenuSelector
    {
        public static void Select(string firstLevelMenu, string secondLevelMenu)
        {
            //locate element by mouse hovering
            var firstMenuLevel = Driver.Instance.FindElement(By.XPath(firstLevelMenu));
            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(firstMenuLevel).Perform();
            var secondMenuLevel = Driver.Instance.FindElement(By.XPath(secondLevelMenu));
            action.MoveToElement(secondMenuLevel).Click().Perform();
        }
    }
}