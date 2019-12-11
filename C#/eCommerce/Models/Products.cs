using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace eCommerce.Models {
    
    public class Product {
        [Key]
        public int ProductId {get;set;}
        public int Quantity {get;set;}
        public String Name {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Transaction> PeoplePurchased {get;set;}
    }
}