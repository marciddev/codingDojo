using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore;
namespace WeddingPlanner.Models {
    public class Arrangement {
        [Key]
        public int ArrangementId {get;set;}
        public int WeddingId {get;set;}
        public Wedding Wedding {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
    }
}