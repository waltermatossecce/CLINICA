using CLINICA.Domain.Entities;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis>Analysis { get;}
        IExamenRepository Exams { get;}
        IPatientRepository Patients { get;}

        IMedicRepository Medic { get;}

    }
}
