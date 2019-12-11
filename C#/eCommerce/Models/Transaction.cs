using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore;
namespace eCommerce.Models {
    public class Transaction {
        [Key]
        public int TransactionId {get;set;}
        public int Amount {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public int ProductId {get;set;}
        public Product Product {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}