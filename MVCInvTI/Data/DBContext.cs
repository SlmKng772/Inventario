using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCInvTI.Models;

namespace MVCInvTI.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<MVCInvTI.Models.CadCli> CadCli { get; set; } = default!;

        public DbSet<MVCInvTI.Models.CadProd> CadProd { get; set; } = default!;

        public DbSet<MVCInvTI.Models.InvMaq> InvMaq { get; set; } = default!;

        public DbSet<MVCInvTI.Models.InvSoft> InvSoft { get; set; } = default!;
    }
}
