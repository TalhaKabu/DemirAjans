using Kab.DemirAjans.Entities.ExtraProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kab.DemirAjans.Entities.Activations;

public class ActivationDto : AggregateRoot
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Code { get; set; }
    public DateTime ExpirationDate { get; set; }
}