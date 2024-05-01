namespace CLINICA.Application.Dtos.Results.Response
{
    public class GetAllResultsResponseDto
    {
        public int? ResultId { get; set; }
        public string? Patient { get; set; }
        public string? PatientDocument { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? StateResult { get; set; }
    }
}
