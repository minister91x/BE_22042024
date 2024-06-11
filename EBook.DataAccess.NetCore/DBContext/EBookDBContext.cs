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
        public EBookDBContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   /// optionsBuilder.UseSqlServer("Data Source=DESKTOP-IFRSV3F;Initial Catalog=BE_22042024;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        //}
        public virtual DbSet<Book> book {get;set;}

        public virtual DbSet<Product> product { get; set; }
        public virtual DbSet<ProductAttribute> productAttribute { get; set; }
        public virtual DbSet<Orders> order { get; set; }
        public virtual DbSet<Account> account { get; set; }
    }
}
