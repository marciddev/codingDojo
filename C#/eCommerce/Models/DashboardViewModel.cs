using System;
using System.Collections.Generic;
namespace eCommerce.Models {
    public class DashModel {
        public List<User> users {get;set;}
        public List<Transaction> transactions {get;set;}
        public List<Product> products {get;set;}
    }
}