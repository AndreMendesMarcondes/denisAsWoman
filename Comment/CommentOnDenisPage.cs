using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace Comment
{
    public class CommentOnDenisPage
    {
        private readonly IWebDriver webDriver;

        public CommentOnDenisPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Comment(string comentario)
        {
            webDriver.Url = "https://m.facebook.com/story.php?story_fbid=2660605310929313&id=100009396100053";

            var input = webDriver.FindElement(By.Id("composerInput"));
            input.SendKeys(comentario);
            Thread.Sleep(500);
            ClickAndWaitForPageToLoad(webDriver, By.Name("submit"));

            try
            {
                while (webDriver.FindElement(By.Id("checkpointSubmitButton")) != null)
                {
                    ClickAndWaitForPageToLoad(webDriver, By.Id("checkpointSubmitButton"));
                }
            }
            catch
            {
            }
        }

        private void ClickAndWaitForPageToLoad(IWebDriver driver,
         By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var elements = driver.FindElements(elementLocator);
                if (elements.Count == 0)
                {
                    throw new NoSuchElementException(
                        "No elements " + elementLocator + " ClickAndWaitForPageToLoad");
                }
                var element = elements.FirstOrDefault(e => e.Displayed);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine(
                    "Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }
}
