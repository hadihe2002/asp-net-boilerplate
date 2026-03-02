namespace HadiDinner.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync();
}
