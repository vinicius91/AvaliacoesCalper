using System;
using System.Text.RegularExpressions;
using AvaliacoesCalper.CrossCutting.Helpers;

namespace AvaliacoesCalper.Domain.ValueObject
{
    public class Email
    {
        public string Address { get; private set; }

        public const int AddressMaxLenght = 254;

        //Contructors

        protected Email()
        {
            
        }

        public Email(string address)
        {
            Guard.ForNullOrEmptyDefaultMessage(address, "E-Mail");
            Guard.StringLength("E-Mail", address, AddressMaxLenght);
            if (IsValid(address) == false)
                throw new Exception("E-mail Inválido");

            Address = address;
        }

        public static bool IsValid(string address)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(address);
        }
    }
}
