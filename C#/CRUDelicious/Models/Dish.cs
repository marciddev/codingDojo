using System.ComponentModel.DataAnnotations;
using System;
namespace CRUDelicious.Models {
    public class Dish {
            [Key]
            public int DishId { get; set; }

            [Required]
            public string Chef {get;set;}
            // MySQL VARCHAR and TEXT types can be represeted by a string

            [Required]
            public string Name { get; set; }
            [Required]
            [Range(1, 5)]
            public int Tastiness { get; set; }
            [Required]
            [Range(0, 100000)]
            public int Calories { get; set; }
            [Required]
            public string Description { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}