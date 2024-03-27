using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebScraper.Classes;

namespace WebScraper.Helpers
{
    /// Classe responsável por extrair dados da página.
    public static class ExtrairDados
    {
        /// Verifica se o botão proxima pagina está habilitado e muda a pagina.
        public static List<Dados> MudarPagina(IWebDriver driver)
        {
            var listaDados = new List<Dados>();

            while (true)
            {
                listaDados.AddRange(ExtrairDadosPaginaAtual(driver));

                var proximaPagina = driver.FindElement(By.XPath("//*[@id=\"lista_next\"]/a"));
                if (!proximaPagina.Enabled)
                    break;

                proximaPagina.Click();

                Thread.Sleep(2000);
            }

            return listaDados;
        }

        /// Extrai dados da página atual e retorna uma lista de objetos Dados.
        public static List<Dados> ExtrairDadosPaginaAtual(IWebDriver driver)
        {
            var listaDados = new List<Dados>();

            Thread.Sleep(4000);

            var mytable = driver.FindElement(By.XPath("//*[@id=\"lista\"]/tbody"));

            var rows_table = mytable.FindElements(By.TagName("tr"));

            foreach (var row in rows_table)
            {
                var columnsRow = row.FindElements(By.TagName("td")).ToList();
                var dados = SalvarDados(columnsRow);
                listaDados.Add(dados);

                foreach (var column in columnsRow)
                {
                    string cellText = column.Text;
                    Console.WriteLine($"Valor da célula: {cellText}");
                }
            }

            return listaDados;
        }

        /// Cria um objeto Dados a partir das colunas.
        private static Dados SalvarDados(IReadOnlyList<IWebElement> colunas)
        {
            return new Dados
            {
                DataAssinaturaContrato = colunas[1].Text,
                DataPublicacaoDOU = colunas[2].Text,
                DataInicioVigencia = colunas[3].Text,
                DataFimVigencia = colunas[4].Text,
                OrgaoSuperior = colunas[5].Text,
                OrgaoEntidadeVinculada = colunas[6].Text,
                UnidadeGestora = colunas[7].Text,
                FormaContratacao = colunas[8].Text,
                GrupoObjetoContratacao = colunas[9].Text,
                NumeroContrato = colunas[10].Text,
                NomeFornecedor = colunas[11].Text,
                CPFCNPJFornecedor = colunas[12].Text,
                Situacao = colunas[13].Text,
                ValorContratado = colunas[14].Text.Replace(".", "").Replace(",", ".")
            };
        }
    }
}

