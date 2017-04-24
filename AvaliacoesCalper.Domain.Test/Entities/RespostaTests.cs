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
    public class RespostaTests
    {

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Resposta_New_User_e_avaliador_nao_podem_ser_iguais()
        {
            new Resposta(1, 1, 1, 1, 1);
        }

        [TestMethod]
        public void Resposta_New_Valores_Sao_Correspondentes_User()
        {
            var resposta = new Resposta(1, 2, 3, 4, 5);
            Assert.AreEqual(1, resposta.UserID);
            
        }

        [TestMethod]
        public void Resposta_New_Valores_Sao_Correspondentes_Alternativa()
        {
            var resposta = new Resposta(1, 2, 3, 4, 5);
            Assert.AreEqual(2, resposta.AlternativaID);

        }

        [TestMethod]
        public void Resposta_New_Valores_Sao_Correspondentes_Questao()
        {
            var resposta = new Resposta(1, 2, 3, 4, 5);
            Assert.AreEqual(3, resposta.QuestaoID);

        }

        [TestMethod]
        public void Resposta_New_Valores_Sao_Correspondentes_Questionario()
        {
            var resposta = new Resposta(1, 2, 3, 4, 5);
            Assert.AreEqual(4, resposta.QuestionarioID);

        }

        [TestMethod]
        public void Resposta_New_Valores_Sao_Correspondentes_Avaliador()
        {
            var resposta = new Resposta(1, 2, 3, 4, 5);
            Assert.AreEqual(5, resposta.AvaliadorID);

        }
    }
}
