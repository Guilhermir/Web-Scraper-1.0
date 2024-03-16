using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Drawing;
using System.Threading;

namespace WebScraper.Helpers
{
    public static class InteragirPagina
    {
        public static void AcessarURL(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://portaldatransparencia.gov.br/contratos/consulta");
        }

        public static void ClicarLimpar(IWebDriver driver)
        {
            var botaoLimpar = driver.FindElement(By.XPath("//*[@id=\"box-filtros-aplicados-com-botao\"]/p/button[2]"));
            botaoLimpar.Click();
        }

        public static void ClicarFornecedor(IWebDriver driver)
        {
            var botaoFornecedor = driver.FindElement(By.XPath("//*[@id=\"id-box-filtro\"]/div/div/ul/li[8]/div/button"));
            botaoFornecedor.Click();
        }

        public static void PreencherEClicar(IWebDriver driver, string cnpj)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement fornecedorInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"token-input-fornecedor\"]")));

            fornecedorInput.SendKeys(cnpj);

            Thread.Sleep(5000);

            fornecedorInput.SendKeys(Keys.ArrowDown);

            fornecedorInput.SendKeys(Keys.Enter);
        }
        public static void ClicarAdicionar(IWebDriver driver)
        {
            var botaoAdicionar = driver.FindElement(By.XPath("//*[@id=\"id-box-filtro\"]/div/div/ul/li[8]/div/div/div/div[2]/input[2]"));
            botaoAdicionar.Click();
        }
        public static void ClicarConsultar(IWebDriver driver)
        {
            var botaoConsultar = driver.FindElement(By.XPath("//*[@id=\"box-filtros-aplicados-com-botao\"]/p/button[1]"));
            botaoConsultar.Click();
        }
    }
}