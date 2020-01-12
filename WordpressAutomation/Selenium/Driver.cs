using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseAddress
        {
            get { return "http://localhost:84/selenium/"; }
        }
        static string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        static string relativeDriverPath = @"..\WebBrowserDrivers";
        public static void Initialize()
        {
            //Instance = new FirefoxDriver(Path.GetFullPath(Path.Combine(projectPath, relativeDriverPath);
            Instance = new ChromeDriver(Path.GetFullPath(Path.Combine(projectPath, relativeDriverPath)));
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}