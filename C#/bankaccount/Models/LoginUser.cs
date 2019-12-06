using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankaccount.Models {
    public class LoginUser {
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        public string Password{get;set;}
    }
}