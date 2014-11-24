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
        public MemberReport(Schedule _sch, Member _m) {
            this._schedule = _sch;
            this._member = _m;
        }
    }
}