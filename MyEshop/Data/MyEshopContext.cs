using Microsoft.EntityFrameworkCore;
using MyEshop.Models;

namespace MyEshop.Data
{
    public class MyEshopContext : DbContext
    {
        public MyEshopContext(DbContextOptions<MyEshopContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            //modelBuilder.Entity<Product>(
            //    p =>
            //    {
            //        p.HasKey(w => w.Id);
            //        p.OwnsOne<Item>(w => w.Item);
            //        p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
            //        .HasForeignKey<Item>(w => w.Id);
            //    }
            //    );

            modelBuilder.Entity<Item>(
                i =>
                {
                    i.HasKey(w => w.Id);
                    i.Property(w => w.Price).HasColumnType("Money");
                }
                );

            #region Seed Data Category
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "لباس ورزشی مردانه",
                    Description = "گروه لباس ورزشی مردانه"
                },
                 new Category()
                 {
                     Id = 2,
                     Name = "لباس ورزشی زنانه",
                     Description = "گروه لباس ورزشی زنانه"
                 },
                  new Category()
                  {
                      Id = 3,
                      Name = "توپ ورزشی",
                      Description = "گروه توپ ورزشی"
                  },
                   new Category()
                   {
                       Id = 4,
                       Name = "اکسسوری های ورزشی",
                       Description = "گروه اکسسوری های ورزشی"
                   });
            #endregion
            #region Seed Data Item
            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    Price = 345.0M,
                    QuantityInStock = 5
                },
                new Item()
                {
                    Id = 2,
                    Price = 350.0M,
                    QuantityInStock = 8
                },
                new Item()
                {
                    Id = 3,
                    Price = 360.0M,
                    QuantityInStock = 3
                }
                );
            #endregion
            #region Seed Data Product
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ItemId = 1,
                    Name = "تیشرت ورزشی مردانه نایک مدل Dri Fit-1644 قرمز",
                    Description = "جنس: پلی استر، وارداتی: ساخت تایلند (High Copy)، قواره: فیت، نوع یقه: گرد، جنس و کیفیت بسیار بالا"
                },
                new Product()
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "تیشرت ورزشی مردانه آندر آرمور مدل Heat Sign-1639 طوسی تیره",
                    Description = "جنس: پلی استر، وارداتی: ساخت تایلند (High Copy)، قواره: فیت، نوع یقه: گرد، جنس و کیفیت بسیار بالا"
                },
                new Product()
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "تیشرت ورزشی مردانه آدیداس مدل Tech-2202 چریکی قرمز",
                    Description = "جنس: پلی استر، وارداتی (High Copy)، قواره: آزاد، نوع یقه: گرد، دارای دوخت و چاپ باکیفیت"
                });
            #endregion
            #region Seed Data CategoryToProduct
            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct { CategoryId = 1, ProductId = 3 }
                );
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
