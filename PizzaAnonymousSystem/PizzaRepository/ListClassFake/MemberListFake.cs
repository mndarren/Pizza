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

        public int? InsertMember(Member member)
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int memberID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMember(int memberID)
        {
            throw new NotImplementedException();
        }

        public Member UpdateMember(string name, int memberID, string streetAddress, string city, string state, string ZIPcode, int status)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllMembers()
        {
            throw new NotImplementedException();
        }
    }
}