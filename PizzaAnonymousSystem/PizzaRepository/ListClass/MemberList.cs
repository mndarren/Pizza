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
        private List<Member> members = new List<Member>();

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
            if (member != null){
                members.Add(member);
                return true;
            }
            else { return false; }
        }

        public List<Member> GetMembers() { return members; }

        //delete member from link list
        public Boolean DeleteMember(int memberID) {
            Member member = members.Where(node => node.ID == memberID).FirstOrDefault();
            if (member != null)
            {
                members.Remove(member);
                return true;
            }
            else { return false; }
        }
             
        //Update member status
        public Boolean UpdateMember(int memberID, int _status){
           Member member = members.Where(node => node.ID == memberID).FirstOrDefault();
           if (member != null)
           {
               member.Status = _status;
               return true;
           }
           else { return false; }
        }
    }
}