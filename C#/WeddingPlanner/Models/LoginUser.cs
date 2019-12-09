using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
namespace WeddingPlanner.Models {
    public class LoginUser {
        public String Email {get;set;}
        [DataType(DataType.Password)]
        public String Password {get;set;}
    }

}