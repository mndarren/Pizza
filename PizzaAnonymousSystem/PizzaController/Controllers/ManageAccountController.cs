using AttributeRouting.Web.Http;
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
    public class ManageAccountController : ApiController
    {
        private readonly IAdminList adminList;
        private readonly IManagerList managerList;
        private readonly IMemberList memberList;
        private readonly IProviderList providerList;

        public ManageAccountController(IAdminList adminList, IManagerList managerList, 
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
        [HttpPost]
        [POST("api/accountmanager/account/member")]
        public Boolean AddMember([FromBody]Member member)
        {   
           return memberList.InsertMember(member);
        }

        [HttpDelete]
        [DELETE("api/accountmanager/account/member/{memberID}")]
        public Boolean DeleteMember([FromUri]int memberID)
        {
            return memberList.DeleteMember(memberID);
        }

        [HttpPut]
        [PUT("api/accountmanager/account/member")]
        public Member UpdateMember([FromBody]/*string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode, int status*/ Member member)
        {
            string name = member.Name;
            int ID = member.ID;
            string streetAddress = member.StreetAddress;
            string city = member.City;
            string state = member.State;
            string ZIPcode = member.ZipCode;
            int status = member.Status;

            return memberList.UpdateMember(name, ID, streetAddress, city, state, ZIPcode, status);
        }

        /********************************************
         * Provider
         * *****************************************/
        [HttpPost]
        [POST("api/accountmanager/account/provider")]
        public Boolean AddProvider([FromBody]Provider provider)
        {
            return providerList.AddProvider(provider);
        }

        [HttpDelete]
        [DELETE("api/accountmanager/account/provider/{providerID}")]
        public Boolean DeleteProvider([FromUri]int providerID)
        {
            return providerList.DeleteProvider(providerID);
        }

        [HttpPut]
        [PUT("api/accountmanager/account/provider")]
        public Provider UpdateProvider([FromBody]/*string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode, long bankAccount*/ Provider provider)
        {
            string name = provider.Name;
            int ID = provider.ID;
            string streetAddress = provider.StreetAddress;
            string city = provider.City;
            string state = provider.State;
            string ZIPcode = provider.ZipCode;
            long bankAccount = provider.BankAccount;

            var result = providerList.UpdateProvider(name,ID,streetAddress,city,state,ZIPcode,bankAccount);
            return result;
        }

        /********************************
         * Manager
         * ************************************/
        [HttpPost]
        [POST("api/accountmanager/account/manager")]
        public Boolean AddManager([FromBody]Manager manager)
        {
            return managerList.InsertManager(manager);
        }
        
        [HttpDelete]
        [DELETE("api/accountmanager/account/manager/{managerID}")]
        public Boolean DeleteManager([FromUri]int managerID)
        {
            return managerList.DeleteManager(managerID);
        }

        [HttpPut]
        [PUT("api/accountmanager/account/manager")]
        public Manager UpdateManager([FromBody]/*string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode*/ Manager manager)
        {
            string name = manager.Name;
            int ID = manager.ID;
            string streetAddress = manager.StreetAddress;
            string city = manager.City;
            string state = manager.State;
            string ZIPcode = manager.ZipCode;

            return managerList.UpdateManager(name, ID, streetAddress,
                                     city, state, ZIPcode);
        }

        /**********************
         * admin
         * *******************/
        [HttpPost]
        [POST("api/accountmanager/account/admin")]
        public Boolean addAdmin([FromBody] Admin admin)
        {
            return adminList.addAdmin(admin);
        }

        [HttpDelete]
        [DELETE("api/accountmanager/account/admin/{adminID}")]
        public Boolean DeleteAdmin([FromUri]int adminID)
        {
            return adminList.DeleteAdmin(adminID);
        }

        [HttpPut]
        [PUT("api/accountmanager/account/admin")]
        public Admin UpdateAdmin([FromBody]/*string name, int ID, string streetAddress,
                                     string city, string state, string ZIPcode*/Admin admin)
        {
            string name = admin.Name;
            int ID = admin.ID;
            string streetAddress = admin.StreetAddress;
            string city = admin.City;
            string state = admin.State;
            string ZIPcode = admin.ZipCode;

            return adminList.UpdateAdmin(name,ID,streetAddress,city,state,ZIPcode);
        }
        
        /*************************************
         * validate member
         * **********************************/
        [HttpPost]
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
