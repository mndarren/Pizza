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
        private static List<Member> memberList;// = new List<Member>();

        //private static MemberList memberList;

        //create a member list instance


        public MemberList() {
            if (memberList == null)
            {
                memberList = new List<Member>();
            }
        }

        //add member into list
        public Boolean InsertMember(Member member){
            if (member != null){
                memberList.Add(member);
                return true;
            }
            else { return false; }
        }

        public Member GetMember(int memberID) {
            Member member = memberList.Where(node => node.ID == memberID).FirstOrDefault();
            return member; 
        
        }

        //delete member from link list
        public Boolean DeleteMember(int memberID) {
            Member member = memberList.Where(node => node.ID == memberID).FirstOrDefault();
            if (member != null)
            {
                memberList.Remove(member);
                return true;
            }
            else { return false; }
        }
             
        //Update member status
        public Boolean UpdateMember(string name, int memberID, string streetAddress,
                                     string city, string state, string ZIPcode, int status)
        {
            Member member = memberList.Where(node => node.ID == memberID).FirstOrDefault();
           if (member != null)
           {
               member.Name = name;
               member.StreetAddress = streetAddress;
               member.City = city;
               member.State = state;
               member.ZipCode = ZIPcode;
               member.Status = status;
               return true;
           }
           else { return false; }
        }

        public List<Member> GetAllMembers()
        {
            return memberList;
        }
    }
}