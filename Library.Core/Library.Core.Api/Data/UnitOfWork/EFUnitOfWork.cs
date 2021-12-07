using Microsoft.EntityFrameworkCore;

namespace Library.Core.Api.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public EFUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        public ITransaction BeginTransaction()
        {
            return new DbTransaction(_context.Database.BeginTransaction());
        }
        public async Task<IEnumerable<T>> QueryAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<int> AddAsync<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            await set.AddAsync(obj);
            return 1;
        }
        public async Task<int> UpdateAsync<T>(T obj) where T : class
        {
            var set = _context.Set<T>();
            set.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return 1;
        }
        public Task<int> RemoveAsync<T>(T obj) where T : class
        {
            _context.Set<T>().Attach(obj);
            _context.Set<T>().Remove(obj);
            return Task.FromResult(1);
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
            _context = null;
        }


    }
}
