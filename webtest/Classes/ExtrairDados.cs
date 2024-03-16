using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebScraper.Classes;

namespace WebScraper.Helpers
{
    public static class ExtrairDados
    {
        public static List<Dados> ExtracaoDados(IWebDriver driver)
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

        public static List<Dados> ExtrairDadosPaginaAtual(IWebDriver driver)
        {
            var listaDados = new List<Dados>();

            Thread.Sleep(2000);

            var mytable = driver.FindElement(By.XPath("//*[@id=\"lista\"]/tbody"));

            var rows_table = mytable.FindElements(By.TagName("tr"));

            int rows_count = rows_table.Count();

            for (int row_index = 0; row_index < rows_count; row_index++)
            {
                List<IWebElement> columnsRow = rows_table[row_index].FindElements(By.TagName("td")).ToList();
                var dados = SalvarDados(columnsRow);
                listaDados.Add(dados);

                int columnsCount = columnsRow.Count;

                for (int column = 0; column < columnsCount; column++)
                {
                    string cellText = columnsRow[column].Text;
                    Console.WriteLine($"Valor da célula da linha {row_index} e coluna {column} é {cellText}");
                }
            }

            return listaDados;
        }

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

