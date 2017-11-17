namespace BLL.BLs
{
    using DAL.Interfaces;
    using System;

    public abstract class BaseBL
    {
        private IUnitOfWorkFactory factory;

        public BaseBL(IUnitOfWorkFactory factory)
        {
            this.factory = factory;
        }

        protected TEntity UseDb<TEntity>(Func<IUnitOfWork, TEntity> func)
        {
            using (IUnitOfWork unitOfWork = factory.Create())
            {
                return func(unitOfWork);
            }
        }

        protected void UseDb(Action<IUnitOfWork> func)
        {
            using (IUnitOfWork unitOfWork = factory.Create())
            {
                func(unitOfWork);
            }
        }
    }
}
