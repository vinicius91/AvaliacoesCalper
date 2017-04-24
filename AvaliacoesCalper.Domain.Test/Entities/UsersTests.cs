using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.CrossCutting.Helpers;
using AvaliacoesCalper.Domain.Entities;
using AvaliacoesCalper.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacoesCalper.Domain.Test.Entities
{
    [TestClass]
    public class UsersTests
    {
        //Test Prepare
        public string Login { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }

        public string SenhaConfirmacao { get; set; }




        public UsersTests()
        {
            Login = "vinicius";
            Nome = "Vinicius";
            Sobrenome = "Rodrigues";
            Email = new Email("viniro@hotmail.com");
            Senha = "123456789";
            SenhaConfirmacao = "123456789";

        }



        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Login_Obrigatorio()
        {
            new Users(null, Nome, Sobrenome, Email, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Nome_Obrigatorio()
        {
            new Users(Login, null, Sobrenome, Email, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Sobrenome_Obrigatorio()
        {
            new Users(Login, Nome, null, Email, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Email_Obrigatorio()
        {
            new Users(Login, Nome, Sobrenome, null, Senha, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Senha_Obrigatorio()
        {
            new Users(Login, Nome, Sobrenome, Email, null, SenhaConfirmacao);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_ConfirmacaoDeSenha_Obrigatorio()
        {
            new Users(Login, Nome, Sobrenome, Email, Senha, null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Usuario_New_Senha_Igual_A_Confirmacao()
        {
            new Users(Login, Nome, Sobrenome, Email, Senha, "12354654");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Usuario_New_Senha_Menor_Que_Valor_Min()
        {
            string senha = "";

            for (int i = 0; i < Users.passwordMinValue -1 ; i++)
            {
                senha = senha + "1";
            }
            new Users(Login, Nome, Sobrenome, Email, senha, senha);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Usuario_New_Senha_Maior_Que_Valor_Max()
        {
            string senha = "";

            for (int i = 0; i < Users.passwordMaxValue + 1; i++)
            {
                senha = senha + "1";
            }
            new Users(Login, Nome, Sobrenome, Email, senha, senha);
        }

        [TestMethod]
        public void Usuario_New_Senha_No_Valor_Correto()
        {
            string senha = "";

            for (int i = 0; i < Users.passwordMaxValue; i++)
            {
                senha = senha + "1";
            }
            new Users(Login, Nome, Sobrenome, Email, senha, senha);
            Assert.AreEqual(Users.passwordMaxValue, senha.Length);
        }


        [TestMethod]
        public void Usuario_New_Valores_Estao_Corretos_Login()
        {
            var usuarioTeste = new Users(Login, Nome, Sobrenome, Email, Senha, SenhaConfirmacao);

            Assert.AreEqual(Login, usuarioTeste.Login);
        }

        [TestMethod]
        public void Usuario_New_Valores_Estao_Corretos_Nome()
        {
            var usuarioTeste = new Users(Login, Nome, Sobrenome, Email, Senha, SenhaConfirmacao);

            Assert.AreEqual(Nome, usuarioTeste.Nome);
        }

        [TestMethod]
        public void Usuario_New_Valores_Estao_Corretos_Sobrenome()
        {
            var usuarioTeste = new Users(Login, Nome, Sobrenome, Email, Senha, SenhaConfirmacao);

            Assert.AreEqual(Sobrenome, usuarioTeste.Sobrenome);
        }

        [TestMethod]
        public void Usuario_New_Valores_Estao_Corretos_Email()
        {
            var usuarioTeste = new Users(Login, Nome, Sobrenome, Email, Senha, SenhaConfirmacao);

            Assert.AreEqual(Email.Address, usuarioTeste.Email.Address);
        }

        [TestMethod]
        public void Usuario_New_Valores_Estao_Corretos_Na_Senha()
        {
            var usuarioTeste = new Users(Login, Nome, Sobrenome, Email, Senha, SenhaConfirmacao);
            bool result = Criptografia.VerifyHashedPassword(usuarioTeste.PasswordHash, Senha);
            Assert.IsTrue(result);
        }



    }
}
