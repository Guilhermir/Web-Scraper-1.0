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
            try
            {
                using (IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver())
                {
                    Console.WriteLine("Digite o CNPJ: (ex: **.***.***/****-**):");
                    string cnpj = Console.ReadLine();

                    InteragirPagina.AcessarURL(driver);

                    InteragirPagina.ClicarLimpar(driver);

                    InteragirPagina.ClicarFornecedor(driver);

                    InteragirPagina.PreencherEClicar(driver, cnpj);

                    InteragirPagina.ClicarAdicionar(driver);

                    InteragirPagina.ClicarConsultar(driver);

                    ExtrairDados.MudarPagina(driver);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}


