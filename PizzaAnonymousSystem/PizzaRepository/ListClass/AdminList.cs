using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaRepository.ListClass;

namespace PizzaRepository.ListClass
{
    public class AdminList : IAdminList
    {
        private LinkedList<Admin> listOfAdmin = new LinkedList<Admin>();

        private static AdminList adminList;

        //create an admin list instance
        public static AdminList Instance()
        {
            if (adminList == null)
            {
                return (adminList = new AdminList());
            }
            else
            {
                return adminList;
            }
        }

        public AdminList() { }

        //add admin into list
        public Boolean addAdmin(Admin admin)
        {
            listOfAdmin.AddLast(admin);
            return true;
        }

        //delete admin from link list
        public Boolean deleteAdmin(int adminID) 
        {
            LinkedListNode<Admin> admin = listOfAdmin.First;
            while (admin != listOfAdmin.Last) 
            {
                if (adminID == admin.Value.ID)
                {
                    listOfAdmin.Remove(admin);
                    return true;
                }
                else
                    admin = admin.Next;
            }
            return false;
        }
             
        //Update  status
        public Boolean updateAdmin(int _adminID, string _adminName, string _adminAddress,
                       string _adminState, string _adminCity, string _adminZip)
        {
            LinkedListNode<Admin> admin = listOfAdmin.First;
            while (admin != listOfAdmin.Last)
            {
                if (admin.Value.ID == memberID)
                {
                    admin.Value.adminName = _adminName;
                    admin.Value.adminAddress = _adminAddress;
                    admin.Value.adminState = _adminState;
                    admin.Value.adminCiry = _adminCity;
                    admin.Value.adminZip = _adminZip;
                    return true;
                }
                else  
                    admin = admin.Next;
            }
            return false;
        }

        public LinkedList<Admin> getAdminList()
        {
            return listOfAdmin;
        }

        //public void WriteToFile()
        //{
        //
        //}

        //public void ReadFromFile()
        //{
        //
        //}

    }
}