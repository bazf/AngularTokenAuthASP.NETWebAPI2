using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private DevComDbContext context = new DevComDbContext();


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
