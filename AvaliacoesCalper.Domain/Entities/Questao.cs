using System;
using System.Collections.Generic;
using AvaliacoesCalper.CrossCutting.Helpers;

namespace AvaliacoesCalper.Domain.Entities
{
    public class Questao : EntityBase
    {

        public string Descricao { get; private set; }

        public ICollection<Alternativa> Alternativas { get; set; }

        public ICollection<Questionario> Questionarios { get; set; }

        protected Questao()
        {
            
        }

        public Questao(string descricao)
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