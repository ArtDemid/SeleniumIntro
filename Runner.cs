using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverIntro
{
    class Runner
    {
        IWebDriver driver = new ChromeDriver();
        TestSuiteGetter getter = new TestSuiteGetter();
        StatusWriter writer = new StatusWriter();
        List<Test> testset = new List<Test>();

        public void Run()
        {
            testset = getter.DefineTestSet();
            //writer.WriteStatus("1", "Some test", "Passed");
            TestMethod_1();
        }

        public void TestMethod_1()
        {
            driver.Navigate().GoToUrl("https://translate.google.com.ua/?hl=uk&tab=TT");
            var data = new object();

            foreach (var item in testset)
            {
                if (item.id == 1)
                {
                    data = item.Data[0];
                }
            }

            IWebElement request = driver.FindElement(By.Id("source"));
            request.SendKeys("Hello World");
            IWebElement submit = driver.FindElement(By.Id("gt-submit"));
            submit.Click();
            IWebElement result = driver.FindElement(By.Id("result_box"));

            if (result.Text == "Привіт Світ")
            {
                string ura = "Passed";
            }

            //driver.Quit();
        }
    }
}
