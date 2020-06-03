using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Comment
{
    class Program
    {
        static void Main(string[] args)
        {
            var webDriver = LaunchBrowser();
            try
            {
                var facebookAutomation = new FacebookAutomation(webDriver);
                facebookAutomation.Login(Environment.GetEnvironmentVariable("email"), Environment.GetEnvironmentVariable("pass"));
                var comment = new CommentOnDenisPage(webDriver);

                for (int i = 0; i < 10000; i++)
                {
                    comment.Comment($"comentario {i}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing automation");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                webDriver.Quit();
            }
        }
        static IWebDriver LaunchBrowser()
        {
            var options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            var driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            return driver;
        }
    }
}