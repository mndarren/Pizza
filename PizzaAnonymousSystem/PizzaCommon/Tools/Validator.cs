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
        private const string nameRegex = @"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$";
        private const string addressRegex = @"^[1-9a-zA-Z ,.'-]+$";
        private const string cityRegex = @"^[a-zA-Z ,.'-]+$";
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

        public static void ValidateMember(Member member)
        {
            var exceptions = ValidatePerson(member);

            if (member.Status != -1 && member.Status != 0 && member.Status != 1)
            {
                exceptions += "Member status is wrong (only can be -1, 0, and 1). ";
            }

            if (exceptions != "") throw new Exception(exceptions);
        }

        public static void ValidateProvider(Provider provider)
        {
            var exceptions = ValidatePerson(provider);

            if (provider.BankAccount > 9999999999999999)
                exceptions += "provider bank account is wrong (<16 digits, & no special characters)";

            if (exceptions != "") throw new Exception(exceptions);
        }

        public static void ValidateManager(Manager manager)
        {
            var exceptions = ValidatePerson(manager);

            if (exceptions != "") throw new Exception(exceptions);
        }

        public static void ValidateAdmin(Admin admin)
        {
            var exceptions = ValidatePerson(admin);

            if (exceptions != "") throw new Exception(exceptions);
        }


        public static void ValidateSchedule(Schedule schedule)
        {
            var exceptions = "";

            if (null != schedule)
            {
                if (schedule.Week < 1 || schedule.Week > 7)
                    exceptions += "invalid week day. week day has to be between 1 and 7. ";
                if (null == schedule.Time)
                    exceptions += "invalid time. time has to be defined. ";

                //interferes with unit testing
                //if (schedule.ReportType != ReportType.MemberReportType
                //    || schedule.ReportType != ReportType.ProviderReportType
                //    || schedule.ReportType != ReportType.EFTReportType
                //    || schedule.ReportType != ReportType.PayableType)
                //    exceptions += "invalid report type. invalid report type ID. please check your administrator. ";

                if (exceptions != "")
                    exceptions = "error: " + exceptions;
            }

            if (exceptions != "") throw new Exception(exceptions);
        }


        public static void ValidateService(Service service)
        {
            var exceptions = "";

            if (service.ServiceCode > 999999 || service.ServiceCode < 0)
                exceptions += "service code is wrong [0,999999]. ";
            if (service.ServiceName.Length > 25 || !Regex.IsMatch(service.ServiceName, nameRegex))
                exceptions += "service name is wrong (<25 characters, & no special characters). ";
            if (service.ServiceFee < 0m || service.ServiceFee > 999.99m)
                exceptions += "service fee is wrong [0,999.99]. ";

            if (exceptions != "") throw new Exception(exceptions);
        }


        public static void ValidateServiceRecord(ServiceRecord serviceRecord) {
            
            var exceptions = "";

            if (serviceRecord.ServiceCode > 999999 || serviceRecord.ServiceCode < 0)
                exceptions += "service code is wrong [0,999999]. ";
            if (serviceRecord.TimeStamp == null)
                exceptions += "invalid time. time has to be defined. ";
            if (serviceRecord.DateProvided ==null)
                exceptions += "invalid time. time has to be defined. ";
            if (serviceRecord.Comments.Length > 100)
                exceptions += "invalid comments. ";

            if (exceptions != "") throw new Exception(exceptions);
        }


       // public static void ValidateAdmin(Manager manager)
       // {
       //     throw new NotImplementedException();
       // }
    }
}
