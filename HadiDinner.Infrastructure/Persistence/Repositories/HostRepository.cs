using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.Host;

namespace HadiDinner.Infrastructure.Persistence.Repositories;

public class HostRepository : IHostRepository
{
    private static readonly List<Host> _hosts = new();

    public void Add(Host host)
    {
        _hosts.Add(host);
    }

    public Host? GetHostById(string hostId)
    {
        var isHostIdParsed = Guid.TryParse(hostId, out Guid parsedHostId);
        if (!isHostIdParsed)
            return null;

        return _hosts.SingleOrDefault(host => host.Id.Value == parsedHostId);
    }
}
