using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarsStore.Models
{
    public class UserRoleProvider : RoleProvider
    {
        ApplicationDbContext db0 = new ApplicationDbContext();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            if (roleName == null || roleName == "")
                throw new Exception("Role name cannot be empty or null.");
            if (roleName.Contains(","))
                throw new Exception("Role names cannot contain commas.");
            if (RoleExists(roleName))
                throw new Exception("Role name already exists.");
            if (roleName.Length > 255)
                throw new Exception("Role name cannot exceed 255 characters.");
            var role = new IdentityRole(roleName);
            db0.Roles.Add(role);
            db0.SaveChanges();
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
            throw new NotImplementedException();
        }

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
            if (roleName == null || roleName == "")
                throw new Exception("Role name cannot be empty or null.");
            IEnumerable<IdentityRole> roles = db0.Roles.ToList();
            foreach( IdentityRole role in roles)
            {
                if (role.Name.Equals(roleName))
                    return true;
            }
            return false;
        }
    }
}