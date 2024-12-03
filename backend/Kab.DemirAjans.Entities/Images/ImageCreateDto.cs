using System;

namespace Kab.DemirAjans.Entities.Images;

public class ImageCreateDto
{
    public int ProductId { get; set; }
    public bool IsFrontImage { get; set; }
}