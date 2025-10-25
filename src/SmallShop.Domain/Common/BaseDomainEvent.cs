using MediatR;

namespace SmallShop.Domain.Common;

public class BaseDomainEvent : INotification
{
    public DateTime CreationDate { get; protected set; }

    public BaseDomainEvent()
    {
        CreationDate = DateTime.Now;
    }
}