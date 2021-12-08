using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{   // Context demek veritabanı ile kendi classlarımı ilişkilendirdiğim classın ta kendisi.
    //Context: Db tabloloları ile proje class'larını bağlamak
    //DbContext yazdığım şet Entityframeworkten geliyor.
    //Bu proje çalıştığında hemen alta bakıkıyor framework ben nereye bağlanacağım?
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Bu metod senin prohen hangi veritabanı ile ilişkili belirteceğim yer.
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=Northwind;Trusted_Connection=true");//Hangi veri tabanına bağlanacağımızı sölüycez
        }
        //Benim hanginesmem hangi neseye karşılık gelecek. bunu Db set dediğim bir nesneyle yapıyporum. altta
        public DbSet<Product> Products { get; set; } //Benim Product nesnemi veri tabanınca ki Products a bağla
        public DbSet<Category> Categories { get; set; } //context db tabanları ile projelerimi bağlıyor, ama o veri tabanlarına hangi nesenelerim denk gelecek onu yazdık.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
