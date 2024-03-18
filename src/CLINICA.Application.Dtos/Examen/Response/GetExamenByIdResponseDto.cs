using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.Dtos.Examen.Response
{
    public class GetExamenByIdResponseDto
    {
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
    }
}
