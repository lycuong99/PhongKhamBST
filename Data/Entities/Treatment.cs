using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Treatment")]
    public class Treatment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Note { get; set; }
        public string Diagnosis { get; set; }
        public bool IsTemplate { get; set; } = false;

        public ICollection<TreatmentDetail> TreatmentDetails { get; set; }
    }
}
