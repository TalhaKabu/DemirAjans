using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.Entities.ExtraProperties;

public abstract class AggregateRoot
{
    public virtual DateTime CreationDate { get; set; }
    public virtual DateTime? LastModificationDate { get; set; }
}