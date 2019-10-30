from django.db import models
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
# Create your models here.
class UserManager(models.Manager):
    def validateRegister(self, postData):
        errors = {}
        if len(postData["register_first_name"]) < 3 or len(postData["register_last_name"]) < 3:
            errors["invalid_name"] = "Your name must be longer than 3 characters"
        if not EMAIL_REGEX.match(postData["register_email"]):
            errors["invalid_email_format"] = "Email format was invalid!"
        if User.objects.filter(email=postData["register_email"]):
            errors["email_exists"] = "That email already exists!"
        if len(postData["register_username"]) < 4:
            errors["username_too_short"] = "Your username was not more than 4 characters!"
        if User.objects.filter(username=postData["register_username"]): 
            errors["username_exists"] = "That username already exists!"
        if len(postData["register_password"]) < 8:
            errors["password_too_short"] = "Your password was too short. It must be at least 8 characters."
        if not postData["register_password"] == postData["register_confirm_password"]:
            errors["passwords_dont_match"] = "Your passwords do not match!"
        return errors
    def validateSignIn(self, postData):
        errors = {}
        if len(postData["signin_username"]) < 1 or len(postData["signin_password"]) < 1:
            errors["na"] = "Nothing entered!"
        return errors
class User(models.Model):
    first_name=models.CharField(max_length=255)
    last_name=models.CharField(max_length=255)
    username=models.CharField(max_length=255)
    email=models.CharField(max_length=255)
    password=models.CharField(max_length=255)
    species = models.CharField(max_length=255)
    health = models.IntegerField(default=100)
    kills = models.IntegerField(default=0)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now_add = True)
    objects = UserManager()
    def __repr__(self):
        return f"{self.first_name} {self.last_name} {self.email} {self.username} {self.species}"
class Log(models.Model):
    message= models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now_add = True)
