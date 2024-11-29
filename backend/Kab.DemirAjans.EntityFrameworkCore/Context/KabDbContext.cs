using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kab.DemirAjans.EntityFrameworkCore.Context;

public class KabDbContext(DbContextOptions<KabDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories {  get; set; }
    public DbSet<Product> Products { get; set; }
}