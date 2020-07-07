using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomacaoELEVA.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Opções para realizar o login
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement usuario;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement senha;

        [FindsBy(How = How.Id, Using = "submitLogin")]
        private IWebElement btnAcessar;

        [FindsBy(How = How.Id, Using = "forgot_password")]
        private IWebElement btnEsqSenha;


        //Opções para Esqueci a Senha
        [FindsBy(How = How.Id, Using = "login_reset")]
        private IWebElement loginEsqueciSenha;

        [FindsBy(How = How.Id, Using = "send_reset")]
        private IWebElement enviarEsqueciSenha;

        [FindsBy(How = How.Id, Using = "cancel_reset")]
        private IWebElement voltarLogin;

        public void realizarLogin(string usu, string psw)
        {
            usuario.SendKeys(usu);
            senha.SendKeys(psw);

            Thread.Sleep(3000);

            btnAcessar.Click();
        }

        public void esqueciSenha(string usur)
        {
            btnEsqSenha.Click();
            Thread.Sleep(3000);

            loginEsqueciSenha.SendKeys(usur);
            enviarEsqueciSenha.Click();
        }
    }
}
