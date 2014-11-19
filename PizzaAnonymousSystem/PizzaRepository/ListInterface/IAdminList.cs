using PizzaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRepository.ListInterface
{
    public interface IAdminList
    {
        int? AddAdmin(Admin admin);
        Admin GetAdmin(int adminID);
        Boolean DeleteAdmin(int adminID);
        Admin UpdateAdmin(string name, int adminID, string streetAddress,
                                     string city, string state, string ZIPcode);
    }
}
