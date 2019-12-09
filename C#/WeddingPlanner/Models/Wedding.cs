using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models {
    public class Wedding {
        [Key]
        public int WeddingId {get;set;}
        [Required]
        public String FirstHuman {get;set;}
        [Required]
        public String SecondHuman {get;set;}
        [Required]
        public DateTime DateOf {get;set;}
        public String Address {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Arrangement> Attendants {get;set;}
    }
}