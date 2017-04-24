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
    public class QuestionariosTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Questionario_New_Descricao_Nao_Pode_Ser_Null()
        {
            new Questionario(null);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Questionario_New_Descricao_Nao_Pode_Ser_Vazio()
        {
            new Questionario("");

        }

        [TestMethod]
        public void Questionario_New_Descricao_Descricao_Confere()
        {
            var questao = new Questionario("Descrição");

            Assert.AreEqual("Descrição", questao.Descricao);

        }
    }
}
