using System.ComponentModel.DataAnnotations;
using System;
namespace chefsanddishes.Models {
    public class Dish {
        [Key]
        public int DishId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public int Calories {get;set;}
        [Required]
        [Range(1, 5)]
        public int Tastiness {get;set;}
        [Required]
        public string Description {get;set;}
        public int ChefId {get;set;}
        public Chef Creator {get;set;}
    }
}