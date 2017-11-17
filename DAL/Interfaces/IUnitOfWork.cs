namespace DAL.Interfaces
{
    using DAL.Entities;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<UserEntity> UserRepository { get; }

        IGenericRepository<UserNoteEntity> UserNoteRepository { get; }

        void Save();
    }
}
