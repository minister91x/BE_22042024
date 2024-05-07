using EBook.DataAccess.NetCore.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DBContext
{
    public class EBookDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IFRSV3F;Initial Catalog=BE_22042024;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        }
        public virtual DbSet<Book> book {get;set;}

    }
}
