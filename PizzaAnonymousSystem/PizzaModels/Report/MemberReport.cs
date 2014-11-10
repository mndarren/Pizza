using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;
//using PizzaRepository.ListClass;

namespace PizzaModels.Report
{
    public class MemberReport
    {
        private Member _member;
        private Schedule _schedule;
        //private ProviderDirectory _pd;
        //private MemberList _ml;

        public MemberReport() { }
        public MemberReport(Schedule _sch, Member _m) { }
        public void SetMemberInformation(Member m) { this._member = m; }
        public void runSchedule() {
            //compare the current time with the time set
            while (true) { 
                String _nowTime = DateTime.Now.ToString("hh:mm:ss") ;
                String _schTime =_schedule.Time.ToString();
                String fileName;
                if (_nowTime.Equals(_schTime))
                {
                    fileName = _member.Name + "_" + _nowTime + ".txt";
                   // System.IO.File.WriteAllText(@"WriteText.txt", text);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName))
                    {
                        file.WriteLine("----------------------Member Report--------------------");
                        file.WriteLine(_member.ID);
                        file.WriteLine(_member.Name);
                        file.WriteLine(_member.State);
                        file.WriteLine(_member.StreetAddress);
                        file.WriteLine(_member.ZipCode);
                        file.WriteLine(_member.Status);                      
                    }
                }
            }
        }
    }
}