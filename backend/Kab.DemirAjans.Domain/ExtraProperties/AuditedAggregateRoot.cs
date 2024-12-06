using System;

namespace Kab.DemirAjans.Domain.ExtraProperties;

public abstract class AuditedAggregateRoot : CreationAuditedAggregateRoot
{
    public virtual DateTime? LastModificationDate { get; protected set; }

    public override void SetDefaultExtraProperties(bool isInsert)
    {
        base.SetDefaultExtraProperties(isInsert);

        if (!isInsert)
            LastModificationDate = DateTime.UtcNow;
    }
}
