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
        public List<MemberReport> GetWeeklyMemberReports()
        {
            List<MemberReport> memberReports = new List<MemberReport>();

            try
            {
                Schedule schedule = scheduleList.GetSchedule(
                    ReportType.MemberReportType);

                TimeSpan startDate;//calculate start date from schedule;
                TimeSpan endDate; //calculate end date from schedule;

                List<Member> memberList = ml.GetAllMembers();
                foreach (Member member in memberList)
                {
                    MemberReport memberReport = new MemberReport();
                    runMemberReportSchedule(member, schedule);
                    memberReports.Add(memberReport);
                }
            }
            catch (Exception e)
            {
                //record exception
                memberReports = null;
            }

            return memberReports;
        }

        [HttpGet]
        [GET("api/reportmanager/reports/providerreport")]
        public List<ProviderReport> GetWeeklyProviderReports()
        {
            List<ProviderReport> providerReports = new List<ProviderReport>();

            try
            {
                Schedule schedule = scheduleList.GetSchedule(
                    ReportType.ProviderReportType);
                TimeSpan startDate;//calculate start date from schedule;
                TimeSpan endDate;//calculate end date from schedule;

                List<Provider> providers = providerList.GetAllProviders();
                foreach (Provider provider in providers)
                {
                    ProviderReport providerReport = new ProviderReport();

                    runProviderReportSchedule(provider, schedule);

                    providerReports.Add(providerReport);
                }
            }
            catch (Exception e)
            {
                //record exception
                providerReports = null;
            }

            return providerReports;
        }

        [HttpGet]
        [GET("api/reportmanager/reports/eftreport")]
        public List<EFTReport> GetWeeklyEFTReports()
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

            return eftReports;
        }

        /*
        public MemberReport GetMemberReport
            (int memberID, TimeSpan startDate, TimeSpan endDate)
        {
            MemberReport memberReport = new MemberReport();

            try
            {
                Member member = ml.GetMember(memberID);

                if (null != member)
                {
                    memberReport.SetMemberInformation(member);

                    foreach (Service s in member.GetServices())
                    //   .Where(s => s.GetDate() <= endDate && s.GetDate() > startDate))
                    {

                        //     memberReport.AddService(service,
                        //         ProviderList.GetProvider(service.GetProviderID()));
                    }
                }
                else throw new Exception("member not found");

            }
            catch (Exception e)
            {
                //record exception
                memberReport = null;
            }

            return memberReport;
        }*/
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

        [HttpGet]
        [GET("api/reportmanager/reports/memberreport/file")]
        public void runMemberReportSchedule(Member _member, Schedule _schedule)
        {
            //compare the current time with the time set
            while (true)
            {
                Thread.Sleep(1000);
                String _nowTime = DateTime.Now.ToString("hh:mm:ss");
                String _schTime = _schedule.Time.ToString();
                String fileName;
                if (_nowTime.Equals(_schTime))
                {
                    fileName = _member.Name + "_" + _nowTime + ".txt";
                    // System.IO.File.WriteAllText(@"WriteText.txt", text);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName))
                    {
                        file.WriteLine("----------------------Member Report--------------------");
                        file.WriteLine("Member ID: " + _member.ID);
                        file.WriteLine("Member Name: " + _member.Name);
                        file.WriteLine("State: " + _member.State);
                        file.WriteLine("Street Address: " + _member.StreetAddress);
                        file.WriteLine("Zipcode: " + _member.ZipCode);
                        file.WriteLine("Status: " + _member.Status);

                        List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForMember(_member.ID);
                        int counter = 0;
                        foreach (ServiceRecord s in serveList)
                        {
                            counter++;
                            int serviceCode = s.ServiceCode;
                            Service service = providerDirectory.GetService("");
                            file.WriteLine("Service:" + counter);
                            file.WriteLine("Service Name: " + service.ServiceName);
                            file.WriteLine("Service Code: " + service.ServiceCode);
                            file.WriteLine("Service Fee: " + service.ServiceFee);
                        }

                    }
                }
            }
        }
        
        [HttpGet]
        [GET("api/reportmanager/reports/providerreport/file")]
        public void runProviderReportSchedule(Provider provider, Schedule _schedule)
        {
            //compare the current time with the time set
            while (true)
            {
                Thread.Sleep(1000);
                String _nowTime = DateTime.Now.ToString("hh:mm:ss");
                String _schTime = _schedule.Time.ToString();
                String fileName;
                if (_nowTime.Equals(_schTime))
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
                        file.WriteLine("Zipcode: " + provider.ZipCode);

                        List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForMember(provider.ID);
                        int counter = 0;
                        foreach (ServiceRecord s in serveList)
                        {
                            counter++;
                            int serviceCode = s.ServiceCode;
                            Service service = providerDirectory.GetService("");
                            file.WriteLine("Service:" + counter);
                            file.WriteLine("Service Name: " + service.ServiceName);
                            file.WriteLine("Service Code: " + service.ServiceCode);
                            file.WriteLine("Service Fee: " + service.ServiceFee);
                        }

                    }
                }
            }
        }

        [HttpGet]
        [GET("api/reportmanager/reports/eftreport/file")]
        public void runEFTReportSchedule(List<Provider> providers, Schedule _schedule)
        {
            //compare the current time with the time set
            while (true)
            {
                Thread.Sleep(1000);
                String _nowTime = DateTime.Now.ToString("hh:mm:ss");
                String _schTime = _schedule.Time.ToString();
                String fileName;
                if (_nowTime.Equals(_schTime))
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

                            List<ServiceRecord> serveList = serviceRecordList.GetAllServiceRecordForMember(provider.ID);
                            foreach (ServiceRecord s in serveList)
                            {
                                serviceNum++;
                                int serviceCode = s.ServiceCode;
                                Service service = providerDirectory.GetService("");
                                file.WriteLine("Service Name: " + service.ServiceName);
                                file.WriteLine("Service fee: " + service.ServiceFee);
                                sumFee += service.ServiceFee;
                            }
                            file.WriteLine("The sum of fee for this provider: " + sumFee);
                            file.WriteLine("The number of the services: " + serviceNum);
                            totalFee += sumFee;
                        }
                        file.WriteLine("The total fee of all providers: " + totalFee);
                        file.WriteLine("The number of the providers: " + providerNum);
                    }
                }
            }
        
        }
    }
}
