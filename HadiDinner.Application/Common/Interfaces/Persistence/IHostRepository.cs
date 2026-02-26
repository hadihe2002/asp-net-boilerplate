using HadiDinner.Domain.Host;

namespace HadiDinner.Application.Common.Interfaces.Persistence;

public interface IHostRepository
{
    public void Add(Host host);
    public Host? GetHostById(string hostId);
}
