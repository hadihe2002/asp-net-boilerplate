using HadiDinner.Domain.Menu.Events;
using MediatR;

namespace HadiDinner.Application.Menus.Events;

public class MenuCreatedEventHandler : INotificationHandler<MenuCreatedEvent>
{
    public Task Handle(MenuCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
