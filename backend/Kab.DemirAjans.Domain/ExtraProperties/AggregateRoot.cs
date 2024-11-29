using System;

namespace Kab.DemirAjans.Domain.ExtraProperties;

public abstract class AggregateRoot
{
    public virtual void SetDefaultExtraProperties(bool isInsert)
    {
    }
}
