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
        [GET("api/reportmanager/reports/memberreport")]
        public void GetWeeklyMemberReports()
        {
            List<MemberReport> memberReports = null;
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
                        }
                        memberReports.Add(memberReport);
                    }
                }             
            }
            catch (Exception e)
            {
                //record exception
                memberReports = null;
            }
        }

        [HttpGet]
        [GET("api/reportmanager/reports/providerreport")]
        public void GetWeeklyProviderReports()
        {
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
                                file.WriteLine("State: " + provider.State);
                                file.WriteLine("Street Address: " + provider.StreetAddress);
                                file.WriteLine("Zip Code: " + provider.ZipCode);

                                List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForProvider(provider.ID);
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
                        }
                        providerReports.Add(providerReport);
                    }
                     }
                } catch (Exception e){
                //record exception
                providerReports = null;
            }
        }

        [HttpGet]
        [GET("api/reportmanager/reports/eftreport")]
        public void GetWeeklyEFTReports()
        {
            List<EFTReport> eftReports = new List<EFTReport>();

            try
            {
                Schedule schedule = scheduleList.GetSchedule(
                    ReportType.EFTReportType);
                TimeSpan startDate; //calculate start date from schedule;
                TimeSpan endDate; //calculate end date from schedule;

                List<Provider> providers = providerList.GetAllProviders();
                runEFTReportSchedule(providers,schedule);
            }
            catch (Exception e)
            {
                //record exception
                eftReports = null;
            }
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
                //record exception
                success = false;
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
                //record exception
                success = false;
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
                //record exception
                success = false;
            }

            return success;
        }

        [HttpPut]
        [PUT("api/reportmanager/report/providerreport/verification/service")]
        public bool VerifyProviderReportServices
            (int providerID, TimeSpan startDate, TimeSpan endDate)
        {
            bool success = false;

            try
            {
                if (null != providerList.GetProvider(providerID))
                {
                    //var services = providerDirectory.GetServicesByProviderID(providerID)
                    //   .Where(s => s.GetDate() <= endDate
                    //        && s.GetDate() > startDate);
                    /*
                    foreach (var service in services)
                    {
                        service.SetServiceVerified(true);
                        ServiceList.UpdateService(service);
                    }*/
                }
                else throw new Exception("invalid provider");
            }
            catch (Exception e)
            {
                //record exception
                success = false;
            }

            return success;
        }

        [HttpPut]
        [PUT("api/reportmanager/report/providerreport/verification/fee")]
        public bool VerifyProviderReportFees
            (int providerID, TimeSpan startDate, TimeSpan endDate)
        {
            bool success = false;

            try
            {
                if (null != providerList.GetProvider(providerID))
                {
                    /*
                    var services = providerDirectory.GetServicesByProviderID(providerID)
                        .Where(s => s.GetDate() <= endDate
                            && s.GetDate() > startDate);

                    foreach (var service in services)
                    {
                        service.SetFeeVerified(true);
                        ServiceList.UpdateService(service);
                    }*/
                }
                else throw new Exception("invalid provider");
            }
            catch (Exception e)
            {
                //record exception
                success = false;
            }

            return success;
        }

        [HttpPut]
        [GET("api/reportmanager/report/eftreport")]
        public void runEFTReportSchedule(List<Provider> providers, Schedule _schedule)
        {
            //compare the current time with the time set
            if (true)
            {
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
                            file.WriteLine("Provider Name: " + provider.Name);

                            List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForProvider(provider.ID);
                            foreach (ServiceRecord s in serveList)
                            {
                                serviceNum++;
                                int serviceCode = s.ServiceCode;
                                Service service = providerDirectory.GetService(serviceCode);
                                file.WriteLine("Service Name: " + service.ServiceName);
                                file.WriteLine("Service fee: " + service.ServiceFee);
                                sumFee += service.ServiceFee;
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
        
        }
    }
}
