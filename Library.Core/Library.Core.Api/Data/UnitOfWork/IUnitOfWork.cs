using Microsoft.EntityFrameworkCore;

namespace Library.Core.Api.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }

        Task<int> AddAsync<T>(T obj) where T : class;
        ITransaction BeginTransaction();
        void Commit();
        Task CommitAsync();
        void Dispose();
        Task<IEnumerable<T>> QueryAsync<T>() where T : class;
        Task<int> RemoveAsync<T>(T obj) where T : class;
        Task<int> UpdateAsync<T>(T obj) where T : class;
    }
}