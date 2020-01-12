using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WordpressAutomation
{
    public class ListPostsPage
    {
        private static int lastCount;
        public static int PreviousPostsCount { get { return lastCount; } }
        public static int CurrentPostsCount { get { return GetPostsCount(); } }

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;
                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }

        public static void SelectPost(string title)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
            var postPageList = wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.Id("the-list")));
            //var postPageList = Driver.Instance.FindElement(By.Id("the-list"));
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page")); //This does not work
            //var postLink = Driver.Instance.FindElement(By.XPath("//a[@class = 'row-title' and text() = 'Sample Page']"));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostsCount();
        }

        private static int GetPostsCount()
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(40));
            var countText = wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.ClassName("displaying-num"))).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            //find any element that matches the title
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));//Find all the rows
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                links = row.FindElements(By.LinkText(title));//look through each row and try to find any element that matches the title
                if(links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);//use Actions class for hover over action
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;//return down to there because we found the one that we were looking for
                }
            }
        }

        public static void SearchForPosts(string searchString)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
            var searchInput = wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.Id("post-search-input")));
            searchInput.SendKeys(searchString);
            var searchPostsButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchPostsButton.Click();
        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}