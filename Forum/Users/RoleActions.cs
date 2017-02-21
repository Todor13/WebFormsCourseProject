using Forum.Data;
using Forum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Users
{
    internal class RoleActions
    {
        internal void AddUserAndRole()
        {
            // Access the application context and create result variables.
            ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            //var roleMgr = new RoleManager<IdentityRole>(roleStore);

            //var admin = roleMgr.Roles.Where(r => r.Name == "admin").SingleOrDefault();

            //if (admin == null)
            //{
            //    IdRoleResult = roleMgr.Create(new IdentityRole { Name = "admin" });
            //}

            //// Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            //// object. Note that you can create new objects and use them as parameters in
            //// a single line of code, rather than using multiple lines of code, as you did
            //// for the RoleManager object.

            //var userMgr = new UserManager<ApplicationUser, int>(new CustomUserStore(context));
            //var appUser = new ApplicationUser
            //{
            //    UserName = "admin@gmail.com",
            //    Email = "admin@gmail.com"
            //};
            //IdUserResult = userMgr.Create(appUser, "Pa$$word1");

            //// If the new "admin" user was successfully created, 
            //// add the "admin" user to the "admin" role. 
            //if (!userMgr.IsInRole(userMgr.FindByEmail("admin@gmail.com").Id, "admin"))
            //{
            //    IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("admin@gmail.com").Id, "admin");
            //}
        }
    }
}