using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Domain.Entities
{
    public class Medic
    {
        public int? MedicId { get; set; }
        public string? Names{ get; set; }
        public string? Lastname { get; set; }
        public string? MotherMaidenName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? BithDate { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? DocumentNumber { get; set; }
        public int? SpecialtyId { get; set; }
        public int? State { get; set; }
        public DateTime? AuditCreateDate { get; set; }


    }
}
