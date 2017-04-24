using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacoesCalper.Domain.Test.ValueObjects
{
    [TestClass]
    public class EmailTests
    {


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Empty()
        {
            var email = new Email("");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Null()
        {
            var email = new Email(null);

        }


        [TestMethod]
        public void Email_New_Email_Valido()
        {
            var email = new Email("viniro@hotmail.com");

            Assert.AreEqual("viniro@hotmail.com", email.Address);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Invalido_Com_Mais_Caracteres()
        {
            string address =
                "vini@hotmail.com";

            while (address.Length < Email.AddressMaxLenght)
            {
                address = address + "vini@hotmail.com";
            }

            var email = new Email(address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Invalido_Fora_Do_Regex()
        {

            var email = new Email("sdbakshjfbksajhdskajdhk");
        }


        
    }
}
