using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModels.Models;

namespace PizzaRepository.ListInterface
{
    public interface IMemberList
    {
        Boolean InsertMember(Member member);
        Member GetMember(int memberID);
        Boolean DeleteMember(int memberID);
        Boolean UpdateMember(string name, int memberID, string streetAddress,
                                     string city, string state, string ZIPcode, int status);
    }
}
