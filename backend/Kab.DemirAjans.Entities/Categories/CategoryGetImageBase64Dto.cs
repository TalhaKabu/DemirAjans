using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.Entities.Categories;

public class CategoryGetImageBase64Dto
{
    public Guid ImageName { get; set; }
    public string Base64 { get; set; }
}