using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace InstagramSeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.instagram.com");

            Thread.Sleep(4000);

            //IWebElement acceptCookies = webDriver.FindElement(By.CssSelector(".aOOlW.bIiDR"));
            //acceptCookies.Click();
            //Thread.Sleep(4000);

            IWebElement userName = webDriver.FindElement(By.Name("username"));
            userName.SendKeys("kullanıcı adı");

            IWebElement password = webDriver.FindElement(By.Name("password"));
            password.SendKeys("şifre");


            IWebElement loginBtn = webDriver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));
            loginBtn.Click();


            Thread.Sleep(3000);

            IWebElement saveInfo = webDriver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));
            saveInfo.Click();

            Thread.Sleep(4000);
            webDriver.Navigate().GoToUrl("https://www.instagram.com/kizil_aslan_5184");

            Thread.Sleep(3000);

            IWebElement follows = webDriver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(3) > a"));
            follows.Click();

            Thread.Sleep(4000);

            //
            string jsCommand = 
                "sayfa = document.querySelector('.isgrP');" +
                "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                "var sayfaSonu = sayfa.scrollHeight;" +
                "return sayfaSonu;";

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

            while (true)
            {
                var son = sayfaSonu;
                Thread.Sleep(2050);
                sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                if (son == sayfaSonu)
                    break;
            }

            //

            int sayac = 1;
            IReadOnlyCollection<IWebElement> isimler = webDriver.FindElements(By.CssSelector("._0imsa"));
            foreach (IWebElement item in isimler)
            {
                Console.WriteLine(sayac+"==>"+item.Text);
                sayac++;
            }

            //IWebElement notNow = webDriver.FindElement(By.CssSelector(".aOOlW.HoLwm"));
            //notNow.Click();
            webDriver.Quit();
        }
    }
}
