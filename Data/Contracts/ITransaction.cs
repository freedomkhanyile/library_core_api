using System;
namespace Data.Contracts
{
    public interface ITransaction: IDisposable
    {
        void Commit();
        void Rollback();
    }
}