using IdentityTesting2.Models;
using System.Data.Entity.Migrations;

namespace IdentityTesting2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityTesting2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentityTesting2.Models.ApplicationDbContext context)
        {
            this.AddUserAndRoles();
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityTesting2.Models.ApplicationDbContext.IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("CanEdit");
            if (!success == true) return success;

            success = idManager.CreateRole("User");
            if (!success) return success;


            var newUser = new ApplicationUser()
            {
                UserName = "jatten",
                Email = "jatten@typecastexception.com"
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password1");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;

            return success;
        }
    }
}
