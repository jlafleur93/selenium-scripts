using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

class HelloSelenium {
    static void Main() {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var driver = new ChromeDriver();
        try
      {
        // Navigate to Url
        driver.Navigate().GoToUrl("https://google.com");
        // Store 'google search' button web element
        var searchBox = driver.FindElement(By.Name("q"));
        var searchButton = driver.FindElement(By.Name("btnK"));

        searchBox.SendKeys("Selenium");
        driver.FindElement(By.Name("q")).GetAttribute("value"); // => "Selenium"
        //Give wait time after
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        searchButton.Click();
        Actions actionProvider = new Actions(driver);
        // Perform click action on the element
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);
        //Find Selenium Page
        IWebElement linkHandle = driver.FindElement(By.XPath("/html/body/div[7]/div/div[10]/div[1]/div[2]/div[2]/div/div/div[1]/div/div[1]/div/a/h3"));
        //Goto Selenium Webpage
        actionProvider.Click(linkHandle).Build().Perform();
        //Grab Banner & Convert Into Text
        String text = driver.FindElement(By.XPath("/html/body/div/main/section[1]/div/div/div/div/h1")).Text;
        //Write The Text to Console
        Console.WriteLine(text);
      }
      finally
      {
        driver.Quit();
      }
    }
}