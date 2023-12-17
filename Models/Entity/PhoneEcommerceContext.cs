using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiPhoneEcommerce.Models.Entity;

public partial class PhoneEcommerceContext : DbContext
{
    public PhoneEcommerceContext()
    {
    }

    public PhoneEcommerceContext(DbContextOptions<PhoneEcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=connectString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0708AA8ABB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
