using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Orders> Oders { get; set; }
        DbSet<Order_Detail> Order_Details { get; set; }

        DbSet<Discount_Code> Discounts { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Detail>().HasKey(u => new
            {
                u.ORDER_ID,
                u.MENU_ID
            });
            
            modelBuilder.Entity<Order_Detail>().Property(u => u.AMOUNT).HasDefaultValue(1);
            modelBuilder.Entity<Order_Detail>().Property(u => u.CODE_ID).HasDefaultValue("null");
           // modelBuilder.Entity<Account>().Property(u => u.MARK).HasDefaultValue(1);
            modelBuilder.Entity<Category>().Property(u => u.MARK).HasDefaultValue(1);
            modelBuilder.Entity<Menu>().Property(u => u.MARK).HasDefaultValue(1);
            modelBuilder.Entity<Discount_Code>().Property(u => u.MARK).HasDefaultValue(1);
            modelBuilder.Entity<Discount_Code>().Property(u => u.PERCENTS).HasDefaultValue(0);
            modelBuilder.Entity<Orders>().Property(u => u.PAYMENT_TYPE).HasDefaultValue(1);
            modelBuilder.Entity<Orders>().Property(u => u.RECEIVED).HasDefaultValue(0);
            modelBuilder.Entity<Orders>().Property(u => u.DELIVERED).HasDefaultValue(0);

            //Data Seeding  
            modelBuilder.Entity<Account>().HasData(new { ADMIN_ID=7,USERNAME = "ducanhdeptraivodichvutru", PASSWD = "123", MARK = 0 });
            modelBuilder.Entity<Account>().HasData(new { ADMIN_ID = 8, USERNAME = "ducanh@gmail.com", PASSWD = "123456!", MARK = 0 });
            modelBuilder.Entity<Category>().HasData(new { CATE_ID=1,CATE_NAME = "Món rau", CATE_IMG = "https://ibb.co/XF73tQf", CATE_DESCRIPTION= "Gồm nhiều chất xơ và vitamin hỗ trợ giảm cân" });
            modelBuilder.Entity<Category>().HasData(new { CATE_ID = 2,CATE_NAME = "Trái cây", CATE_IMG = "https://ibb.co/Gc11tnM", CATE_DESCRIPTION = "Gồm nhiều vitamin và dưỡng chất" });
            modelBuilder.Entity<Discount_Code>().HasData(new { CODE_ID= "BLACKFRIDAY", CODE_NAME= "Thứ sáu đen tối", PERCENTS =50, MARK=1});
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID=1,MENU_NAME = "Rau trộn", MENU_SIZE=1, MENU_PRICE= 20000.00d, CALORIES= 50.00f, MENU_IMG= "https://picsum.photos/200", MENU_DESCRIPTION= "1 cây xà lách, 1/2 trái dưa leo, 2 trái cà chua", CATE_ID=4 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID=2,MENU_NAME = "Rau trộn", MENU_SIZE = 2, MENU_PRICE = 10000.00d, CALORIES = 50.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "2 cây xà lách, 1 trái dưa leo, 4 trái cà chua", CATE_ID = 4 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID=3,MENU_NAME = "Rau luộc", MENU_SIZE = 1, MENU_PRICE = 20000.00d, CALORIES = 50.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "1/2 kg rau muống", CATE_ID = 4 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID = 4,MENU_NAME = "Rau luộc", MENU_SIZE = 2, MENU_PRICE = 10000.00d, CALORIES = 50.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "1 kg rau muống", CATE_ID = 4 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID = 5,MENU_NAME = "Trái cây tô", MENU_SIZE = 1, MENU_PRICE = 30000.00d, CALORIES = 50.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "trái cây", CATE_ID = 5 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID = 6,MENU_NAME = "Trái cây tô", MENU_SIZE = 2, MENU_PRICE = 50000.00d, CALORIES = 50.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "trái cây", CATE_ID = 5 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID = 7,MENU_NAME = "Trái cây tô", MENU_SIZE = 3, MENU_PRICE = 79000.00d, CALORIES = 50.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "trái cây", CATE_ID = 5 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID = 8,MENU_NAME = "Sinh tố bơ", MENU_SIZE = 1, MENU_PRICE = 25000.00d, CALORIES = 250.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "1 bơ", CATE_ID = 4 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID = 9,MENU_NAME = "Sinh tố bơ", MENU_SIZE = 2, MENU_PRICE = 30000.00d, CALORIES = 250.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "2 bơ", CATE_ID = 4 });
            modelBuilder.Entity<Menu>().HasData(new { MENU_ID = 10,MENU_NAME = "Sinh tố bơ", MENU_SIZE = 3, MENU_PRICE = 35000.00d, CALORIES = 250.00f, MENU_IMG = "https://picsum.photos/200", MENU_DESCRIPTION = "3 bơ", CATE_ID = 4 });






        }

    }
}
