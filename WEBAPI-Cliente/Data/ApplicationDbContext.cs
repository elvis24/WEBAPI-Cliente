using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_Cliente.Modelo;

namespace WEBAPI_Cliente.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
