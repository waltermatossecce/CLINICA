namespace CLINICA.Application.Dtos.Medic.Response
{
    public class GetAllMedicResponseDto
    {
        public int? MedicId { get; set; }
        public string? Names { get; set; }
        public string? SurNames { get; set; }
        public string? Specialities { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? BithDate { get; set; }
        public string? StateMedic { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
