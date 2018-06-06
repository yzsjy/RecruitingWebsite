﻿using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopJobs.Models
{
    public class Create
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [Range(18, 100)]
        public int Age { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string nationality { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{3}\-[0-9]{3}\-[0-9]{4}", ErrorMessage = "Please enter a valid Phone Number in the format, XXX-XXX-XXXX")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please enter theEmail address in the correct format")]
        public string Email { get; set; }
    }
    
    public class View
    {
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Requirement { get; set; }
        public string Salary { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
    }
}
