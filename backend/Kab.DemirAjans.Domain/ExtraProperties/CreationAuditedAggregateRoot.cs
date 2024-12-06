using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kab.DemirAjans.Domain.ExtraProperties;

public abstract class CreationAuditedAggregateRoot : AggregateRoot
{
    public virtual DateTime CreationDate { get; protected set; }

    public override void SetDefaultExtraProperties(bool isInsert)
    {
        base.SetDefaultExtraProperties(isInsert);

        if (isInsert)
            CreationDate = DateTime.UtcNow;
    }
}
