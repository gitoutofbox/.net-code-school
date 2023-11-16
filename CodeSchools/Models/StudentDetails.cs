﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeSchools.Models
{
    public class StudentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Student_master_id { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Dob { get; set; }

        public StudentMaster? Student_master { get; set; }
    }
}
