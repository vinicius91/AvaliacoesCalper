using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.CrossCutting.Helpers;

namespace AvaliacoesCalper.Domain.Entities
{
    public class Alternativa : EntityBase
    {

        public string Descricao { get; private set; }

        public int Valor { get; private set; }

        public ICollection<Questao> Questoes { get; set; }

        public const int DescricaoMinLength = 5;

        public const int DescricaoMaxLength = 100;

        public const int ValorMinLenght = 1;

        public const int ValorMaxLenght = 5;


        protected Alternativa()
        {
            
        }

        public Alternativa(string descricao, int valor)
        {
            SetDescricao(descricao);
            SetValor(valor);
        }

        public void SetDescricao(string descricao)
        {
            Guard.ForNullOrEmptyDefaultMessage(descricao, "Descrição");
            Guard.StringLength(descricao, DescricaoMinLength, DescricaoMaxLength, "Descrição deve possuir 5 a 100 caracteres" );
            Descricao = descricao;

        }

        public void SetValor(int valor)
        {
            if (valor < ValorMinLenght || valor > ValorMaxLenght)
            {
                throw new Exception("Valor deve estar dentro dos limites estabelecidos");
            }
            Valor = valor;
        }

    }
}
