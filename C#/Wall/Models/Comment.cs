using System;
using System.ComponentModel.DataAnnotations;
public class Comment {
    [Key]
    public int CommentId {get;set;}
    public int MessageId {get;set;}
    public Message Message {get;set;}
    public int UserId {get;set;}
    public User User{get;set;}

    public String CommentText {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}