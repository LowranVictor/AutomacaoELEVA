using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Xunit;

namespace AutomacaoELEVA.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Modal de status do servidor
        [FindsBy(How = How.Id, Using = "fluig-modal")]
        private IWebElement modalStatus;

        //Fecha modal status
        [FindsBy(How = How.CssSelector, Using = "[class='close']")]
        private IWebElement fechaModalStatus; 

        //Itens para opção de solicitações pendentes de NF
        [FindsBy(How = How.CssSelector, Using = "[class='swal2-confirm swal2-styled']")]
        private IWebElement btnOKModalSolicitacoes;

        [FindsBy(How = How.Id, Using = "swal2-content")]
        private IWebElement modalSolicitacoesPendentes;

        //Menu lateral direito (abertura de paineis e processo)
        [FindsBy(How = How.LinkText , Using = "Painel de Aprovação")]
        private IWebElement btnPainelAprov;

        [FindsBy(How = How.LinkText, Using = "Painel de Consulta")]
        private IWebElement btnPainelConsulta;

        [FindsBy(How = How.LinkText, Using = "Solicitação de Pagamento")]
        private IWebElement btnSolicitacaoPagamento;

        [FindsBy(How = How.LinkText, Using = "Solicitação de Adiantamento")]
        private IWebElement btnSolicitacaoAdiantamento;

        [FindsBy(How = How.LinkText, Using = "Solicitação de Reembolso")]
        private IWebElement btnSolicitacaoReembolso;

        [FindsBy(How = How.LinkText, Using = "Solicitação de Fundo Fixo")]
        private IWebElement btnSolicitacaoFundoFixo;

        //Tarefas, Solicitações e Documentos
        [FindsBy(How = How.LinkText, Using = "Tarefas Atrasadas")]
        private IWebElement btnTarefaAtrasada;

        [FindsBy(How = How.LinkText, Using = "Tarefas no prazo")]
        private IWebElement btnTarefaPrazo;

        [FindsBy(How = How.LinkText, Using = "Minhas Solicitações")]
        private IWebElement btnMinhasSolicit;

        [FindsBy(How = How.LinkText, Using = "Aprovação de documentos pendentes")]
        private IWebElement btnAprovDocPendente;

        [FindsBy(How = How.LinkText, Using = "Documentos aguardando aprovação")]
        private IWebElement btnDocsAgAprov;

        [FindsBy(How = How.LinkText, Using = "Documentos em check-out")]
        private IWebElement btnDocsCheckout;

        //Tratativa realizada para verificar se o modal informando que possui solicitações pendentes é exibido
        //Onde o mesmo valida a mensagem e logo após clica no OK.
        public void fechaModalSolicitacoesPendentes()
        {
            string msgmodal = "Você possui solicitações com nota fiscal pendente";
            string recmsg = modalSolicitacoesPendentes.GetAttribute("innerText");

            if (recmsg.Contains(msgmodal))
            {
                try
                {
                    btnOKModalSolicitacoes.Click();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
       
        public void fechaModalServidor()
        {
            bool exibeModal = modalStatus.Displayed;
            try
            {
                if (exibeModal)
                {
                    fechaModalStatus.Click();
                }

                fechaModalSolicitacoesPendentes();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public void acessarPainelAprovacao()
        {
            try
            {
                btnPainelAprov.Click();
                Thread.Sleep(20000);
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }

    }
}
