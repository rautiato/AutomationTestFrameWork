using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class PageTests : WordpressTest
    {
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            #region Manual test case
            //Go to login page
            //Login as “admin” user with correct password “ha tran”
            //Click Login button
            //Hover mouse on the “Pages” menu on the left navigation panel
            //Click “All Pages” menu
            //Click on the page post having title “Sample Page”
            //Verify that the page post is edit mode by checking visibility of the “View Page” button
            //Verify that the page title is “Sample Page”
            #endregion

            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");
            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title didn't match");
        }
    }
}
