namespace CLINICA.Application.Dtos.Examen.Response
{
    public class GetExamenByIdResponseDto
    {
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
    }
}
