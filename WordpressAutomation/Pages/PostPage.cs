using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class PostPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("post-title-0"));
                if (title != null)
                    return title.Text;
                return string.Empty;
            }
        }
        public static object NewPostTitle
        {
            get
            {
                //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30));
                //var title = wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.Id("post-title-0")));
                var newPostTitle = Driver.Instance.FindElement(By.XPath("//h1[text() = 'This is the post title']"));
                if (newPostTitle != null)
                    return newPostTitle.Text;
                return string.Empty;

            }
        }
        public static string Body
        {
            get
            {
                var body = Driver.Instance.FindElement(By.XPath("//div[@class='components-autocomplete']/p[@aria-label='Paragraph block']"));
                if (body != null)
                    return body.Text;
                return string.Empty;
            }
        }

        //public static void ViewAPost(string postTitle)//don't know how to locate a title getting from parameter
        public static void ViewAPost()
        {
            var postList = Driver.Instance.FindElement(By.Id("the-list"));
            var postLink = postList.FindElements(By.TagName("a"))[0];
            //var postLink = postList.FindElement(By.LinkText(postTitle));//don't know how to locate a title getting from parameter
            postLink.Click();
        }

        public static void GoTo()
        {
            var menuPosts = Driver.Instance.FindElement(By.XPath("//div[@class='wp-menu-name' and text() = 'Posts']"));
            menuPosts.Click();
        }
    }
}