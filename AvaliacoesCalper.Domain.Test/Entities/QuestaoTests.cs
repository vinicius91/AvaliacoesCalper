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
    public class QuestaoTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Questao_New_Descricao_Nao_Pode_Ser_Null()
        {
            new Questao(null);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Questao_New_Descricao_Nao_Pode_Ser_Vazio()
        {
            new Questao("");

        }

        [TestMethod]
        public void Questao_New_Descricao_Descricao_Confere()
        {
            var questao = new Questao("Descrição");

            Assert.AreEqual("Descrição", questao.Descricao);

        }
    }
}
