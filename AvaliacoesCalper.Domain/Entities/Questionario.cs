using System.Collections.Generic;
using AvaliacoesCalper.CrossCutting.Helpers;

namespace AvaliacoesCalper.Domain.Entities
{
    public class Questionario : EntityBase
    {
        public string Descricao { get; private set; }

        public ICollection<Questao> Questionarios { get; set; }


        protected Questionario()
        {
            
        }


        public Questionario(string descricao)
        {
            SetDescricao(descricao);
        }

        public void SetDescricao(string descricao)
        {
            Guard.ForNullOrEmptyDefaultMessage(descricao, "Descrição");
            Descricao = descricao;
        }
    }
}