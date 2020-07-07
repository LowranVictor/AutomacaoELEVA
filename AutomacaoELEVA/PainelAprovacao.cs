using System;
using Xunit;
using OpenQA.Selenium;
using AutomacaoELEVA.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;

namespace AutomacaoELEVA
{
    public class PainelAprovacao
    {
        IWebDriver webDriver = new ChromeDriver();
        LoginPage loginPage;
        HomePage hpage;
        PainelAprovacaoPage painelAprovacaoPage;

        [Fact]
        public void ExportarExcel()
        {
            loginPage = new LoginPage(webDriver);
            hpage = new HomePage(webDriver);
            painelAprovacaoPage = new PainelAprovacaoPage(webDriver);

            webDriver.Navigate().GoToUrl("http://fluig.hom.elevaeducacao.com.br:9080/portal/home?admin=1");
            webDriver.Manage().Window.Maximize();

            Thread.Sleep(5000);

            loginPage.realizarLogin("upflow.lowran", "123456");
            Thread.Sleep(3000);

            hpage.fechaModalServidor();
            Thread.Sleep(1000);

            hpage.acessarPainelAprovacao();
            Thread.Sleep(3000);

            //As op��es para o tipo de data s�o: DataSolicitacao, DataVencimento, DataCompetencia
            painelAprovacaoPage.filtrarDataPainelAprovacao("DataVencimento", "01/01/2020 até 01/02/2020");

            string caminhoArq = retornaCaminhoArquivo();

            if (File.Exists(caminhoArq))
            {
                try
                {
                    File.Delete(caminhoArq);
                    //As op��es para o tipo de exporta��o s�o: PDF, Excel, Imprimir, Copiar
                    painelAprovacaoPage.exportarPainelAprovacao("Excel");
                }
                catch (Exception ex)
                {

                    throw ex;
                }               
            }
            else
            {
                try
                {
                    //As op��es para o tipo de exporta��o s�o: PDF, Excel, Imprimir, Copiar
                    painelAprovacaoPage.exportarPainelAprovacao("Excel");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            webDriver.Close();
        }

        public string retornaCaminhoArquivo()
        {
            var dia = DateTime.Today.Day;
            var mes = DateTime.Today.Month;
            var ano = DateTime.Today.Year;

            string novoDia = "0";
            string novoMes = "0";
            if (dia < 10)
            {
                novoDia = novoDia + dia.ToString();
            }
            else
            {
                novoDia = dia.ToString();
            }

            if (mes < 10)
            {
                novoMes = novoMes + mes.ToString();
            }
            else
            {
                novoMes = mes.ToString();
            }

            string caminhdoArqExportado = @"C:\Users\" + Environment.UserName + @"\Downloads\" + ano + novoMes + novoDia + "_PainelAutorização.xlsx";
            return caminhdoArqExportado;
        }

    }
}
