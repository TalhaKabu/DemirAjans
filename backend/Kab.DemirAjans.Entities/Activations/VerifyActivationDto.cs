using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.Entities.Activations;

public class VerifyActivationDto
{
    public string Code { get; set; }
    public string Email { get; set; }
}