﻿using AttributeRouting.Web.Http;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaModels.Models;

namespace PizzaController.Controllers
{
    public class ManageAccount : ApiController
    {
        private readonly IAdminList adminList;
        private readonly IManagerList managerList;
        private readonly IMemberList memberList;
        private readonly IProviderList providerList;

        public ManageAccount(IAdminList adminList, IManagerList managerList, 
            IMemberList memberList, IProviderList providerList)
        {
            this.adminList = adminList;
            this.managerList = managerList;
            this.memberList = memberList;
            this.providerList = providerList;
        }

        /************************************
         * member
         ***********************************/
        [POST("api/accountmanager/account/member")]
        public Boolean AddMember([FromBody]Member member)
        {   
           return memberList.InsertMember(member);
        }

        [DELETE("api/accountmanager/account/member/{memberID}")]
        public Boolean DeleteMember([FromUri]int memberID)
        {
            return memberList.DeleteMember(memberID);
        }

        [POST("api/accountmanager/account/member")]
        public Member UpdateMember([FromBody]string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode, int status)
        {
            return memberList.UpdateMember(name, ID, streetAddress, city, state, ZIPcode, status);
        }

        //[GET("/accountmanager/account")]
        //public List<Member> GetAllMembers()
        //{
        //    var members = new List<Member>();
        //    try
        //    {
        //
        //    }
        //    catch (Exception e)
        //    {
        //        throw new HttpRequestException(e.Message);
        //    }
        //    return members;
        //}

        /********************************************
         * Provider
         * *****************************************/
        [POST("api/accountmanager/account/provider")]
        public Boolean AddProvider([FromBody]Provider provider)
        {
            return providerList.AddProvider(provider);
        }

        [DELETE("api/accountmanager/account/provider/{providerID}")]
        public Boolean DeleteProvider([FromUri]int providerID)
        {
            return providerList.DeleteProvider(providerID);
        }

        [POST("api/accountmanager/account/provider")]
        public Provider UpdateProvider([FromBody]string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode, long bankAccount)
        {
            var result = providerList.UpdateProvider(name,ID,streetAddress,city,state,ZIPcode,bankAccount);
            return result;
        }

        /********************************
         * Manager
         * ************************************/
        [POST("api/accountmamnager/account/manager")]
        public Boolean AddManager([FromBody]Manager manager)
        {
            return managerList.InsertManager(manager);
        }
        
        [DELETE("api/accountmanager/account/manager/{managerID}")]
        public Boolean DeleteManager([FromUri]int managerID)
        {
            return managerList.DeleteManager(managerID);
        }

        [POST("api/accountmanager/account/manager")]
        public Boolean UpdateManager([FromBody]string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode)
        {
            return managerList.UpdateManager(name, ID, streetAddress,
                                     city, state, ZIPcode);
        }

        /**********************
         * admin
         * *******************/
        [POST("api/accountmanager/account/admin")]
        public Boolean addAdmin([FromBody] Admin admin)
        {
            return adminList.addAdmin(admin);
        }

        [DELETE("api/accountmanager/account/admin/{adminID}")]
        public Boolean DeleteAdmin([FromUri]int adminID)
        {
            return adminList.DeleteAdmin(adminID);
        }

        [POST("api/accountmanager/account/admin")]
        public Admin UpdateAdmin([FromBody]string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode)
        {
            return adminList.UpdateAdmin(name,ID,streetAddress,city,state,ZIPcode);
        }
        
        /*************************************
         * validate member
         * **********************************/
        [GET("api/accountmanager/validation/member/{memberID}")]
        public string ValidateMember([FromUri]int memberID){
            var member = memberList.GetMember(memberID);
            if (member.Status == 0) { return "Validate!"; }
            else if (member.Status == 1) { return "invalid!"; }
            else if (member.Status == 2) { return "Suspend!"; }
            else return null;
        }
        
    }
}
