using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace chefsanddishes.Models {
    public class Chef {
        [Key]
        public int ChefId {get;set;}
        [Required]
        public DateTime Birthday {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        public List<Dish> CreatedDishes {get;set;}

    }
}