namespace Kab.DemirAjans.Entities.SubCategories;

public class SubCategoryCreateDto
{
    public string Name { get; set; }
    public string? Base64 { get; set; }
    public int CategoryId { get; set; }
    public int Skid { get; set; }
}