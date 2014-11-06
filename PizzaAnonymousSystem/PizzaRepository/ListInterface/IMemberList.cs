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
        List<Member> GetMembers();
        Boolean DeleteMember(int memberID);
        Boolean UpdateMember(int memberID, int _status);
    }
}
