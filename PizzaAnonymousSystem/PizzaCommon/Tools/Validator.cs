using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModels.Models;
using PizzaCommon.Tools;

namespace PizzaCommon.Tools
{
    public static class Validator
    {
        private const string checkingName = @"/^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u";
        private const string checkingAddress = @"\d{1,3}.?\d{0,3}\s[a-zA-Z]{2,30}\s[a-zA-Z]{2,15}";
        private const string checkingCity = @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$";
        private const string checkingState = @"^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
        private const string checkingZIPCode = @"^\d{5}(?:[-\s]\d{4})?$";
        private const string checkingBankAccount = @"";

        public string CheckingMember() { }
        public string CheckingProvider() { }
        public string CheckingManager() { }
        public string CheckingAdmin() { }
        public string CheckingSchedule() { }
        public string CheckingService(Service newService) 
        {
            var exceptions = "";
            if (newService.ServiceCode > 999999 || newService.ServiceCode < 0)
                exceptions += "service code is wrong [0,999999]";
            if (newService.ServiceName.Length > 25 || !newService.ServiceName.Regex(checkingName))
                exceptions += "service name is wrong (<25 characters, & no special characters)";
            if (newService.ServiceFee < 0m || newService.ServiceFee > 999.99m)
                exceptions += "service fee is wrong [0,999.99]";
            throw new Exception(exceptions);
        }
        public string CheckingServiceReocrd() { }


        public static void CheckingService(global::PizzaModels.Models.Service newService)
        {
            throw new NotImplementedException();
        }
    }
}
