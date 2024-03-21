namespace CLINICA.Application.Dtos.Patients.Response
{
    public class GetPatientByIdResponseDto
    {
        public int? PatientId { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phono { get; set; }
        public int? TypeAgeId { get; set; }
        public int? Age { get; set; }
        public int? GenerId { get; set; }
    }
}
