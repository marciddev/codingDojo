using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models {
    public class User {
        [Display(Name = "First Name: ")]
        [Required]
        [MinLength(4)]
        public string firstName {get;set;}

        [Display(Name = "Last Name: ")]
        [Required]
        [MinLength(4)]
        public string lastName {get;set;}


        [Display(Name = "Age: ")]
        [Required]
        [Range(0, 100)]
        public int age {get;set;}


        [Required]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string email {get;set;}


        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Password: ")]
        public string password {get;set;}
    }
}