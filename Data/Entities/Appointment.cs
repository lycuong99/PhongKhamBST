using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Appointment")]
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("PatiendId")]
        public Guid PatiendId { get; set; }

        public virtual Patient Patient {get;set; }

        public long Cost { get; set; }

        public string Note { get; set; }

        //Triệu chứng
        public string Symptoms { get; set; }

        public Treatment Treatment { get; set; }

        [ForeignKey("TreatById")]
        public Guid TreatById { get; set; }
        public User TreatBy { get; set; }
    }
}
