using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore;
using System.Collections.Generic;
namespace eCommerce.Models {
    
    public class User {
        [Key]
        public int UserId {get;set;}
        [Required]
        public String FirstName {get;set;}
        [Required]
        public String LastName {get;set;}
        [Required]
        [EmailAddress]
        public String Email {get;set;}
        [DataType(DataType.Password)]
        [MinLength(8)]
        public String Password {get;set;}
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public String ConfirmPassword {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Transaction> PurchasedProducts {get;set;}
    }
}