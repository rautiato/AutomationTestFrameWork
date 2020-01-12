using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests
{
    [TestClass]
    public class AllPostsTests : WordpressTest
    {
        #region Brainstorm test cases
        //Added posts show up in all posts
        //Can activate excerpt mode
        //Can add new post

        //Single post selections:

        //Can select a post by title
        //Can select a post by Edit
        //Can select a post by Quick Edit
        //Can trash a post
        //Can view a post
        //Can filter by author
        //Can filter by category
        //Can filter by tag
        //Can go to posts comments

        //Bulk actions:

        //Can edit multiple posts
        //Can select all posts

        //Drop down filters:

        //Can filter by months
        //Can filter by category
        //Can view published only
        //Can view draft only
        //Can view trash only

        //Can search posts

        //pickup the following tests to create automated test case:

        //Added posts show up in all posts
        //Can trash a post
        //Can search a post
        #endregion
        [TestMethod]
        public void Added_Post_Show_Up()
        {
            #region Manual test case
            //Go to login page
            //Login as “admin” user with correct password “ha tran”
            //Click Login button
            //Hover mouse on the “Posts” menu on the left navigation panel
            //Click “All Posts” menu
            //Observe and record the posts count at the top right corner of the posts list
            //Add a new post and publish it
            //Go to All Posts list
            //Verify that the posts count increase by 1
            //Verify that the added post exists in the list
            #endregion Manual test case
            //Go to Posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            //Add a new post
            PostCreator.CreatePost();
            //Go to Posts, get new post count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostsCount + 1, ListPostsPage.CurrentPostsCount, "Count of posts didn't increase");

            //Check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            //Trash post(clean up)
            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostsCount, ListPostsPage.CurrentPostsCount, "Couldn't trash post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            #region Manual test case
            //Go to login page
            //Login as “admin” user with correct password “ha tran”
            //Click Login button
            //Hover mouse on the “Posts” menu on the left navigation panel
            //Click “All Posts” menu
            //Enter a search string that matches to at least a post title to the Search text box
            //Click “Search Posts” button
            //Verify that the matching post titles show up in the list
            #endregion Manual test case

            //Create a new post
            PostCreator.CreatePost();

            //Go to list posts
            ListPostsPage.GoTo(PostType.Posts);

            //Search for posts
            ListPostsPage.SearchForPosts(PostCreator.PreviousTitle);

            //Check that post show up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }
    }
}
