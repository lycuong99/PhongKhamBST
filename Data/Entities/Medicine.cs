using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Medicine")]
    public class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
