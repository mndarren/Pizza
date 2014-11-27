using AttributeRouting.Web.Http;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaModels.Models;
using System.Web.Http.Cors;

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


        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }


        /************************************
         * member
         ***********************************/
        [EnableCors("*","*", "*")]
        [HttpPost]
        [POST("api/accountmanager/account/member")]
        public int? AddMember([FromBody]Member member)
        {
            var memberId = new int?();

            try
            {
                memberId = memberList.InsertMember(member);
            }
            catch (Exception e)
            {
                memberId = null;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return memberList.InsertMember(member);
        }

        [EnableCors("*", "*", "*")]
        [HttpDelete]
        [DELETE("api/accountmanager/account/member/{memberID}")]
        public Boolean DeleteMember([FromUri]int memberID)
        {
            var success = false;

            try
            {
                success = memberList.DeleteMember(memberID);
            }
            catch (Exception e)
            {
                success = false;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return success;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp fix for CORS PUT
        [POST("api/accountmanager/account/put/member")]
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
            Member tempmember = new Member();
            try
            {
                tempmember = memberList.UpdateMember(name, ID, streetAddress, city, state, ZIPcode, status);
                if (null == tempmember) throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "member not found"));
            }
            catch (Exception e)
            {
                tempmember = null;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }
            return tempmember;
        }
        
        /********************************************
         * Provider
         * *****************************************/
        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/accountmanager/account/provider")]
        public int? AddProvider([FromBody]Provider provider)
        {
            return providerList.AddProvider(provider);
        }

        [EnableCors("*", "*", "*")]
        [HttpDelete]
        [DELETE("api/accountmanager/account/provider/{providerID}")]
        public Boolean DeleteProvider([FromUri]int providerID)
        {
            return providerList.DeleteProvider(providerID);
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp fix for CORS PUT
        [POST("api/accountmanager/account/put/provider")]
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
        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/accountmanager/account/manager")]
        public int? AddManager([FromBody]Manager manager)
        {
            return managerList.InsertManager(manager);
        }

        [EnableCors("*", "*", "*")]
        [HttpDelete]
        [DELETE("api/accountmanager/account/manager/{managerID}")]
        public Boolean DeleteManager([FromUri]int managerID)
        {
            return managerList.DeleteManager(managerID);
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp fix for CORS PUT
        [POST("api/accountmanager/account/put/manager")]
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
        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/accountmanager/account/admin")]
        public int? addAdmin([FromBody] Admin admin)
        {
            return adminList.AddAdmin(admin);
        }

        [EnableCors("*", "*", "*")]
        [HttpDelete]
        [DELETE("api/accountmanager/account/admin/{adminID}")]
        public Boolean DeleteAdmin([FromUri]int adminID)
        {
            return adminList.DeleteAdmin(adminID);
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp fix for CORS PUT
        [POST("api/accountmanager/account/put/admin")]
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
        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/accountmanager/validation/member/{memberID}")]
        public string ValidateMember([FromUri]int memberID){
            var member = memberList.GetMember(memberID);
            if (member == null) return "Invalid!";
            if (member.Status == -1) { return "Validate!"; }
            else if (member.Status == 0) { return "Invalid!"; }
            else if (member.Status == 1) { return "Suspend!"; }
            else return null;
        }


        [EnableCors("*", "*", "*")]
        [HttpPost]
        [POST("api/accountmanager/validation/provider/{providerID}")]
        public string ValidateProvider([FromUri] int providerID)
        {
            var provider = providerList.GetProvider(providerID);
            if (provider == null) { return "Invalid!"; }
            else  return "Validate!"; 
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp Fix for GET
        [POST("api/accountmanager/account/get/member/{memberID}")]
        public Member GetMember([FromUri]int memberID)
        {
            var member = new Member();

            try
            {
                member = memberList.GetMember(memberID);
                if (null == member) throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "member not found"));
            }
            catch (Exception e)
            {
                member = null;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return member;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp Fix for GET
        [POST("api/accountmanager/account/get/provider/{providerID}")]
        public Provider GetProvider([FromUri]int providerID)
        {
            var provider = new Provider();

            try
            {
                provider = providerList.GetProvider(providerID);
                if (null == provider) throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "provider not found"));
            }
            catch (Exception e)
            {
                provider = null;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return provider;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp Fix for GET
        [POST("api/accountmanager/account/get/manager/{managerID}")]
        public Manager GetManager([FromUri]int managerID)
        {
            var manager = new Manager();

            try
            {
                manager = managerList.GetManager(managerID);
                if (null == manager) throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "manager not found"));
            }
            catch (Exception e)
            {
                manager = null;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return manager;
        }

        [EnableCors("*", "*", "*")]
        [HttpPost] //Temp Fix for GET
        [POST("api/accountmanager/account/get/admin/{adminID}")]
        public Admin GetAdmin([FromUri]int adminID)
        {
            var admin = new Admin();

            try
            {
                admin = adminList.GetAdmin(adminID);
                if (null == admin) throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "admin not found"));
            }
            catch (Exception e)
            {
                admin = null;
                var error = e.Message;
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return admin;
        }
    }
}
