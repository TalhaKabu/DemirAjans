using Kab.DemirAjans.Domain.Activations;
using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Domain.Images;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Domain.SubCategories;
using Kab.DemirAjans.Domain.Users;
using Kab.DemirAjans.EntityFrameworkCore.ModelCreatingExtensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kab.DemirAjans.EntityFrameworkCore.Context;

public class KabDbContext(DbContextOptions<KabDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Activation> Activations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureKab();
    }
}