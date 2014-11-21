using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModels.Models;
using PizzaCommon.Tools;
using System.Text.RegularExpressions;

namespace PizzaCommon.Tools
{
    public static class Validator
    {
        private const string nameRegex = @"/^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u";
        private const string addressRegex = @"\d{1,3}.?\d{0,3}\s[a-zA-Z]{2,30}\s[a-zA-Z]{2,15}";
        private const string cityRegex = @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$";
        private const string stateRegex = @"^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
        private const string zipCodeRegex = @"^\d{5}(?:[-\s]\d{4})?$";

        private static string ValidatePerson(Person person)
        {
            var exceptions = "";

            if (person.StreetAddress.Length > 25 || !Regex.IsMatch(person.StreetAddress, addressRegex))
                exceptions += "newPerson street address is wrong (<25 characters, & no special characters)";
            if (person.Name.Length > 25 || !Regex.IsMatch(person.Name, nameRegex))
                exceptions += "newPerson name is wrong (<25 characters, & no special characters)";
            if (person.City.Length > 14 || !Regex.IsMatch(person.City, cityRegex))
                exceptions += "newPerson city is wrong (<14 characters, & no special characters)";
            if (person.State.Length != 2 || !Regex.IsMatch(person.State, stateRegex))
                exceptions += "newPerson state is wrong (==2 characters, & no special characters)";
            if (person.ZipCode.Length != 5 || !Regex.IsMatch(person.ZipCode, zipCodeRegex))
                exceptions += "newPerson ZipCode is wrong (==5 characters, & no special characters)";
            
            return exceptions;
        }

        public static void ValidateMember() 
        {
            throw new NotImplementedException(); //TODO
        }

        public static void ValidateProvider(Provider provider) 
        {
            var exceptions = ValidatePerson(provider);
            
            if (provider.BankAccount > 9999999999999999)
                exceptions += "provider bank account is wrong (<16 digits, & no special characters)";

            throw new Exception(exceptions);
        }

        public static void ValidateManager(Manager manager) 
        {
            throw new NotImplementedException(); //TODO
        }

        public static void ValidateAdmin(Admin admin) 
        {
            throw new NotImplementedException(); //TODO
        }


        public static void ValidateSchedule(Schedule schedule) 
        {
            throw new NotImplementedException(); //TODO
        }


        public static void ValidateService(Service service) 
        {
            var exceptions = "";

            if (service.ServiceCode > 999999 || service.ServiceCode < 0)
                exceptions += "service code is wrong [0,999999]";
            if (service.ServiceName.Length > 25 || !Regex.IsMatch(service.ServiceName, nameRegex))
                exceptions += "service name is wrong (<25 characters, & no special characters)";
            if (service.ServiceFee < 0m || service.ServiceFee > 999.99m)
                exceptions += "service fee is wrong [0,999.99]";

            throw new Exception(exceptions);
        }

        public static void ValidateServiceRecord(ServiceRecord serviceRecord) 
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
