using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class LoginTests : WordpressTest
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            #region Manual test case
            //Go to login page
            //Login as “admin” user with correct password “ha tran”. Click Login button
            //Verify that user can login, the Dashboard page is displayed
            #endregion Manual test case

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }
    }
}
