using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCommon.Tools
{
    public static class Vaildator
    {
        private const string checkingName = @"/^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u";
        private const string checkingAddress = @"\d{1,3}.?\d{0,3}\s[a-zA-Z]{2,30}\s[a-zA-Z]{2,15}";
        private const string checkingCity = @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$";
        private const string checkingState = @"^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
        private const string checkingZIPCode = @"^\d{5}(?:[-\s]\d{4})?$";
        private const string checkingBankAccount = @"";
        private int checkingServiceCode;
        private int checkingFee;

        public string CheckingMember() { }
        public string CheckingProvider() { }
        public string CheckingManager() { }
        public string CheckingAdmin() { }
        public string CheckingSchedule() { }
        public string CheckingService() { }
        public string CheckingServiceReocrd() { }

    }
}
