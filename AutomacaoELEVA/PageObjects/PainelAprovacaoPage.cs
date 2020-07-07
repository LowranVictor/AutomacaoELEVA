using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomacaoELEVA.PageObjects
{
    class PainelAprovacaoPage
    {
        private IWebDriver driver;

        public PainelAprovacaoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "fltDtaSolic")]
        private IWebElement dtSolicitacao;

        [FindsBy(How = How.Name, Using = "fltDtaVenc")]
        private IWebElement dtVencimento;

        [FindsBy(How = How.Id, Using = "fltCompetencia")]
        private IWebElement dtCompetencia;

        [FindsBy(How = How.Id, Using = "btnPesqServidor")]
        private IWebElement btnFiltrar;

        [FindsBy(How = How.Id, Using = "btnAprovar")]
        private IWebElement btnAprovar;

        [FindsBy(How = How.Id, Using = "btnReprovar")]
        private IWebElement btnReprovar;

        //baixar anexos
        [FindsBy(How = How.CssSelector, Using = "[class='fa fa-cloud-dowload']")]
        private IWebElement btnBaixarAnexo;

        //Exportar os dados do painel
        [FindsBy(How = How.CssSelector, Using = "[class='btn-group grupo-exportar']")]
        private IWebElement btnExpotar;

        [FindsBy(How = How.CssSelector, Using = "[class='buttons-pdf buttons-html5']")]
        private IWebElement btnExpotaPDF;

        [FindsBy(How = How.CssSelector, Using = "[class='buttons-excel buttons-html5']")]
        private IWebElement btnExpotaExcel;

        [FindsBy(How = How.CssSelector, Using = "[class='buttons-print']")]
        private IWebElement btnExportaImprimir;

        [FindsBy(How = How.CssSelector, Using = "[class='buttons-copy buttons-html5']")]
        private IWebElement btnExportaCopiar;

        //Exportar o relatório de pagamento
        [FindsBy(How = How.Id, Using = "btnExportarTudo")]
        private IWebElement btnRelatorio;

        [FindsBy(How = How.LinkText, Using = "Relatório Geral de Pagamentos")]
        private IWebElement btnRelatorioGeralPagamento;

        //Exibição da quantidade de linhas no painel
        [FindsBy(How = How.CssSelector, Using = "[data-qtd='25']")]
        private IWebElement dropExibi25;

        [FindsBy(How = How.CssSelector, Using = "[data-qtd='50']")]
        private IWebElement dropExibi50;

        [FindsBy(How = How.CssSelector, Using = "[data-qtd='100']")]
        private IWebElement dropExibi100;

        [FindsBy(How = How.CssSelector, Using = "[data-qtd='200']")]
        private IWebElement dropExibi200;

        [FindsBy(How = How.CssSelector, Using = "[data-qtd='500']")]
        private IWebElement dropExibi500;

        [FindsBy(How = How.CssSelector, Using = "[data-qtd='-1']")]
        private IWebElement dropExibiTodasLinhas;

        //Filtro geral
        [FindsBy(How = How.Id, Using = "txtPesquisaPrincipal")]
        private IWebElement filtroGeral;

        [FindsBy(How = How.Id, Using = "limpaPesquisa")]
        private IWebElement btnLimpaPesquisa;

        [FindsBy(How = How.Id, Using = "exibirFiltroAvancado")]
        private IWebElement btnExibeFiltroAvnacado;

        //Filtros relatório geral de pagamento
        [FindsBy(How = How.Name, Using = "DtAbertura_INICIAL")]
        private IWebElement dtAberturaInicialPA;

        [FindsBy(How = How.Name, Using = "DtAbertura_FINAL")]
        private IWebElement dtAberturaFinalPA;

        [FindsBy(How = How.Name, Using = "DtVencimento_INICIAL")]
        private IWebElement dtVencimentoInicialPA;

        [FindsBy(How = How.Name, Using = "DtVencimento_FINAL")]
        private IWebElement dtVencimentoFinalPA;

        [FindsBy(How = How.Name, Using = "DtCompetencia_INICIAL")]
        private IWebElement dtCompetenciaInicialPA;

        [FindsBy(How = How.Name, Using = "DtCompetencia_FINAL")]
        private IWebElement dtCompetenciaFinalPA;

        [FindsBy(How = How.Id, Using = "slctStatus")]
        private IWebElement selectStatus;

        [FindsBy(How = How.Id, Using = "slctSolicitacao")]
        private IWebElement selectTipoSolicitacao;

        [FindsBy(How = How.LinkText, Using = "Cancelar")]
        private IWebElement btnCancelarPA;

        [FindsBy(How = How.LinkText, Using = "Filtrar")]
        private IWebElement btnFiltrarPA;

        public void filtrarDataPainelAprovacao(string tipoData,string data)
        {
            switch (tipoData)
            {
                case "DataSolicitacao":
                    dtSolicitacao.Clear();
                    dtSolicitacao.SendKeys(data);
                    break;
                case "DataVencimento":
                    dtVencimento.Clear();
                    dtVencimento.SendKeys(data);
                    break;
                case "DataCompetencia":
                    dtCompetencia.Clear();
                    dtCompetencia.SendKeys(data);
                    break;
                default:
                    break;
            }

            Thread.Sleep(3000);

            btnFiltrar.Click();
            Thread.Sleep(15000);
        }

        public void exportarPainelAprovacao(string tipoExport)
        {
            btnExpotar.Click();

            switch (tipoExport)
            {
                case "PDF":
                    btnExpotaPDF.Click();
                    break;
                case "Excel":
                    btnExpotaExcel.Click();
                    break;
                case "Imprimir":
                    btnExportaImprimir.Click();
                    break;
                case "Copiar":
                    btnExportaCopiar.Click();
                    break;
                default:
                    break;
            }
            Thread.Sleep(3000);
        }

        public void exportarRelatorioPagamentoPainelAprovacao()
        {
            btnRelatorio.Click();
            btnRelatorioGeralPagamento.Click();

            Thread.Sleep(2000);

            btnFiltrarPA.Click();
        }
    }
}
