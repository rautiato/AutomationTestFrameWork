using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
            wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.XPath("//a[@class = 'components-button is-button is-default' and (text() = 'View Post')]")))
                .Click();
        }
        public static bool IsInEditMode()
        {
            var viewPageLink = Driver.Instance.FindElement(By.XPath("//a[@class = 'ab-item' and text() = 'View Page']"));
            bool isViewPageLinkVisible = viewPageLink.Displayed;
            if (isViewPageLinkVisible)
                return isViewPageLinkVisible;
            return false;
        }

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement((By.Id("post-title-0")));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }
    }

    public class CreatePostCommand
    {
        private string title;
        private string body;
        public CreatePostCommand(string title)
        {
            this.title = title;
        }
        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Thread.Sleep(3000);
            bool isDisableTipsDisplayed = Driver.Instance.FindElement(By.XPath("//button[@aria-label = 'Disable tips']")).Displayed;
            if (isDisableTipsDisplayed)
            {
                Driver.Instance.FindElement(By.XPath("//button[@aria-label = 'Disable tips']")).Click();
            }
            Driver.Instance.FindElement(By.Id("post-title-0")).SendKeys(title);

            //#region Enter the body post //These codes don't work
            ////Driver.Instance.FindElement(By.XPath("//div[@class='editor-block-list__layout block-editor-block-list__layout']")).SendKeys(body);

            ////var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            ////wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.XPath("//div[@class='editor-block-list__layout block-editor-block-list__layout']"))).SendKeys(body);
            //#endregion Enter the body post

            //#region Enter the body post //These codes work
            ////IJavaScriptExecutor jscript = Driver.Instance as IJavaScriptExecutor;
            ////var postBody = Driver.Instance.FindElement(By.XPath("//div[@class='editor-block-list__layout block-editor-block-list__layout']"));
            ////IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.Instance;
            ////executor.ExecuteScript("arguments[0].innerHTML = 'hello body post via javascript'", postBody);
            //#endregion

            IWebElement postBody = Driver.Instance.FindElement(By.XPath("//div[@class='editor-block-list__layout block-editor-block-list__layout']"));
            Actions actions = new Actions(Driver.Instance);
            actions.MoveToElement(postBody);
            actions.Click();
            actions.SendKeys(body);
            actions.Build().Perform();

            Driver.Instance.FindElement(By.XPath("//button[text() = 'Publish…']")).Click();
            Driver.Instance.FindElement(By.XPath("//button[text() = 'Publish']")).Click();
        }
    }
}