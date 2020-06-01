using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreduzeceProjektniCentar.Models.Interfaces
{
    interface IAuthRepository
    {
        bool IsValid(UserBO userBO);

        void AddUser(UserBO userBO);
    }
}
