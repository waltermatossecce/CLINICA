using CLINICA.Application.Dtos.Results.Response;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IResultsRepository :IGenericRepository<Results>
    {
        Task<IEnumerable<GetAllResultsResponseDto>> GetAllResults(string storedProcedure,object parameters);

        //Task<bool> RegisterResullt(Results results);
    }
}
