﻿using AttributeRouting.Web.Http;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaRepository.ListInterface;
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
        [POST("/accountmanager/account/")]
        public Boolean AddMember([FromBody]Member member)
        {   
           return memberList.InsertMember(member);
        }

        [DELETE("/accountmanager/account/")]
        public Boolean DeleteMember([FromBody]int memberID)
        {
            return memberList.DeleteMember(memberID);
        }

        [POST("/accountmanager/account")]
        public Boolean UpdateMember([FromBody]string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode, int status)
        {
            return memberList.UpdateMember(name, ID, streetAddress, city, state, ZIPcode, bankAccount);
        }

        [GET("/accountmanager/account/")]
        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();

            try
            {
                members = memberList.GetMembers();
            }
            catch(Exception e){
                throw new HttpRequestException(e.Message);
            }

            return members;
        }

        /********************************************
         * Provider
         * *****************************************/
        [POST("/accountmanager/account/")]
        public Boolean AddProvider([FromBody]Provider provider)
        {
            return providerList.AddProvider(provider);
        }

        [DELETE("/accountmanager/account/")]
        public Boolean DeleteProvider([FromBody]int providerID)
        {
            return providerList.DeleteProvider(providerID);
        }

        [POST("/accountmanager/account")]
        public Boolean UpdateProvider([FromBody]string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode, long bankAccount)
        {
            return providerList.UpdateProvider(name,ID,streetAddress,city,state,ZIPcode,bankAccount);
        }

        [GET("/accountmanager/account/")]
        public List<Provider> GetAllProviders()
        {
            var providers = new List<Provider>();

            try
            {
                providers = providerList.GetProviders();
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }

            return providers;
        }

        /********************************
         * Manager
         * ************************************/
        
        
        /**********************
         * admin
         * *******************/
 
        
        /*************************************
         * validate member
         * **********************************/.
        [PUT("/accountmanager/account")]
        public int ValidateMember(int memberID){
            var members = memberList.GetMembers();
            Member member = members.Where(node => node.ID == memberID).FirstOrDefault();
            return member.Status;
        }
        
    }
}
