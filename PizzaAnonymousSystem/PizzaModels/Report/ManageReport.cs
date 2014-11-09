using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaModels.Report
{
    public class ManageReport
    {
        private Member _member;
        private Schedule _schedule;
        private MemberList memberList;
        private ProviderList providerList;
        private ServiceList serviceList;
        private ScheduleList scheduleList;


        public ManageReport() { }

        public List<MemberReport> GetWeeklyMemberReports()
        {
            List<MemberReport> memberReports = new List<MemberReport>();

            try
            {
                Schedule schedule = ScheduleList.GetSchedule(
                    ReportType.MemberReportType);
                TimeSpan startDate;//calculate start date from schedule;
                TimeSpan endDate; //calculate end date from schedule;

                MemberList members = memberList.GetAllMembers();
                foreach (Member member in members)
                {
                    MemberReport memberReport = new MemberReport();
                    memberReport.SetMemberInformation(member);

                    foreach (Service s in member.GetServices()
                        .Where(s => s.GetDate() <= endDate && s.GetDate() > startDate))
                    {
                        memberReport.AddService(service,
                            ProviderList.GetProvider(service.GetProviderID()));
                    }

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


        public List<ProviderReport> GetWeeklyProviderReports()
    {
	    List<ProviderReport> providerReports = new List<ProviderReport>();

	    try
	    {
		    Schedule schedule = ScheduleList.GetSchedule(
			    ReportType.ProviderReportType);
		    TimeSpan startDate;//calculate start date from schedule;
		    TimeSpan endDate;//calculate end date from schedule;
		
		    Provider providers = providerList.GetAllProviders();
		    foreach (Provider provider in providers)
		    {
			    ProviderReport providerReport = new ProviderReport();
			    providerReport.Provider = provider;//SetProviderInformation(provider);
			
			    foreach (Service service in ServiceList.GetServicesByProviderID
				    (provider.ID)
				    .Where(s => s.GetDate() <= endDate && s.GetDate() > startDate))
			    {
				    providerReport.AddService(service,
					    ProviderList.GetProvider(service.GetMemberID()));
			    }

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

        public List<EFTReport> GetWeeklyEFTReports()
        {
            List<EFTReport> eftReports = new List<EFTReport>();

            try
            {
                Schedule schedule = ScheduleList.GetSchedule(
                    ReportType.EFTReportType);
                TimeSpan startDate; //calculate start date from schedule;
                TimeSpan endDate; //calculate end date from schedule;

                Provider providers = providerList.GetAllProviders();
                foreach (Provider provider in providers)
                {
                    var eftReport = new EFTReport();
                    eftReport.providerID = provider.ID;
                    eftReport.providerName = provider.Name;

                    double totalFee = 0.0;
                    foreach (Service service in ServiceList.GetServicesByProviderID
                        (provider.ID)
                        .Where(s => s.GetDate() <= endDate && s.GetDate() > startDate))
                    {
                        totalFee += service.GetFee();
                    }

                    eftReports.Add(eftReport);
                }
            }
            catch (Exception e)
            {
                //record exception
                eftReports = null;
            }

            return eftReports;
        }


        public MemberReport GetMemberReport
            (int memberID, TimeSpan startDate, TimeSpan endDate)
        {
            MemberReport memberReport = new MemberReport();

            try
            {
                Member member = MemberList.GetMember(memberID);

                if (null != member)
                {
                    memberReport.SetMemberInformation(member);

                    foreach (Service s in member.GetServices()
                        .Where(s => s.GetDate() <= endDate && s.GetDate() > startDate))
                    {
                        memberReport.AddService(service,
                            ProviderList.GetProvider(service.GetProviderID()));
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
        }



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

                success = ScheduleList.UpdateSchedule(updatedSchedule);
            }
            catch (Exception e)
            {
                //record exception
                success = false;
            }

            return success;
        }



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

                success = ScheduleList.UpdateSchedule(updatedSchedule);
            }
            catch (Exception e)
            {
                //record exception
                success = false;
            }

            return success;
        }


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

                success = ScheduleList.UpdateSchedule(updatedSchedule);
            }
            catch (Exception e)
            {
                //record exception
                success = false;
            }

            return success;
        }


        public bool VerifyProviderReportServices
            (int providerID, TimeSpan startDate, TimeSpan endDate)
        {
            bool success = false;

            try
            {
                if (null != providerList.GetProvider(providerID))
                {
                    var services = serviceList.GetServicesByProviderID(providerID)
                        .Where(s => s.GetDate() <= endDate
                            && s.GetDate() > startDate);

                    foreach (var service in services)
                    {
                        service.SetServiceVerified(true);
                        ServiceList.UpdateService(service);
                    }
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


        public bool VerifyProviderReportFees
            (int providerID, TimeSpan startDate, TimeSpan endDate)
        {
            bool success = false;

            try
            {
                if (null != providerList.GetProvider(providerID))
                {
                    var services = serviceList.GetServicesByProviderID(providerID)
                        .Where(s => s.GetDate() <= endDate
                            && s.GetDate() > startDate);

                    foreach (var service in services)
                    {
                        service.SetFeeVerified(true);
                        ServiceList.UpdateService(service);
                    }
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
    }
}