namespace WordpressAutomation
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AllPosts
            {
                public static void Select()
                {
                    MenuSelector.Select("//div[@class = 'wp-menu-name' and text() = 'Posts']", "//a[@class = 'wp-first-item' and text() = 'All Posts']");
                }
            }
            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("//div[@class='wp-menu-name' and text() = 'Posts']", "//a[text() = 'Add New']");
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    MenuSelector.Select("//div[@class = 'wp-menu-name' and text() = 'Pages']", "//a[@class = 'wp-first-item' and text() = 'All Pages']");
                }
            }
        }
    }
}