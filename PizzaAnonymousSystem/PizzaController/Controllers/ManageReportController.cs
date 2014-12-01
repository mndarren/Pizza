/**
 *@Author: Shengti Pan
 *@Date:11/5/2014
 *@File: ManageReportController.cs
 *@Description: generate all reports for the system
 */

using AttributeRouting.Web.Http;
using PizzaModels.Report;
using PizzaRepository.ListInterface;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaModels.Models;
using System.Web.Http.Cors;
using System.Web.Http.Controllers;
using PizzaCommon.Tools;
using PizzaController.Models;

namespace PizzaController.Controllers
{
    public class ManageReportController : ApiController
    {
        private readonly IMemberList ml;
        private readonly IProviderList providerList;
        private readonly IProviderDirectory providerDirectory;
        private readonly IScheduleList scheduleList;
        private readonly IServiceRecordList serviceRecordList;



        public ManageReportController(IMemberList ml, IProviderList providerList,
            IProviderDirectory providerDirectory, IScheduleList scheduleList, IServiceRecordList serviceRecordList)
        {
            this.ml = ml;
            this.providerList = providerList;
            this.providerDirectory = providerDirectory;
            this.scheduleList = scheduleList;
            this.serviceRecordList = serviceRecordList;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/reports/accountPayableReport")]
        public string GetAccountPayableReport()
        {
            String result = ""; //0: success, 1: member is null, 2: serveList is null
            List<AccountPayableReport> eftReports = new List<AccountPayableReport>();
            try
            {
                Schedule _schedule = scheduleList.GetSchedule(
                    ReportType.PayableType);
                //TimeSpan startDate; //calculate start date from schedule; //NOT USED! REMOVE?
                //TimeSpan endDate; //calculate end date from schedule;     //NOT USED! REMOVE?

                List<Provider> providers = providerList.GetAllProviders();
                if (providers != null)
                {
                    String _nowTime = DateTime.Now.ToString("hh:mm");

                    String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();

                    String fileName;
                    //if (_nowTime.Equals(_schTime))
                    _nowTime = _nowTime.Replace(":", "_");
                    //while(true)
                    if (true)
                    {
                        int providerNum = 0;
                        decimal totalFee = 0;

                        result += "----------------------Account Payable Report--------------------<br/>";
                        foreach (Provider provider in providers)
                        {
                            providerNum++;
                            int serviceNum = 0;
                            decimal sumFee = 0;
                            result += "Provider Name: " + provider.Name + "<br/>";

                            List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForProvider(provider.ID);
                            if (serveList != null)
                            {
                                foreach (ServiceRecord s in serveList)
                                {
                                    serviceNum++;
                                    int serviceCode = s.ServiceCode;
                                    Service service = providerDirectory.GetService(serviceCode);
                                    if (service != null)
                                    {
                                        result += "Service Name: " + service.ServiceName + "<br/>";
                                        result += "Service fee: " + service.ServiceFee + "<br/>";
                                        sumFee += service.ServiceFee;
                                    }
                                    else
                                    {
                                        result += "<br/>service is null<br/>";
                                    }
                                }
                            }
                            else
                            {
                                result += "<br/>service list is null.<br/>";
                            }
                            result += "The sum of fee for this provider: " + sumFee + "<br/>";
                            result += "The number of the services: " + serviceNum + "<br/>";
                            totalFee += sumFee;

                            result += "<br/>-------------------------------<br/>";
                        }
                        result += "The total fee of all providers: " + totalFee + "<br/>";
                        result += "The number of the providers: " + providerNum + "<br/>";
                    }
                }
                else result += "<br/>providers are null.<br/>"; //providers = null;
            }
            catch (Exception e)
            {
                eftReports = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/reports/onememberreport/{memberID}")]
        public String GetWeeklyOneMemberReport([FromUri]int memberID)
        {
            String result = ""; //0: success, 1: member is null, 2: serveList
            try
            {
                Schedule _schedule = scheduleList.GetSchedule(
                    ReportType.MemberReportType);

                String _nowTime = DateTime.Now.ToString("hh:mm");

                Member _member = ml.GetMember(memberID);
                if (_member != null)
                {
                    //if (_nowTime.Equals(_schTime))
                    _nowTime = _nowTime.Replace(":", "_");
                    string _status = "";

                    result = "----------------------Member Report-------------------- <br />";
                    result += "Member ID: " + _member.ID + "<br />";
                    result += "Member Name: " + _member.Name + "<br />";
                    result += "State: " + _member.State + "<br />";
                    result += "Street Address: " + _member.StreetAddress + "<br />";
                    result += "Zipcode: " + _member.ZipCode + "<br />";
                    if (_member.Status == 0)
                        _status = "Accepted";
                    else if (_member.Status == 2)
                        _status = "Suspened";
                    else
                        _status = "Invalid";
                    result += "Status: " + _status + "<br />";

                    List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForMember(_member.ID);
                    if (serveList != null)
                    {
                        int counter = 0;
                        foreach (ServiceRecord s in serveList)
                        {
                            counter++;
                            int serviceCode = s.ServiceCode;
                            Service service = providerDirectory.GetService(serviceCode);
                            result += "\nService:" + counter + "<br />";
                            result += "Service Name: " + service.ServiceName + "<br />";
                            result += "Service Code: " + service.ServiceCode + "<br />";
                            result += "Service Fee: " + service.ServiceFee + "<br />";
                            result += "<br/>-------------------------------<br/>";
                        }
                    }
                    else
                        result += "<br />serveList is null<br />";

                }
                else result += "<br />member is null<br />";
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [EnableCors("*", "*", "*")]
        [HttpGet]
        [GET("api/reportmanager/reports/memberreport")]
        public int GetWeeklyMemberReports()
        {
            List<MemberReport> memberReports = null;
            int result = 0; //0: success, 1: member is null, 2: serveList
            try
            {

                while (true)
                {
                    Schedule _schedule = scheduleList.GetSchedule(ReportType.MemberReportType);
                    DateTime nTime = DateTime.Now;

                    //String _nowTime = DateTime.Now.ToString("hh:mm");
                    String _nowTime = nTime.Hour.ToString() + ":" + nTime.Minute.ToString();
                    String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();
                    Console.WriteLine("now -> system: " + _nowTime + "->" + _schTime);
                    if (_nowTime.Equals(_schTime))
                    {
                        memberReports = new List<MemberReport>();
                        List<Member> memberList = ml.GetAllMembers();
                        if (memberList != null)
                        {

                            //compare the current time with the time set
                            foreach (Member _member in memberList)
                            {
                                MemberReport memberReport = new MemberReport();
                                memberReports.Add(memberReport);
                                String fileName;
                                _nowTime = _nowTime.Replace(":", "_");
                                if (true)
                                {
                                    fileName = "Member_" + _member.Name + "_" + _nowTime + ".txt";
                                    string _status = "";
                                    // System.IO.File.WriteAllText(@"WriteText.txt", text);
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(PathFactory.ReportPath() + fileName))
                                    {
                                        file.WriteLine("----------------------Member Report--------------------");
                                        file.WriteLine("Member ID: " + _member.ID);
                                        file.WriteLine("Member Name: " + _member.Name);
                                        file.WriteLine("State: " + _member.State);
                                        file.WriteLine("Street Address: " + _member.StreetAddress);
                                        file.WriteLine("Zipcode: " + _member.ZipCode);
                                        if (_member.Status == 0)
                                            _status = "Accepted";
                                        else if (_member.Status == 2)
                                            _status = "Suspened";
                                        else
                                            _status = "Invalid";
                                        file.WriteLine("Status: " + _status);

                                        List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForMember(_member.ID);
                                        if (serveList != null)
                                        {
                                            int counter = 0;
                                            foreach (ServiceRecord s in serveList)
                                            {
                                                counter++;
                                                int serviceCode = s.ServiceCode;
                                                Service service = providerDirectory.GetService(serviceCode);
                                                if (service != null)
                                                {
                                                    file.WriteLine("\nService:" + counter);
                                                    file.WriteLine("Service Name: " + service.ServiceName);
                                                    file.WriteLine("Service Code: " + service.ServiceCode);
                                                    file.WriteLine("Service Fee: " + service.ServiceFee);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            result = 2; //servicelist is null;
                                            //break;
                                        }
                                    }
                                }
                                memberReports.Add(memberReport);
                            }
                        }
                        //Thread.Sleep(1000 * 3600 * 24);

                    }
                    Thread.Sleep(10000);
                }

            }
            catch (Exception e)
            {
                memberReports = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/reports/oneproviderreport/{providerID}")]
        public String GetWeeklyOneProviderReport([FromUri]int providerID)
        {
            String result = ""; //0: success, 1: member is null, 2: serveList
            List<ProviderReport> providerReports = null;
            try
            {
                providerReports = new List<ProviderReport>();
                Provider provider = providerList.GetProvider(providerID);
                if (provider != null)
                {

                    result = "----------------------Provider Report--------------------<br />";
                    result += "Provider ID: " + provider.ID + "<br />";
                    result += "Provider Name: " + provider.Name + "<br />";
                    result += "City: " + provider.City + "<br />";
                    result += "State: " + provider.State + "<br />";
                    result += "Street Address: " + provider.StreetAddress + "<br />";
                    result += "Zip Code: " + provider.ZipCode + "<br />";

                    List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForProvider(provider.ID);
                    if (serveList != null)
                    {
                        int counter = 0;
                        foreach (ServiceRecord s in serveList)
                        {
                            counter++;
                            int serviceCode = s.ServiceCode;
                            Service service = providerDirectory.GetService(serviceCode);
                            if (service != null)
                            {
                                result += "<br />Service:" + counter + "<br />";
                                result += "Service Name: " + service.ServiceName + "<br />";
                                result += "Service Code: " + service.ServiceCode + "<br />";
                                result += "Service Fee: " + service.ServiceFee + "<br />";
                            }
                            result += "<br/>-------------------------------<br/>";
                        }
                    }
                    else
                    {
                        result += "<br />serveList is null<br />";
                    }
                }
                else result += "<br />provider is null<br />";

            }
            catch (Exception e)
            {
                providerReports = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [EnableCors("*", "*", "*")]
        [HttpGet]
        [GET("api/reportmanager/reports/providerreport")]
        public int GetWeeklyProviderReports()
        {
            int result = 0; //0: success, 1: member is null, 2: serveList
            List<ProviderReport> providerReports = null;
            try
            {

                //TimeSpan startDate;//calculate start date from schedule; //NOT USED! REMOVE?
                //TimeSpan endDate;//calculate end date from schedule;     //NOT USED! REMOVE?

                //compare the current time with the time set
                while (true)
                {
                    Schedule _schedule = scheduleList.GetSchedule(ReportType.ProviderReportType);
                    DateTime nTime = DateTime.Now;

                    //String _nowTime = DateTime.Now.ToString("hh:mm");
                    String _nowTime = nTime.Hour.ToString() + ":" + nTime.Minute.ToString();
                    String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();
                    Console.WriteLine("now -> system: " + _nowTime + "->" + _schTime);
                    providerReports = new List<ProviderReport>();
                    List<Provider> providers = providerList.GetAllProviders();
                    if (providers != null)
                    {
                        foreach (Provider provider in providers)
                        {

                            ProviderReport providerReport = new ProviderReport();
                            String fileName;
                            //if (_nowTime.Equals(_schTime))
                            _nowTime = _nowTime.Replace(":", "_");

                            fileName = "Provider_" + provider.Name + "_" + _nowTime + ".txt";
                            // System.IO.File.WriteAllText(@"WriteText.txt", text);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(PathFactory.ReportPath() + fileName))
                            {
                                file.WriteLine("----------------------Provider Report--------------------");
                                file.WriteLine("Provider ID: " + provider.ID);
                                file.WriteLine("Provider Name: " + provider.Name);
                                file.WriteLine("City: " + provider.City);
                                file.WriteLine("State: " + provider.State);
                                file.WriteLine("Street Address: " + provider.StreetAddress);
                                file.WriteLine("Zip Code: " + provider.ZipCode);

                                List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForProvider(provider.ID);
                                if (serveList != null)
                                {
                                    int counter = 0;
                                    foreach (ServiceRecord s in serveList)
                                    {
                                        counter++;
                                        int serviceCode = s.ServiceCode;
                                        Service service = providerDirectory.GetService(serviceCode);
                                        if (service != null)
                                        {
                                            file.WriteLine("\nService:" + counter);
                                            file.WriteLine("Service Name: " + service.ServiceName);
                                            file.WriteLine("Service Code: " + service.ServiceCode);
                                            file.WriteLine("Service Fee: " + service.ServiceFee);
                                        }
                                    }
                                }
                                else
                                {
                                    result = 2;//serveList is null;
                                    //break;
                                }


                            }
                            providerReports.Add(providerReport);
                        }
                    }
                    else
                    {
                        result = 1;//providers is null;
                        //break;
                    }
                    Thread.Sleep(1000 * 3600 * 24);
                    //Thread.Sleep(30000);
                }
            }
            catch (Exception e)
            {
                providerReports = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [EnableCors("*", "*", "*")]
        [HttpGet]
        [GET("api/reportmanager/reports/eftreport")]
        public int GetWeeklyEFTReports()
        {
            List<EFTReport> eftReports = new List<EFTReport>();
            int result = 0; //0: success, 1: member is null, 2: serveList
            try
            {

                while (true)
                {
                    Schedule _schedule = scheduleList.GetSchedule(ReportType.EFTReportType);


                    DateTime nTime = DateTime.Now;

                    //String _nowTime = DateTime.Now.ToString("hh:mm");
                    String _nowTime = nTime.Hour.ToString() + ":" + nTime.Minute.ToString();
                    String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();
                    Console.WriteLine("now -> system: " + _nowTime + "->" + _schTime);

                    String fileName;
                    //if (_nowTime.Equals(_schTime))
                    _nowTime = _nowTime.Replace(":", "_");
                    List<Provider> providers = providerList.GetAllProviders();
                    if (providers != null)
                    {


                        fileName = "EFT_" + _nowTime + ".txt";
                        int providerNum = 0;
                        decimal totalFee = 0;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(PathFactory.ReportPath() + fileName))
                        {
                            file.WriteLine("----------------------EFT Report--------------------");
                            foreach (Provider provider in providers)
                            {
                                providerNum++;
                                int serviceNum = 0;
                                decimal sumFee = 0;
                                file.WriteLine("Bank account: " + provider.BankAccount);

                                List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForProvider(provider.ID);
                                if (serveList != null)
                                {
                                    foreach (ServiceRecord s in serveList)
                                    {
                                        serviceNum++;
                                        int serviceCode = s.ServiceCode;
                                        Service service = providerDirectory.GetService(serviceCode);
                                        if (service != null)
                                        {
                                            sumFee += service.ServiceFee;
                                            result = 0;
                                        }
                                        else
                                        {
                                            result = 3;//service is null
                                        }
                                    }
                                }
                                else
                                {
                                    result = 2;//service list is null
                                }
                                totalFee += sumFee;
                                file.WriteLine("The total fee: " + totalFee);
                                file.WriteLine("\n");
                            }
                        }
                    }
                    else result = 1; //providers = null;
                    //Thread.Sleep(30000);
                    Thread.Sleep(1000 * 3600 * 24);
                }

            }
            catch (Exception e)
            {
                eftReports = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //temp fix for CORS POST
        [POST("api/reportmanager/schedules/put/memberreport")]
        public bool UpdateMemberReportSchedule
            (int weekday, TimeSpan time)
        {
            bool success = true;
            try
            {
                Schedule updatedSchedule = new Schedule();
                updatedSchedule.ReportType = ReportType.MemberReportType;
                updatedSchedule.Week = weekday;
                updatedSchedule.Time = time;

                updatedSchedule = scheduleList.UpdateSchedule(updatedSchedule);
            }
            catch (Exception e)
            {
                success = false;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/schedules/put/providerreport")]
        public bool UpdateProviderReportSchedule
            (int weekday, TimeSpan time)
        {
            bool success = true;

            try
            {
                Schedule updatedSchedule = new Schedule();
                updatedSchedule.ReportType = ReportType.ProviderReportType;
                updatedSchedule.Week = weekday;
                updatedSchedule.Time = time;

                updatedSchedule = scheduleList.UpdateSchedule(updatedSchedule);
            }
            catch (Exception e)
            {
                success = false;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/schedules/put/eftreport")]
        public bool UpdateEFTReportSchedule
            (int weekday, TimeSpan time)
        {
            bool success = true;

            try
            {
                Schedule updatedSchedule = new Schedule();
                updatedSchedule.ReportType = ReportType.EFTReportType;
                updatedSchedule.Week = weekday;
                updatedSchedule.Time = time;

                updatedSchedule = scheduleList.UpdateSchedule(updatedSchedule);
            }
            catch (Exception e)
            {
                success = false;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/report/providerreport/verification/put/service")]
        public bool VerifyProviderReportServices([FromBody]VerifyReportViewModel input)
        {
            bool success = false;

            try
            {
                if (null != input)
                {
                    if (null != providerList.GetProvider(input.ProviderNumber))
                    {
                        success = serviceRecordList.VerifyServiceRecords(input.ProviderNumber,
                            input.StartDate, input.EndDate, null, true);
                    }
                    else throw new Exception("invalid provider");
                }
                else throw new Exception("invalid input");
            }
            catch (Exception e)
            {
                success = false;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/report/providerreport/verification/put/fee")]
        public bool VerifyProviderReportFees([FromBody]VerifyReportViewModel input)
        {
            bool success = false;

            try
            {
                if (null != input)
                {
                    if (null != providerList.GetProvider(input.ProviderNumber))
                    {
                        success = serviceRecordList.VerifyServiceRecords(input.ProviderNumber,
                            input.StartDate, input.EndDate, true, null);
                    }
                    else throw new Exception("invalid provider");
                }
                else throw new Exception("invalid input");
            }
            catch (Exception e)
            {
                success = false;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }


        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/reports/eftreport/file")]
        public string getWeeklyEFTReportsFile()
        {
            //compare the current time with the time set
            string result = "";
            String _nowTime = DateTime.Now.ToString("hh:mm");

            _nowTime = _nowTime.Replace(":", "_");

            List<Provider> providers = providerList.GetAllProviders();
            if (providers != null)
            {
                int providerNum = 0;
                decimal totalFee = 0;

                result += "----------------------EFT Report--------------------<br />";
                foreach (Provider provider in providers)
                {
                    providerNum++;
                    int serviceNum = 0;
                    decimal sumFee = 0;
                    result += "Bank account: " + provider.BankAccount;
                    result += "<br />";
                    List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForProvider(provider.ID);
                    if (serveList != null)
                    {
                        foreach (ServiceRecord s in serveList)
                        {
                            serviceNum++;
                            int serviceCode = s.ServiceCode;
                            Service service = providerDirectory.GetService(serviceCode);
                            if (service != null)
                            {
                                sumFee += service.ServiceFee;
                            }
                            else
                            {
                                result += "<br />service is null<br />";//service is null
                            }
                        }
                    }
                    else
                    {
                        result += "<br />service list is null<br />";//service list is null
                    }
                    totalFee += sumFee;
                    result += "The total fee: " + totalFee;
                    result += "<br/>-------------------------------<br/>";
                }
            }
            return result;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/reports/starupEFTReport")]
        public bool startUpEFTReport()
        {
            GetWeeklyEFTReports();
            return true;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/reports/starupMemberReport")]
        public bool startUpMemberReport()
        {
            GetWeeklyMemberReports();
            return true;
        }


        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/reportmanager/reports/starupProviderReport")]
        public bool startUpProviderReport()
        {
            GetWeeklyProviderReports();
            return true;
        }
    }
}
