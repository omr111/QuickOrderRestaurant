using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace QuickOrder.WebMVC.Models
{
    public class userRoleProvider:RoleProvider
    {
        QuickOrder.UnitOfWork.Concrete.UnitOfWork ctx =new QuickOrder.UnitOfWork.Concrete.UnitOfWork();
       
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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

            List<roleOfUsers> roleOfUsers = ctx.roleOfUserBll.getAllByEmail(username);
          
           string[] roles=new string[roleOfUsers.Count];
           if (roleOfUsers.Count>0)
           {
               for (int i = 0; i < roles.Length; i++)
               {
                   foreach (var item in roleOfUsers)
                   {
                       roles[i] = item.roles.roleName.Trim();
                       roleOfUsers.Remove(item);
                       break;
                   }
               }
              
               return roles;
           }return new string[]{""};
        

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
            throw new NotImplementedException();
        }
    }
}