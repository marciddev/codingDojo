from django.db import models

# Create your models here.
from django.db import models
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
# Create your models here.
class UserManager(models.Manager):
    def validateRegistration(self, postData):
        errors = {}
        if len(postData["register_first_name"]) < 3:
            errors["register_first_name"] = "Invalid first name!(less than 3 characters)"
        if len(postData["register_first_name"]) < 3:
            errors["register_last_name"] = "Invalid last name!(less than 3 characters)"
        if not EMAIL_REGEX.match(postData["register_email"]):
            errors["register_email"] = "Invalid email!"
        if len(postData["register_password"]) < 9:
            errors["register_password"] = "Password must be greater than 8 characters!"
        if postData["register_password"] != postData["register_confirm_password"]:
            errors["matching_passwords"] = "Passwords do not match!"
        return errors
class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name=models.CharField(max_length=255)
    email=models.CharField(max_length=255)
    password=models.CharField(max_length=255)
    updated_at=models.DateTimeField(auto_now=True)
    created_at=models.DateTimeField(auto_now_add=True)
    objects = UserManager()
    def __repr__(self):
        return f"Name: {self.first_name} {self.last_name} Email: {self.email} ID: {self.id}"
class Author(models.Model):
    first_name=models.CharField(max_length=255)
    last_name=models.CharField(max_length=255)
    updated_at=models.DateTimeField(auto_now=True)
    created_at=models.DateTimeField(auto_now_add=True)
    def __repr__(self):
        return f"Name: {self.first_name} {self.last_name}"
class Book(models.Model):
    title=models.CharField(max_length=255)
    author=models.ForeignKey(Author, related_name="books")
    updated_at=models.DateTimeField(auto_now=True)
    created_at=models.DateTimeField(auto_now_add=True)
    def __repr__(self):
        return f"Title: {self.title} Author: {self.author.first_name} {self.author.last_name}"
class Review(models.Model):
    rating=models.IntegerField(default=None)
    message=models.CharField(max_length=255)
    book=models.ForeignKey(Book, related_name="book_reviews")
    user=models.ForeignKey(User, related_name="user_reviews")
    updated_at=models.DateTimeField(auto_now=True)
    created_at=models.DateTimeField(auto_now_add=True)
    def __repr__(self):
        return f"Rating: {self.rating} message: {self.message} book: {self.book.title} user: {self.user.first_name}"