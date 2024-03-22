using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IMedicRepository: IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDto>> GetMedicAllAsync(string storedProcedure);
    }
}
