using PreduzeceProjektniCentar.Models.Interfaces;
using PreduzeceProjektniCentar.Models.LinqSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreduzeceProjektniCentar.Models.EFRepository
{
    public class AuthRepository : IAuthRepository
    {
        private PreduzecaDataContext pDC = new PreduzecaDataContext();
        public void AddUser(UserBO userBO)
        {
            if (IsValid(userBO)) return;

            User user = new User() {
            Username = userBO.Username,
            Password = userBO.Password
            };
            pDC.Users.InsertOnSubmit(user);
            pDC.SubmitChanges();
             
        }

        public bool IsValid(UserBO userBO)
        {
            bool isValid = pDC.Users.Any(t => t.Username == userBO.Username && t.Password == userBO.Password);
            return isValid;
        }
    }
}