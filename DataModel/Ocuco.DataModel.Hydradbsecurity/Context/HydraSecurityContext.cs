using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ocuco.DataModel.Hydradbsecurity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.DataModel.Hydradbsecurity.Context
{
    public class HydraSecurityContext : IdentityDbContext<HubUser>
    {
        public HydraSecurityContext(DbContextOptions<HydraSecurityContext> options) : base(options)
        {

        } 


        
    }
}
