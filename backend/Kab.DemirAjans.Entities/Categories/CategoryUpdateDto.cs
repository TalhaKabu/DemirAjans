using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.Entities.Categories;

public class CategoryUpdateDto
{
    public string? Name { get; set; }
    public string? Base64 { get; set; }
    public bool? AppearInFront { get; set; }
}