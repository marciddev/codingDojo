from django.db import models
import re
from datetime import datetime
import bcrypt
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
# Create your models here.
class UserManager(models.Manager):
    def validateRegister(self, postData):
        errors = {}
        if len(postData["register_first_name"]) < 2:
            errors["register_first_name"] = "Your first name must be more than two letters!"
        if len(postData["register_last_name"]) < 2:
            errors["register_last_name"] = "Your last name must be more than two letters!"
        if not EMAIL_REGEX.match(postData["register_email"]):
            errors["register_email_format"] = "Your email is invalid!"
        check = User.objects.filter(email=postData["register_email"])
        if check:
            errors["register_email_exists"] = "The specified email already exists!"
        try:
            if datetime.now() < datetime.strptime(postData["register_birthday"], "%Y-%m-%d"):
                errors["soon_bday"] = "Birthday must be in the past!"
        except:
            errors["birthday_too_soon"] = "Your birthday must be in the past!"
        if len(postData["register_password"]) < 8:
            errors["short_password"] = "Your password must be 8 characters or greater!"
        if postData["register_password"] != postData["register_confirm_password"]:
            errors["matching_password_failure"] = "Passwords do not match!"
        if len(postData["register_birthday"]) < 10:
            errors["empty_birthday"] = "Invalid birthday!"
        return errors
    def validateLogin(self, postData):
        errors = {}
        if not EMAIL_REGEX.match(postData["login_email"]):
            errors["login_email_format"] = "Your email is invalid!"
        check = User.objects.filter(email=postData["login_email"])
        if not check:
            errors["login_email_exists"] = "The specified email does not exist!"
        return errors
class User(models.Model):
    first_name=models.CharField(max_length=255)
    last_name=models.CharField(max_length=255)
    email=models.CharField(max_length=255)
    birthday=models.DateField()
    password=models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = UserManager()
    def __repr__(self):
        return f"Name: {self.first_name} {self.last_name} Email: {self.email} Birthday: {self.birthday} ID: {self.id}"
class Author(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now = True)
class Book(models.Model):
    title=models.CharField(max_length=255)
    author=models.ForeignKey(Author, related_name="books")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now = True)
class Review(models.Model):
    message = models.CharField(max_length=255)
    rating = models.IntegerField()
    user = models.ForeignKey(User, related_name="reviews")
    book=models.ForeignKey(Book, related_name="reviews")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now = True)