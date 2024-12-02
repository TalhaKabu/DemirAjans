using Kab.DemirAjans.Domain.Categories;
using Kab.DemirAjans.Domain.Images;
using Kab.DemirAjans.Domain.Products;
using Kab.DemirAjans.Domain.SubCategories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kab.DemirAjans.EntityFrameworkCore.ModelCreatingExtensions;

public static class KabDbContextModelCreatingExtensions
{
    public static void ConfigureKab(this ModelBuilder builder)
    {
        #region Category
        builder.Entity<Category>(typeBuilder =>
        {
            typeBuilder.HasMany<SubCategory>().WithOne();
            typeBuilder.HasMany<Product>().WithOne();
            typeBuilder.Property(t => t.ImageName).HasDefaultValue(Guid.Empty);
        });
        #endregion

        #region Category
        builder.Entity<SubCategory>(typeBuilder =>
        {
            typeBuilder.HasMany<Product>().WithOne();
        });
        #endregion

        #region Product
        builder.Entity<Product>(typeBuilder =>
        {
            typeBuilder.Property(t => t.CategoryId).IsRequired();
            typeBuilder.HasMany<Image>().WithOne();
        });
        #endregion

        #region Image
        builder.Entity<Image>(typeBuilder =>
        {
            typeBuilder.Property(t => t.ProductId).IsRequired();
        });
        #endregion
    }
}
