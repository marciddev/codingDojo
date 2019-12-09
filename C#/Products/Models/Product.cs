using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Products.Models {
    public class Product {
        [Key]
        public int ProductId {get;set;}
        [Range(3, 45)]
        public String Name {get;set;}
        public String Description {get;set;}
        public Double Price {get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Association> ProductCategories {get;set;}
    }
}