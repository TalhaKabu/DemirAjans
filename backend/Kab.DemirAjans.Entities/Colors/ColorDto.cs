using Kab.DemirAjans.Entities.ExtraProperties;

namespace Kab.DemirAjans.Entities.Colors;

public class ColorDto : AggregateRoot
{
    public string? Name { get; set; }
    public string Code { get; set; }
    public string Header { get; set; }
    public int ProductId { get; set; }
    public int Uid { get; set; }
    public Guid ImageName { get; set; }
    public string Base64 { get; set; }
}