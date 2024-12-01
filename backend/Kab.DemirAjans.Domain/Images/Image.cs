using System.ComponentModel.DataAnnotations;
using System;
using Kab.DemirAjans.Domain.ExtraProperties;

namespace Kab.DemirAjans.Domain.Images;

public class Image : AuditedAggregateRoot
{
    public Guid Id { get; set; }

    [MaxLength(ImageConst.MaxPathLength)]
    public string? Path { get; set; }
    public bool IsFrontImage { get; set; }
    public required int ProductId { get; set; }
}