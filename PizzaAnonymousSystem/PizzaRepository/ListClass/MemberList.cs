/*
 Author:Cheng Luo
 */
using PizzaModels.Models;
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

        //create a member list instance
        public static MemberList Instance(){
            if (memberList == null){
                return (memberList = new MemberList());
            }
            else{
                return memberList;
            }
        }

        public MemberList() { }

        //add member into list
        public Boolean InsertMember(Member member){
            members.AddLast(member);
            return true;
        }

        /*
        public Boolean DeleteMember(int memberID) { 
        }
        */

    }
}