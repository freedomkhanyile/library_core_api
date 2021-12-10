using System;

namespace Library.Core.Api.Data.UnitOfWork
{
    public interface ITransaction: IDisposable
    {
        void Commit();
        void Dispose();
        void Rollback();
    }
}