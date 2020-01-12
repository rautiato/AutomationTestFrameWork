using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests
{
    public class WordpressTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            PostCreator.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("admin").WithPassword("hatran").Login();
        }

        [TestCleanup]
        public void CleanUp()
        {
            PostCreator.CleanUp();
            Driver.Close();
        }
    }
}
