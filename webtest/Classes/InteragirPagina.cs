using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace WebScraper.Helpers
{
    /// <summary>
    /// Classe para interagir com elementos da página web.
    /// </summary>
    public static class InteragirPagina
    {
        /// <summary>
        /// Acessa a URL.
        /// </summary>
        public static void AcessarURL(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://portaldatransparencia.gov.br/contratos/consulta");
        }

        /// <summary>
        /// Clica no botão "Limpar" na página.
        /// </summary>
        public static void ClicarLimpar(IWebDriver driver)
        {
            var botaoLimpar = driver.FindElement(By.XPath("//*[@id=\"box-filtros-aplicados-com-botao\"]/p/button[2]"));
            botaoLimpar.Click();
        }

        /// <summary>
        /// Clica no botão "Fornecedor" na página.
        /// </summary>
        public static void ClicarFornecedor(IWebDriver driver)
        {
            var botaoFornecedor = driver.FindElement(By.XPath("//*[@id=\"id-box-filtro\"]/div/div/ul/li[8]/div/button"));
            botaoFornecedor.Click();
        }

        /// <summary>
        /// Preenche o campo com o CNPJ do fornecedor e clica em "Enter".
        /// </summary>
        public static void PreencherEClicar(IWebDriver driver, string cnpj)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement fornecedorInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"token-input-fornecedor\"]")));

            fornecedorInput.SendKeys(cnpj);

            Thread.Sleep(5000);

            fornecedorInput.SendKeys(Keys.ArrowDown);

            fornecedorInput.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Clica no botão "Adicionar" na página.
        /// </summary>
        public static void ClicarAdicionar(IWebDriver driver)
        {
            var botaoAdicionar = driver.FindElement(By.XPath("//*[@id=\"id-box-filtro\"]/div/div/ul/li[8]/div/div/div/div[2]/input[2]"));
            botaoAdicionar.Click();
        }

        /// <summary>
        /// Clica no botão "Consultar" na página.
        /// </summary>
        public static void ClicarConsultar(IWebDriver driver)
        {
            var botaoConsultar = driver.FindElement(By.XPath("//*[@id=\"box-filtros-aplicados-com-botao\"]/p/button[1]"));
            botaoConsultar.Click();
        }
    }
}

