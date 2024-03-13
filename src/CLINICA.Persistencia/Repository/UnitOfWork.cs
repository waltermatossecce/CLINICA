using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;

namespace CLINICA.Persistencia.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Analysis> Analysis { get; }

        public UnitOfWork(IGenericRepository<Analysis> analysis)
        {
            Analysis = analysis;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
