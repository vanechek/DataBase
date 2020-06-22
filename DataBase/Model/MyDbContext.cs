using DataBase.Model.Table;
using System.Data.Entity;

namespace DataBase.Model
{
    class MyDbContext : DbContext
    {
        public MyDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Gu12> Gu12s { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Send> Sends { get; set; }
        public DbSet<Math> Maths { get; set; }
        public DbSet<Consignment> Consignments { get; set; }
        public DbSet<SupplySchedule> SupplySchedules { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
