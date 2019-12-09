using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace WeddingPlanner.Models {
    public class User {
        [Key]
        public int UserId {get;set;}
        [Required]
        public String FirstName {get;set;}
        [Required]
        public String LastName {get;set;}
        [EmailAddress]
        [Required]
        public String Email {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public String Password {get;set;}
        [Required]
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public String ConfirmPassword {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Arrangement> Marriages {get;set;}
    }
}