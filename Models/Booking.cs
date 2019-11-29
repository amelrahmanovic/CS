using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Booking
    {
        [Key]
        public int id { get; set; }
        public string object_name { get; set; }
        [ForeignKey("Capacity_provider")]
        public int capacity_provider_id { get; set; }
        public Capacity_provider Capacity_provider { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public bool is_active { get; set; }
        public float amount { get; set; }
        public string currency { get; set; }
        public string comment { get; set; }

    }
}
