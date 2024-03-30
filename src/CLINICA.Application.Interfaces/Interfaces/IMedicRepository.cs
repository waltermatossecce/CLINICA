using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IMedicRepository: IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDto>> GetMedicAllAsync(string storedProcedure, object parameters);
    }
}
