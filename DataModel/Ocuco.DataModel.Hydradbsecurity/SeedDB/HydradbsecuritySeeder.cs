using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Ocuco.DataModel.Hydradbsecurity.Context;
using Ocuco.DataModel.Hydradbsecurity.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.DataModel.Hydradbsecurity.SeedDB
{
    public class HydradbsecuritySeeder
    {
        private readonly HydraSecurityContext ctx;
        private readonly IHostingEnvironment hosting;
        private readonly UserManager<HubUser> userManager;

        public HydradbsecuritySeeder(HydraSecurityContext ctx, IHostingEnvironment hosting, UserManager<HubUser> userManager)
        {
            this.ctx = ctx;
            this.hosting = hosting;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            ctx.Database.EnsureCreated();

            HubUser user = await userManager.FindByEmailAsync("daniel.tassi@ocuco.com"); 
            if (user == null)
            {
                user = new HubUser()
                {
                    FirstName = "Daniel",
                    LastName = "Tassi",
                    Email = "daniel.tassi@ocuco.com",
                    UserName = "daniel.tassi@ocuco.com"
                };

                var result = await userManager.CreateAsync(user, "P@55w0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
            }
        }
    }
}
