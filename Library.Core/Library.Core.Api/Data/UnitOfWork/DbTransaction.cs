using Microsoft.EntityFrameworkCore.Storage;

namespace Library.Core.Api.Data.UnitOfWork
{
    public class DbTransaction : ITransaction
    {
        private readonly IDbContextTransaction _efTransaction;

        public DbTransaction(IDbContextTransaction efTransaction)
        {
            _efTransaction = efTransaction;
        }

        public void Commit()
        {
            _efTransaction.Commit();
        }

        public void Dispose()
        {
            _efTransaction.Dispose();
        }

        public void Rollback()
        {
            _efTransaction.Rollback();
        }

    }
}
