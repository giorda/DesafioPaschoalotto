using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace DesafioPaschoalotto
{
    [TestClass]
    public class Cenario1
    {
        IWebDriver driver = new ChromeDriver();
        WebDriverWait wait;
        
        public void ConfiguracaoDriver()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.magazineluiza.com.br/");
            
        }

        
       public void CT0101()
       {
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/div")));
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/div")).Click();
            
       }
       
       public void CT0102(string termoBusca)
       {
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/div/input")).SendKeys(termoBusca);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/ul[2]/li[2]")));        


        }
        public void CT0103()
        {
                      
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/ul[2]/li[2]")).Click();
                        
        }
        
        public void CT0201(string termoBusca)
        {
            ConfiguracaoDriver();
            CT0101();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/div/input")).SendKeys(termoBusca);
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/div/span/i")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/div[1]/div[1]/div/h1/strong")));
            driver.Quit();
        }
        public void CT0301(string termoBusca)
        {
            ConfiguracaoDriver();
            CT0101();
            driver.Navigate().GoToUrl("https://www.magazineluiza.com.br/");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/div/input")).SendKeys(termoBusca);
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[1]/header/div/div[1]/div/div/div[2]/div[2]/div/input")).SendKeys(Keys.Enter);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/div[1]/div[1]/div/h1/strong")));
            driver.Quit();
        }
        [TestMethod]
        [DataRow("Smartphone Samsung Galaxy A70")]
        [DataRow("Smartphone Motorola One Vision")]
        [DataRow("Smartphone Xiaomi Redmi Note 7")]
        public void ExecutarCenario(string termoBusca)
        {
            
            CT0201(termoBusca);
            
        }


    }
}
