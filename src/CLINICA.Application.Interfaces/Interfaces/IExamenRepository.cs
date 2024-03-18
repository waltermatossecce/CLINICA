using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IExamenRepository : IGenericRepository<Examen>
    {
        Task<IEnumerable<GetAllExamenResponseDto>> GetAllExams(string storedProcedure);

    }
}
