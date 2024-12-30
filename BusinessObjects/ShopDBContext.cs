using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects
{
    public class ShopDBContext:DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options) { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WishList>()
                .HasOne(w=>w.User)
                .WithMany(c=>c.WishLists)
                .HasForeignKey(w => w.UserId)
                .IsRequired();
            modelBuilder.Entity<WishList>()
                .HasOne(w=>w.Product)
                .WithMany(p=>p.WishLists)
                .HasForeignKey(p => p.ProductId)
                .IsRequired();
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Product>(p => p.InventoryId)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasOne(p => p.TypeAttribute)
                .WithMany(pa => pa.TypeProducts)
                .HasForeignKey(p => p.TypeAttibuteId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.SizeAttribute)
                .WithMany(pa => pa.SizeProducts)
                .HasForeignKey(p => p.SizeAttibuteId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ColorAttribute)
                .WithMany(pa => pa.ColorProducts)
                .HasForeignKey(p => p.ColorAttibuteId);
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .IsRequired();
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .IsRequired();
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne(od => od.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(od => od.UserId)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi=>oi.Order)
                .WithMany(o=>o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .IsRequired();
            modelBuilder.Entity<PaymentDetail>()
                .HasOne(p => p.Order)
                .WithOne(o => o.PaymentDetail)
                .HasForeignKey<PaymentDetail>(p => p.OrderId)
                .IsRequired();
        }
    }
}
