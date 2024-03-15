﻿

namespace VideogamesStore.Domain.Abstractions.Entities
{
    public abstract class BaseAuditable
    {
        public Guid Id { get; init; }
        public Guid CreatedBy { get; init; }
        public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.Now;
    }
}
