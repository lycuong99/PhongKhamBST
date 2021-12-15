using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("TreatmentDetail")]
    public class TreatmentDetail
    {
        public Guid Id { get; set; }
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }

        public int NoDay { get; set; }

        public int NoTimeToTakeMedicine { get; set; }

        public int Dosage { get; set; }

        public string Unit { get; set; }

        public string TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

     
    }
}
