using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.CrossCutting.Helpers;
using AvaliacoesCalper.Domain.ValueObject;

namespace AvaliacoesCalper.Domain.Entities
{
    public class Users : EntityBase
    {
        public string Login { get; private set; }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public Email Email { get; private set; }

        public string PasswordHash { get; private set; }

        public Guid TokenAlteracaoSenha { get; private set; }

        public const int loginMaxValue = 50;

        public const int passwordMinValue = 6;

        public const int passwordMaxValue = 16;


        protected Users()
        {
            
        }

        public Users(string login, string nome, string sobrenome, Email email, string senha, string senhaconfirmacao)
        {
            SetLogin(login);
            SetNome(nome);
            SetSobrenome(sobrenome);
            SetEmail(email);
            SetSenha(senha, senhaconfirmacao);

        }


        public void SetLogin(string login)
        {
            Guard.ForNullOrEmptyDefaultMessage(login, "Login");
            Guard.StringLength("Login", login, loginMaxValue);
            Login = login;

        }

        public void SetNome(string nome)
        {
            Guard.ForNullOrEmptyDefaultMessage(nome, "Nome");
            Nome = nome;
        }

        public void SetSobrenome(string sobrenome)
        {
            Guard.ForNullOrEmptyDefaultMessage(sobrenome, "Sobrenome");
            Sobrenome = sobrenome;
        }


        public void SetEmail(Email email)
        {
            if (email == null)
            {
                throw new Exception("E-mail é obrigatório");
            }

            Email = email;
        }


        public void SetSenha(string senha, string senhaconfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaconfirmacao, "Confirmação de Senha");
            Guard.StringLength(senha, passwordMinValue, passwordMaxValue, "A senha deve possuir no mínimo 6 e no máximo 16 caracteres");
            Guard.AreEqual(senha, senhaconfirmacao, "As senha digitadas não correspondentes");
            PasswordHash = Criptografia.HashPassword(senha);

        }


    }
}
