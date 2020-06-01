using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using PreduzeceProjektniCentar.Models.Interfaces;
using PreduzeceProjektniCentar.Models.LinqSql;

namespace PreduzeceProjektniCentar.Models
{
    public class UsersRoleProvider : RoleProvider
    {
        private PreduzecaDataContext pDC = new PreduzecaDataContext();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            User user = pDC.Users.FirstOrDefault(t => t.Username == username);
            return user.UserRoles.Select(t => t.Role.Naziv).ToArray();
        }// Vraca sve role koje ima odredjeni korisnik

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}