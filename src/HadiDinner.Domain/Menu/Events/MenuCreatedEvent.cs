using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Menu.Events;

public record MenuCreatedEvent(Menu Menu) : IDomainEvent;
