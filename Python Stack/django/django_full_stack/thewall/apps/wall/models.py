from django.db import models
from apps.login.models import *
# Create your models here.
class Post(models.Model):
    message=models.CharField(max_length=255)
    User=models.ForeignKey(Users)
    expired_at = models.DateTimeField()
    created_at=models.DateTimeField(auto_now_add=True)
    updated_at=models.DateTimeField(auto_now=True)
    def __repr__(self):
        return f"ID: {self.id}, MESSAGE: {self.message}, USER: {self.User.First_Name}"
class Comment(models.Model):
    comment=models.CharField(max_length=255)
    User=models.ForeignKey(Users, related_name="user_comments")
    Post=models.ForeignKey(Post, related_name="post_comments")
    created_at=models.DateTimeField(auto_now_add=True)
    updated_at=models.DateTimeField(auto_now=True)
    def __repr__(self):
        return f"ID: {self.id} COMMENT: {self.comment} USER: {self.User.id} {self.User.First_Name}POST MSG:  {self.Post.message} POST: {self.Post.id} {self.Post.message}"
