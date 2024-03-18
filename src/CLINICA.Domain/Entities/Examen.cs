namespace CLINICA.Domain.Entities
{
    public class Examen
    {
        public int? ExamId { get; set; }
        public string? Name { get; set; }
        public int? AnalysisId { get; set; }
        public int? State { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
