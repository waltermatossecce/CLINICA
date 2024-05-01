namespace CLINICA.Domain.Entities
{
    public class Results
    {
        public int ResultId { get; set; }
        public int TakeExamId { get; set; }
        public int State { get; set; }
        public DateTime AuditCreateDate { get; set; }

    }
}
