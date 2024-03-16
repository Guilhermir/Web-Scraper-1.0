using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebScraper.Classes;
using WebScraper.Helpers;

namespace WebScraper.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();

            Console.WriteLine("Por favor, digite o formato do CNPJ (ex: **.***.***/****-**):");
            string cnpj = Console.ReadLine();

            InteragirPagina.AcessarURL(driver);

            InteragirPagina.ClicarLimpar(driver);

            InteragirPagina.ClicarFornecedor(driver);

            InteragirPagina.PreencherEClicar(driver, cnpj);

            InteragirPagina.ClicarAdicionar(driver);

            InteragirPagina.ClicarConsultar(driver);

            ExtrairDados.ExtracaoDados(driver);

        }
    }
}

