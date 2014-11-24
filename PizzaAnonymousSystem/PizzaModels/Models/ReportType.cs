using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaModels.Models
{
    public class ReportType
    {
        public static int MemberReportType = 0;//"MEMBER_REPORT_TYPE";
        public static int ProviderReportType = 1;//"PROVIDER_REPORT_TYPE";
        public static int EFTReportType = 2;//"EFT_REPORT_TYPE";
        public static int PayableType = 3;//for account payable report
    }
}