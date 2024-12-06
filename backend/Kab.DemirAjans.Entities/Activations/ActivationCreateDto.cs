using System;

namespace Kab.DemirAjans.Entities.Activations;

public class ActivationCreateDto
{
    public string Email { get; set; }
    public string? Code { get; set; }
    public DateTime ExpirationDate { get; set; }
}