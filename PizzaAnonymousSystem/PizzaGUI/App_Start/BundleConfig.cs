using System.Web;
using System.Web.Optimization;

namespace PizzaGUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                        "~/Scripts/Index/LoginRole.js"));


            bundles.Add(new ScriptBundle("~/bundles/tools/admin").Include(
                        "~/Scripts/Tools/Admin/AddAdmin.js",
                        "~/Scripts/Tools/Admin/DeleteAdmin.js",
                        "~/Scripts/Tools/Admin/GetAdmin.js",
                        "~/Scripts/Tools/Admin/UpdateAdmin.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/manager").Include(
                        "~/Scripts/Tools/Manager/AddManager.js",
                        "~/Scripts/Tools/Manager/DeleteManager.js",
                        "~/Scripts/Tools/Manager/GetManager.js",
                        "~/Scripts/Tools/Manager/UpdateManager.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/member").Include(
                        "~/Scripts/Tools/Member/AddMember.js",
                        "~/Scripts/Tools/Member/DeleteMember.js",
                        "~/Scripts/Tools/Member/GetMember.js",
                        "~/Scripts/Tools/Member/UpdateMember.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/provider").Include(
                        "~/Scripts/Tools/Provider/AddProvider.js",
                        "~/Scripts/Tools/Provider/DeleteProvider.js",
                        "~/Scripts/Tools/Provider/GetProvider.js",
                        "~/Scripts/Tools/Provider/UpdateProvider.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/report").Include(
                        "~/Scripts/Tools/Report/GetWeeklyEFTReports.js",
                        "~/Scripts/Tools/Report/GetWeeklyEFTReportsFile.js",
                        "~/Scripts/Tools/Report/GetWeeklyMemberReport.js",
                        "~/Scripts/Tools/Report/GetWeeklyMemberReports.js",
                        "~/Scripts/Tools/Report/GetWeeklyMemberReportsFile.js",
                        "~/Scripts/Tools/Report/GetWeeklyProviderReports.js",
                        "~/Scripts/Tools/Report/GetWeeklyProviderReportsFile.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/schedule").Include(
                        "~/Scripts/Tools/Schedule/UpdateEFTReportSchedule.js",
                        "~/Scripts/Tools/Schedule/UpdateMemberReportSchedule.js",
                        "~/Scripts/Tools/Schedule/UpdateProviderReportsSchedule.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/service").Include(
                        "~/Scripts/Tools/Service/AddService.js",
                        "~/Scripts/Tools/Service/DeleteService.js",
                        "~/Scripts/Tools/Service/GetAllServices.js",
                        "~/Scripts/Tools/Service/UpdateServices.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/servicerecord").Include(
                        "~/Scripts/Tools/Service/GetAllServices.js",
                        "~/Scripts/Tools/ServiceRecord/AddServiceRecord.js",
                        "~/Scripts/Tools/ServiceRecord/ValidateMember.js"));

            bundles.Add(new ScriptBundle("~/bundles/tools/verification").Include(
                        "~/Scripts/Tools/Verification/VerifyProviderReportFee.js",
                        "~/Scripts/Tools/Verification/VerifyProviderReportServices.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
