using PizzaCommon.Tools;
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
            var success = false;
            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                if (member != null)
                {
                    var tempmember = pizzDB.Members.Where(node => node.ID == member.ID).FirstOrDefault();
                    if (tempmember == null)
                    {
                        pizzDB.Members.Add(MapMemberToEntity(member));
                        pizzDB.SaveChanges();
                        success = true;
                    }
                    else success = false;
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                throw new Exception(e.Message);
            }
            return success;
        }

        //need to fix this
        public Member GetMember(int memberID) {
            var member = new Member();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var tempMember = pizzaDB.Members
                    .Where(es => es.ID == memberID).FirstOrDefault();

                if (null != tempMember)
                    member = MapEntityToMember(tempMember);
                else member = null;
            }
            catch (Exception e)
            {
                member = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return member;
        }

        //delete member from link list
        public Boolean DeleteMember(int memberID) { 
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var tempMember = pizzaDB.Members
                    .Where(es => es.ID == memberID).FirstOrDefault();

                if (null != tempMember)
                {
                    pizzaDB.Members.Remove(tempMember);
                    pizzaDB.SaveChanges(); //Apply changes to DB
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }
            return success;
        }
             
        //Update member
        public Member UpdateMember(string name, int memberID, string streetAddress,
                                     string city, string state, string ZIPcode, int status)
        {
           var member = new Member();
           try
           {
               var pizzDB = new Entity.PizzaDBEntities();
               AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());
              
               var eMember = pizzDB.Members.Where(node => node.ID == memberID).FirstOrDefault();

               if (eMember != null)
               {
                   foreach (var es in pizzDB.Members.Where(es => es.ID == memberID))
                   {
                       es.Name = name;
                       es.StreetAddress = streetAddress;
                       es.City = city;
                       es.State = state;
                       es.ZipCode = ZIPcode;
                       es.Status = (short)status;
                   }
                   pizzDB.SaveChanges();
                   member = GetMember(memberID);
               }
               else member = null;
           }
           catch (Exception e)
           {
               member = null;
               throw new Exception(e.Message);
           }
           return member;
        }

        public List<Member> GetAllMembers()
        {
            var member = new Member();
            var pizzDB = new Entity.PizzaDBEntities();
            AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

            foreach (var result in pizzDB.Members)
            {
                member = MapEntityToMember(result);
                members.Add(member);
            }
            return members;
        }


        #region Entity DataType Mapping

        private Entity.Member MapMemberToEntity(Member member)
        {
            var tempMember = new Entity.Member();

            if (null != member)
            {
                tempMember.ID = member.ID;
                tempMember.Name = member.Name;
                tempMember.StreetAddress = member.StreetAddress;
                tempMember.City = member.City;
                tempMember.State = member.State;
                tempMember.ZipCode = member.ZipCode;
                tempMember.Status = (short)member.Status;
            }

            return tempMember;
        }

        private Member MapEntityToMember(Entity.Member tempMember)
        {
            var Member = new Member();

            if (null != tempMember)
            {
                Member.ID = tempMember.ID;
                Member.Name = tempMember.Name;
                Member.StreetAddress = tempMember.StreetAddress;
                Member.City = tempMember.City;
                Member.State = tempMember.State;
                Member.ZipCode = tempMember.ZipCode;
                Member.Status = (int)tempMember.Status;
            }

            return Member;
        }

        #endregion
    }
}