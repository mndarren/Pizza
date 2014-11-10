using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaRepository.ListClassFake
{
    public class MemberListFake : IMemberList
    {
        private bool _returnError;

        public MemberListFake(bool returnError = false){
            this._returnError = returnError;
        }

        public bool ReturnError { get { return _returnError; } set { _returnError = value; } }

        public Boolean InsertMember(Member member)
        {
            return !_returnError;
        }

        public Boolean DeleteMember(int memberID)
        {
            return !_returnError;
        }
        public Boolean UpdateMember(int memberID, int _status)
        {
            return !_returnError;
        }

    }
}