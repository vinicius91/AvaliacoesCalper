using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.CrossCutting.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacoesCalper.CrossCutting.Test.Helpers
{
    [TestClass]
    public class GuardTest
    {


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Erro_Quando_em_Branco()
        {
            Guard.ForNullOrEmpty("", "Valor não pode ser vazio!");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Erro_Quando_nulo()
        {
            Guard.ForNullOrEmpty(null, "Valor não pode ser nulo!");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmptyDefaultMessage_Erro_Quando_vazio()
        {
            Guard.ForNullOrEmptyDefaultMessage("", "CompradorID");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmptyDefaultMessage_Erro_Quando_nulo()
        {
            Guard.ForNullOrEmptyDefaultMessage(null, "CompradorID");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_With_ErrorMessage()
        {
            Guard.ForValidId(new Guid(), "O id não pode ser nulo");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_With_propName()
        {
            Guard.ForValidId("CompradorID", new Guid());

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_With_propName_And_Int_Id()
        {
            int id = 0;
            Guard.ForValidId("CompradorID", id);

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_StringLenght_With_String_Larger_Then_Maximum()
        {
            Guard.StringLength("Name", "adbcd", 3);
        }

        [TestMethod]
        public void Guard_StringLenght_With_String_Lesser_Then_Maximum()
        {
            Guard.StringLength("Name", "adbcd", 7);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Guard_StringLenght_With_String_Lesser_Then_Minimum()
        {
            Guard.StringLength("Name", "a", 2, 8);
        }

        [TestMethod]
        public void Guard_StringLenght_With_String_In_The_Midle()
        {
            Guard.StringLength("Name", "adbcdef", 6, 8);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_AreEqual_Com_Valores_diferentes()
        {
            Guard.AreEqual("abc", "abd", "Valores devem ser iguais");
        }

        [TestMethod]
        public void Guard_AreEqual_Com_Valores_Iguais()
        {
            Guard.AreEqual("abc", "abc", "Valores devem ser iguais");
        }
    }
}

