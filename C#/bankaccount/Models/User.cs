using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace bankaccount.Models {
    public class User {
        [Key]
        public int UserId {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [EmailAddress]
        [Required]
        public string Email {get;set;}
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password{get;set;}
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm{get;set;}
        public double Balance{get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Transaction> Transactions {get;set;}
    }
}