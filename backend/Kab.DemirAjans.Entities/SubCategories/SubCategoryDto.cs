﻿using Kab.DemirAjans.Entities.ExtraProperties;
using System;

namespace Kab.DemirAjans.Entities.SubCategories;

public class SubCategoryDto : AggregateRoot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Guid ImageName { get; set; }
    public int CategoryId { get; set; } 
    public int Skid { get; set; }
}