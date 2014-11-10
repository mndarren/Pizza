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

       // public List<Member> GetMembers()
       // {
       //
       // }

        public Boolean DeleteMember(int memberID)
        {
            return !_returnError;
        }
        public Boolean UpdateMember(int memberID, int _status)
        {
            return !_returnError;
        }

        public bool UpdateMember(string name, int memberID, string streetAddress, string city, string state, string ZIPcode, int status)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        bool IMemberList.InsertMember(Member member)
        {
            throw new NotImplementedException();
        }

        Member IMemberList.GetMember(int memberID)
        {
            throw new NotImplementedException();
        }

        bool IMemberList.DeleteMember(int memberID)
        {
            throw new NotImplementedException();
        }

        bool IMemberList.UpdateMember(string name, int memberID, string streetAddress, string city, string state, string ZIPcode, int status)
        {
            throw new NotImplementedException();
        }

        List<Member> IMemberList.GetAllMembers()
        {
            throw new NotImplementedException();
        }
    }
}