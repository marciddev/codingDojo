using System;
using System.ComponentModel.DataAnnotations;
namespace eCommerce.Models {
    public class LoginUser {
        public String LoginEmail {get;set;}
        [DataType(DataType.Password)]
        public String LoginPassword {get;set;}
    }
}