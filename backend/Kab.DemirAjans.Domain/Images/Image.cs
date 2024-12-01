using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.Domain.Images;

public class Image
{
    public Guid Id { get; set; }

    [MaxLength(ImageConst.MaxPathLength)]
    public string? Path { get; set; }
}