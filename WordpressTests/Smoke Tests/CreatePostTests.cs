using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests : WordpressTest
    {
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            #region Manual test case
            //Go to login page
            //Login as “admin” user with correct password “ha tran”
            //Click Login button
            //Click Posts menu on the left nagivation panel
            //Click Add New button
            //Enter the post title “This is the post title”
            //Enter the post body “Hi, This is the post body”
            //Click “Publish…” button
            //Click “Publish” button
            //Click “View Post” button
            //Verify that the post is created by checking the title “This is the post title”
            #endregion Manual test case

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the post title")
                .WithBody("Hi, This is the post body")
                .Publish();
            NewPostPage.GoToNewPost();
            Assert.AreEqual(PostPage.NewPostTitle, "This is the post title", "Title did not match new post.");
        }
    }
}
