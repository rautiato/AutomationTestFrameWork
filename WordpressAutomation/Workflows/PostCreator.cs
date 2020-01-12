using System;
using System.Text;

namespace WordpressAutomation.Workflows
{
    public class PostCreator
    {
        public static string PreviousTitle { get; set; }
        public static string PreviousBody { get; set; }
        public static bool createdAPost
        {
            get {return !String.IsNullOrEmpty(PreviousTitle);}
        }
        public static void CreatePost()
        {
            NewPostPage.GoTo();
            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();
            NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();
        }
        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }
        public static void CleanUp()
        {
            if (createdAPost)
            {
                TrashPost();
            }
        }
        private static void TrashPost()
        {
            ListPostsPage.TrashPost(PreviousTitle);
            Initialize();
        }

        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }
        private static string CreateTitle()
        {
            return CreateRandomString() + ", title";
        }
        private static string CreateRandomString()
        {
            var s = new StringBuilder();
            var random = new Random();
            var cycles = random.Next(5 + 1);
            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
            }
            return s.ToString();
        }

        private static string[] Words = new[]
        {
            "boy", "cat", "dog", "rabbit", "baseball", "throw", "find", "mustard"
        };

        private static string[] Articles = new[]
        {
            "the", "and", "and", "a", "of", "to", "it", "as"
        };
    }
}