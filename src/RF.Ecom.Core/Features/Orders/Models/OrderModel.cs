namespace RF.Ecom.Core.Features.Orders.Models;

using System;
using System.Collections.Generic;

public sealed class OrderModel
{
    public int Id { get; init; }

    public Guid DomainId { get; init; }

    public string Reference { get; init; }

    public int Status { get; init; }

    public DateTimeOffset DateCreated { get; init; }

    public IEnumerable<ItemModel> Items { get; init; } = [];
}
