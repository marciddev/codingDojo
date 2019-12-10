using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Message {
    [Key]
    public int MessageId {get;set;}
    public int UserId {get;set;}
    public User User{get;set;}
    public String message {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Comment> Comments {get;set;}
}