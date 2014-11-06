using AttributeRouting.Web.Http;
using PizzaModels.Report;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PizzaController.Controllers
{
    public class ManageReport : ApiController
    {
        private readonly IMemberList memberList;
        private readonly IProviderList providerList;
        private readonly IProviderDirectory providerDirectory;
        private readonly IScheduleList scheduleList;

        public ManageReport(IMemberList memberList, IProviderList providerList,
            IProviderDirectory providerDirectory, IScheduleList scheduleList)
        {
            this.memberList = memberList;
            this.providerList = providerList;
            this.providerDirectory = providerDirectory;
            this.scheduleList = scheduleList;
        }

        /// <summary>
        /// Return all weekly member reports
        /// </summary>
        /// <returns>a list of member reports</returns>
        [GET("/reportmanager/weeklymemberreports/")]
        public List<MemberReport> GetWeeklyMemberReports()
        {
            var memberReports = new List<MemberReport>();

            try
            {

            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }

            return memberReports;
        }
    }
}
