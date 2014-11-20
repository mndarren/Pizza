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
        private const string checkingCity = @"";
        private const string checkingState = @"";
        private const string checkingZIPCode = @"";
        private const string checkingBankAccount = @"";
        private const int checkingServiceCode;
        private const int checkingFee;

        public string CheckingMember() { }
        public string CheckingProvider() { }
        public string CheckingManager() { }
        public string CheckingAdmin() { }
        public string CheckingSchedule() { }
        public string CheckingService() { }
        public string CheckingServiceReocrd() { }

    }
}
