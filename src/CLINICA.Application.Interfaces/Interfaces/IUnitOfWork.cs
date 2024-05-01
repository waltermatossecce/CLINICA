using CLINICA.Domain.Entities;
using System.Transactions;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis>Analysis { get;}
        IExamenRepository Exams { get;}
        IPatientRepository Patients { get;}
        IMedicRepository Medic { get;}
        ITakeExamRepository TakeExam { get;}
        IResultsRepository Results { get;}

        //transacion
        TransactionScope BeginTransaction();

    }
}
