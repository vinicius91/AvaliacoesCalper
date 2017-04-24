using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacoesCalper.Domain.Test.Entities
{
    [TestClass]
    public class AlternativaTests
    {

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Alternativa_New_Descricao_Nao_Pode_Ser_Nula()
        {
            new Alternativa(null, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Alternativa_New_Descricao_Nao_Pode_Ser_Vazia()
        {
            new Alternativa("", 2);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Alternativa_New_Descricao_Nao_Pode_Ser_Menor_que_min()
        {
            string descricao = "";

            for (int i = 0; i < Alternativa.DescricaoMinLength - 1; i++)
            {
                descricao = descricao + "a";
            }
            new Alternativa(descricao, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Alternativa_New_Descricao_Nao_Pode_Ser_Maior_que_Max()
        {
            string descricao = "";

            for (int i = 0; i < Alternativa.DescricaoMaxLength +1; i++)
            {
                descricao = descricao + "a";
            }
            new Alternativa(descricao, 2);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Alternativa_New_Valor_Nao_Pode_Ser_Maior_que_Max()
        {
            new Alternativa("Não Atende", 6);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Alternativa_New_Valor_Nao_Pode_Ser_Menor_Que_Min()
        {
            new Alternativa("Não Atende", 0);
        }

        [TestMethod]
        public void Alternativa_New_Valores_Passados_Conferem_Descricao()
        {
            var alternativa = new Alternativa("Não Atende", 2);
            Assert.AreEqual("Não Atende", alternativa.Descricao);
        }

        [TestMethod]
        public void Alternativa_New_Valores_Passados_Conferem_Valor()
        {
            var alternativa = new Alternativa("Não Atende", 2);
            Assert.AreEqual(2, alternativa.Valor);
        }
    }
}
