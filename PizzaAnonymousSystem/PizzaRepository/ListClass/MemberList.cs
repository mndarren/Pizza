using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClass
{
    public class MemberList : IMemberList
    {
        private LinkedList<Member> members = new LinkedList<Member>();

        private static MemberList memberList;

        public static MemberList instance(){
            if (memberList == null)
            {
                return (memberList = new MemberList());
            }
            else
            {
                return memberList;
            }
        }


        public MemberList(){}

    }
}