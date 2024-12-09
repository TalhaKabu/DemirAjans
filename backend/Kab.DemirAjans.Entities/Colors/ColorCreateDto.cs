namespace Kab.DemirAjans.Entities.Colors;

public class ColorCreateDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int ProductId { get; set; }
    public int Uid { get; set; }
    public string Base64 { get; set; }
}