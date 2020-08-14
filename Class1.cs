using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AppiumTest
{
    public class Class1
    {
        AndroidDriver<AndroidElement> driver;
        AppiumOptions capabilities;

        [SetUp]
        public void InitDriver()
        {
            capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("platformName", "Android");
            capabilities.AddAdditionalCapability("deviceName", "emulator-5554");
            capabilities.AddAdditionalCapability("appPackage", "com.android.chrome");
            capabilities.AddAdditionalCapability("appActivity", "com.google.android.apps.chrome.Main");
            capabilities.AddAdditionalCapability("MobileCapabilityType.BROWSER_NAME", "chrome");
            
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("ignore-certificate-errors");
            options.AddArguments("disable-translate");
            options.AddArguments("--disable-fre");
            capabilities.AddAdditionalCapability("ChromeOptions.CAPABILITY", options);
            
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);

            

        }
        [Test]
        public void Test1()
        {
            Assert.IsNotNull(driver);
            Thread.Sleep(5000);
            string context = driver.Context;
            driver.Context = ("NATIVE_APP");
            driver.FindElementById("com.android.chrome:id/terms_accept").Click();
            driver.FindElementById("com.android.chrome:id/negative_button").Click();
            driver.Context = (context);
            driver.Navigate().GoToUrl("http://www.cnn.com");

            Thread.Sleep(15000);
        }
        [TearDown]
        public void closeDriver()
        {
            driver.Quit();
        }
    }
}
