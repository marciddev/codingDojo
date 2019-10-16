from django.db import models
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
# Create your models here.
class UserManager(models.Manager):
    def validateRegister(self, postData):
        errors = {}
        if len(postData["register_first_name"]) < 3:
            errors["register_first_name"] = "Your first name must be longer than 2 characters!"
        if len(postData["register_last_name"]) < 3:
            errors["register_last_name"] = "Your last name must be longer than 2 characters!"
        if not EMAIL_REGEX.match(postData['register_email']):
            errors['register_email'] = "Email is invalid!"
        if len(postData["register_password"]) < 9:
            errors["register_password"] = "Your password must be at least 8 characters!"
        if postData["register_password"] != postData["register_confirm_password"]:
            errors["passwords_dont_match"] = "Your passwords do not match!"
        return errors
    def validateLogin(self, postData):
        errors={}
        if not EMAIL_REGEX.match(postData["login_email"]):
            errors["login_email"] = "Invalid email!"
        if len(postData["login_password"]) < 9:
            errors["login_password"] = "Password is too short!"
        return errors
class BookManager(models.Manager):
    def validateNewBook(self, postData):
        errors = {}
        if len(postData["new_book_title"]) < 5:
            errors["new_book_title"] = "Book title must be at least 5 characters!"
        if len(postData["new_book_description"]) < 5:
            errors["new_book_description"] = "Book description must be at least 5 characters!"
        return errors
class User(models.Model):
    First_Name = models.CharField(max_length=255)
    Last_Name = models.CharField(max_length=255)
    Email = models.CharField(max_length=255)
    Password = models.CharField(max_length=255)
    updated_at = models.DateTimeField(auto_now=True)
    created_at = models.DateTimeField(auto_now_add=True)
    objects = UserManager()
    def __repr__(self):
        return f"Name: {self.First_Name} {self.Last_Name}, Email: {self.Email}, ID: {self.id}"
class Book(models.Model):
    title=models.CharField(max_length=255)
    uploaded_by=models.ForeignKey(User, related_name="uploaded_books")
    liked_by=models.ManyToManyField(User, related_name="liked_books")
    description=models.TextField()
    updated_at=models.DateTimeField(auto_now_add=True)
    created_at=models.DateTimeField(auto_now=True)
    objects=BookManager()