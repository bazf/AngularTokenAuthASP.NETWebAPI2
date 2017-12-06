namespace DAL.Interfaces.Implementations
{
    using DAL.Entities;
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        private NotesAppContext context = new NotesAppContext();


        private IGenericRepository<UserEntity> userRepository;

        private IGenericRepository<UserNoteEntity> userNoteEntity;


        public IGenericRepository<UserEntity> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<UserEntity>(context);
                }

                return userRepository;
            }
        }

        public IGenericRepository<UserNoteEntity> UserNoteRepository
        {
            get
            {
                if (userNoteEntity == null)
                {
                    userNoteEntity = new GenericRepository<UserNoteEntity>(context);
                }

                return userNoteEntity;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
