using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TopJobs.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20,MinimumLength =5)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Requirement { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{3}\-[0-9]{3}\-[0-9]{4}",ErrorMessage ="Please enter a valid Phone Number in the format, XXX-XXX-XXXX")]
        [Display(Name ="Phone Number")]
        public string Phone_Number { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Please enter theEmail address in the correct format")]
        public string Email { get; set; }
    }
    
    public class ViewResume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        public string nationality { get; set; }
        public string Experience { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}