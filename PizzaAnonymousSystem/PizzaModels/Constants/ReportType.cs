using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Constants
{
    public static class ReportType
    {
        public const int MEMBERREPORT = 0;
        public const int PROVIDERREPORT = 1;
        public const int EFTREPORT = 2;
        public const int ACCTPAYABLEREPORT = 3;
    }

    public static class MemberStatus
    {
        public const int ACCEPTED = 0;
        public const int INVALID = 1;
        public const int SUSPENDED = 2;
    }
}