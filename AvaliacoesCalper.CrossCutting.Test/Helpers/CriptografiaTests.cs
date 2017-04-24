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
    public class CriptografiaTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Criptografia_HashPassword_Check_Null()
        {
            Criptografia.HashPassword(null);

        }


        [TestMethod]
        public void Criptografia_Hashpassword_Type_Of_Return()
        {
            var passwordHash = Criptografia.HashPassword("12345678");
            Assert.IsInstanceOfType(passwordHash, typeof(string));

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Criptografia_VerifyHashedPassword_Hashed_Is_Null()
        {
            Criptografia.VerifyHashedPassword(null, "12345678");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Criptografia_VerifyHashedPassword_Password_Is_Null()
        {
            var passwordHash = Criptografia.HashPassword("12345678");
            Criptografia.VerifyHashedPassword(passwordHash, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Criptografia_VerifyHashedPassword_Hashed_Is_Empty()
        {
            Criptografia.VerifyHashedPassword("", "12345678");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Criptografia_VerifyHashedPassword_Password_Is_Empty()
        {
            var passwordHash = Criptografia.HashPassword("12345678");
            Criptografia.VerifyHashedPassword(passwordHash, "");
        }


        [TestMethod]
        public void Criptografia_VerifyHashedPassword_Hash_Is_Equal_Password()
        {
            var passwordHash = Criptografia.HashPassword("12345678");
            bool result = Criptografia.VerifyHashedPassword(passwordHash, "12345678");
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Criptografia_VerifyHashedPassword_Hash_Is_Diferrent_From_Password()
        {
            var passwordHash = Criptografia.HashPassword("12345678");
            bool result = Criptografia.VerifyHashedPassword(passwordHash, "45646122");
            Assert.IsFalse(result);
        }



    }
}
