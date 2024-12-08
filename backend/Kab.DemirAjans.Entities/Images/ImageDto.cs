using Kab.DemirAjans.Entities.ExtraProperties;
using System;

namespace Kab.DemirAjans.Entities.Images;

public class ImageDto : AggregateRoot
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public bool IsFrontImage { get; set; }
    public string Base64 { get; set; }
}