using AttributeRouting.Web.Http;
using PizzaModels.Report;
using PizzaRepository.ListInterface;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaModels.Models;

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


        [HttpGet]
        [GET("api/reportmanager/reports/accountPayableReport")]
        public int GetAccountPayableReport()
        {
            int result = 0;//0: success, 1: member is null, 2: serveList is null
            List<AccountPayableReport> eftReports = new List<AccountPayableReport>();
            try
            {
                Schedule _schedule = scheduleList.GetSchedule(
                    ReportType.PayableType);
                TimeSpan startDate; //calculate start date from schedule;
                TimeSpan endDate; //calculate end date from schedule;

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
                        fileName = "Account_Payable_" + _nowTime + ".txt";
                        int providerNum = 0;
                        decimal totalFee = 0;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName))
                        {
                            file.WriteLine("----------------------Account Payable Report--------------------");
                            foreach (Provider provider in providers)
                            {
                                providerNum++;
                                int serviceNum = 0;
                                decimal sumFee = 0;
                                file.WriteLine("Provider Name: " + provider.Name);

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
                                            file.WriteLine("Service Name: " + service.ServiceName);
                                            file.WriteLine("Service fee: " + service.ServiceFee);
                                            sumFee += service.ServiceFee;
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
                                file.WriteLine("\nThe sum of fee for this provider: " + sumFee);
                                file.WriteLine("The number of the services: " + serviceNum);
                                totalFee += sumFee;
                            }
                            file.WriteLine("\nThe total fee of all providers: " + totalFee);
                            file.WriteLine("The number of the providers: " + providerNum);
                            file.WriteLine("\n");
                        }
                    }
                }
                else result = 1; //providers = null;
            }
            catch (Exception e)
            {
                eftReports = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }


        [HttpGet]
        [GET("api/reportmanager/reports/onememberreport")]
        public int GetWeeklyOneMemberReport(int memberID)
        {
            int result = 0; //0: success, 1: member is null, 2: serveList
            try
            {
                Schedule _schedule = scheduleList.GetSchedule(
                    ReportType.MemberReportType);

                String _nowTime = DateTime.Now.ToString("hh:mm");
                String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();

                String fileName;
                Member _member = ml.GetMember(memberID);
                if (_member != null)
                {
                    //if (_nowTime.Equals(_schTime))
                    _nowTime = _nowTime.Replace(":", "_");
                    fileName = _member.Name + "_" + _nowTime + ".txt";
                    string _status = "";
                    // System.IO.File.WriteAllText(@"WriteText.txt", text);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
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
                                file.WriteLine("\nService:" + counter);
                                file.WriteLine("Service Name: " + service.ServiceName);
                                file.WriteLine("Service Code: " + service.ServiceCode);
                                file.WriteLine("Service Fee: " + service.ServiceFee);
                            }
                        }
                        else
                            result = 2;//serveList is null
                    }
                }
                else result = 1;//member is null
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [HttpGet]
        [GET("api/reportmanager/reports/memberreport")]
        public int GetWeeklyMemberReports()
        {
            List<MemberReport> memberReports = null;
            int result = 0; //0: success, 1: member is null, 2: serveList
            try
            {
                Schedule _schedule = scheduleList.GetSchedule(
                ReportType.MemberReportType);

                TimeSpan startDate;//calculate start date from schedule;
                TimeSpan endDate; //calculate end date from schedule;


                //while(true)
                if (true)
                {
                    Thread.Sleep(1000);
                    memberReports = new List<MemberReport>();
                    List<Member> memberList = ml.GetAllMembers();
                    if (memberList != null)
                    {

                        //compare the current time with the time set
                        foreach (Member _member in memberList)
                        {
                            MemberReport memberReport = new MemberReport();
                            memberReports.Add(memberReport);

                            String _nowTime = DateTime.Now.ToString("hh:mm");

                            String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();

                            String fileName;
                            //if (_nowTime.Equals(_schTime))
                            _nowTime = _nowTime.Replace(":", "_");
                            if (true)
                            {
                                fileName = _member.Name + "_" + _nowTime + ".txt";
                                string _status = "";
                                // System.IO.File.WriteAllText(@"WriteText.txt", text);
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
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
                                            file.WriteLine("\nService:" + counter);
                                            file.WriteLine("Service Name: " + service.ServiceName);
                                            file.WriteLine("Service Code: " + service.ServiceCode);
                                            file.WriteLine("Service Fee: " + service.ServiceFee);
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
                }
                else
                {
                    result = 1;//memeberlist is null;
                    //break;
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

        [HttpGet]
        [GET("api/reportmanager/reports/providerreport")]
        public int GetWeeklyProviderReports()
        {
            int result = 0; //0: success, 1: member is null, 2: serveList
            List<ProviderReport> providerReports = null;
            try
            {
                Schedule _schedule = scheduleList.GetSchedule(
                ReportType.ProviderReportType);
                TimeSpan startDate;//calculate start date from schedule;
                TimeSpan endDate;//calculate end date from schedule;

                //compare the current time with the time set
                //while(true)
                if (true)
                {
                    Thread.Sleep(1000);
                    providerReports = new List<ProviderReport>();
                    List<Provider> providers = providerList.GetAllProviders();
                    if (providers != null)
                    {
                        foreach (Provider provider in providers)
                        {
                            ProviderReport providerReport = new ProviderReport();
                            String _nowTime = DateTime.Now.ToString("hh:mm");

                            String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();

                            String fileName;
                            //if (_nowTime.Equals(_schTime))
                            _nowTime = _nowTime.Replace(":", "_");
                            if (true)
                            {
                                fileName = provider.Name + "_" + _nowTime + ".txt";
                                // System.IO.File.WriteAllText(@"WriteText.txt", text);
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName))
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
                                            file.WriteLine("\nService:" + counter);
                                            file.WriteLine("Service Name: " + service.ServiceName);
                                            file.WriteLine("Service Code: " + service.ServiceCode);
                                            file.WriteLine("Service Fee: " + service.ServiceFee);
                                        }
                                    }
                                    else
                                    {
                                        result = 2;//serveList is null;
                                        //break;
                                    }

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

        [HttpGet]
        [GET("api/reportmanager/reports/eftreport")]
        public int GetWeeklyEFTReports()
        {
            List<EFTReport> eftReports = new List<EFTReport>();
            int result = 0; //0: success, 1: member is null, 2: serveList
            try
            {
                Schedule schedule = scheduleList.GetSchedule(
                    ReportType.EFTReportType);
                TimeSpan startDate; //calculate start date from schedule;
                TimeSpan endDate; //calculate end date from schedule;

                List<Provider> providers = providerList.GetAllProviders();
                if (providers != null)
                    result = runEFTReportSchedule(providers, schedule);
                else result = 1; //providers = null;
            }
            catch (Exception e)
            {
                eftReports = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return result;
        }

        [HttpPut]
        [PUT("api/reportmanager/schedules/memberreport")]
        public bool UpdateMemberReportSchedule
            (int weekday, TimeSpan time)
        {
            bool success = false;
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

        [HttpPut]
        [PUT("api/reportmanager/schedules/providerreport")]
        public bool UpdateProviderReportSchedule
            (int weekday, TimeSpan time)
        {
            bool success = false;

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

        [HttpPut]
        [PUT("api/reportmanager/schedules/eftreport")]
        public bool UpdateEFTReportSchedule
            (int weekday, TimeSpan time)
        {
            bool success = false;

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

        [HttpPut]
        [PUT("api/reportmanager/report/providerreport/verification/service")]
        public bool VerifyProviderReportServices
            (int providerID, DateTime startDate, DateTime endDate)
        {
            bool success = false;

            try
            {
                if (null != providerList.GetProvider(providerID))
                {
                    success = serviceRecordList.VerifyServiceRecords(providerID,
                        startDate, endDate, null, true);
                }
                else throw new Exception("invalid provider");
            }
            catch (Exception e)
            {
                success = false;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }

        [HttpPut]
        [PUT("api/reportmanager/report/providerreport/verification/fee")]
        public bool VerifyProviderReportFees
            (int providerID, DateTime startDate, DateTime endDate)
        {
            bool success = false;

            try
            {
                if (null != providerList.GetProvider(providerID))
                {
                    success = serviceRecordList.VerifyServiceRecords(providerID,
                        startDate, endDate, true, null);
                }
                else throw new Exception("invalid provider");
            }
            catch (Exception e)
            {
                success = false;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }

        [HttpPut]
        [GET("api/reportmanager/report/eftreport")]
        public int runEFTReportSchedule(List<Provider> providers, Schedule _schedule)
        {
            //compare the current time with the time set
            int result = 0;
            Thread.Sleep(1000);
            String _nowTime = DateTime.Now.ToString("hh:mm");

            String _schTime = _schedule.Time.Hours.ToString() + ":" + _schedule.Time.Minutes.ToString();

            String fileName;
            //if (_nowTime.Equals(_schTime))
            _nowTime = _nowTime.Replace(":", "_");
            //while(true)
            if (true)
            {
                fileName = "EFT_" + _nowTime + ".txt";
                int providerNum = 0;
                decimal totalFee = 0;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName))
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
                    }
                    file.WriteLine("\nThe total fee: " + totalFee);
                    file.WriteLine("\n");
                }
            }
            return result;
        }
    }
}
