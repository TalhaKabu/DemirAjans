using Kab.DemirAjans.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kab.DemirAjans.EntityFrameworkCore.ModelCreatingExtensions;

public static class KabDbContextModelCreatingExtensions
{
    private static readonly string IesTablePrefix = "IesMirror";
    public static void ConfigureIes(this ModelBuilder builder)
    {
        #region Template
        builder.Entity<Product>(typeBuilder =>
        {
            //typeBuilder.Property(t => t.Id).IsRequired();
        });
        #endregion
    }
}
