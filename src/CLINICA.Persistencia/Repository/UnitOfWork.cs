using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;

namespace CLINICA.Persistencia.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGenericRepository<Analysis> Analysis { get; }

        public IExamenRepository Exams {  get; }

        public UnitOfWork(ApplicationDbContext context, IGenericRepository<Analysis> analysis)
        {
            _context = context;
            Analysis = analysis;
            Exams = new ExamRepository(_context);
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
