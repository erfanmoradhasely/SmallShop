using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallShop.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Infrastructure.Identity.DbContext
{
    public class SmallShopIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public SmallShopIdentityDbContext(DbContextOptions<SmallShopIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SmallShopIdentityDbContext).Assembly);
        }
    }
}
