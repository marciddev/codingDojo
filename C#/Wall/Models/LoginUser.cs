using System;
using System.ComponentModel.DataAnnotations;
namespace Wall.Models {
    public class LoginUser {
        public String Email {get;set;}
        [DataType(DataType.Password)]
        public String Password {get;set;}
    }
}