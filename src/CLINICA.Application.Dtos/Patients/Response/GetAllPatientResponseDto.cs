namespace CLINICA.Application.Dtos.Patients.Response
{
    public class GetAllPatientResponseDto
    {
        public int PatientId { get; set; }
        public string? Names { get; set; }
        public string? SurNames { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phono { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? StatePatient { get; set; }
        public DateTime AuditCreateDate { get; set; }

    }
}
