using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using System.Transactions;

namespace CLINICA.Persistencia.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGenericRepository<Analysis> Analysis { get; }
        public IExamenRepository Exams { get; }
        public IPatientRepository Patients { get; }
        public IMedicRepository Medic { get; }
        public ITakeExamRepository TakeExam { get; }

        public UnitOfWork(ApplicationDbContext context, IGenericRepository<Analysis> analysis)
        {
            _context = context;
            Analysis = analysis;
            Exams = new ExamRepository(_context);
            Patients = new PatientRepository(_context);
            Medic = new MedicRepository(_context);
            TakeExam = new TakeExamRepository(_context);

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TransactionScope BeginTransaction()
        {
            var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            return transaction;
        }
    }
}
