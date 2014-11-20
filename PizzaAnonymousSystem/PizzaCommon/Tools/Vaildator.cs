using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCommon.Tools
{
    public static class Vaildator
    {
        private string checkingName = @"/^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u";
        private string checkingAddress = @"";
        private string checkingCity = @"";
        private string checkingState = @"";
        private string checkingZIPCode = @"";
        private string checkingBankAccount = @"";
        private int checkingServiceCode;
        private int checkingFee;

        public string CheckingMember() { }
        public string CheckingProvider() { }
        public string CheckingManager() { }
        public string CheckingAdmin() { }
        public string CheckingSchedule() { }
        public string CheckingService() { }
        public string CheckingServiceReocr() { }

    }
}
