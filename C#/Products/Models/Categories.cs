using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Products.Models {
    public class Category {
        [Key]
        public int CategoryId {get;set;}
        public String Name {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Association> CategoryProducts {get;set;}
    }
}