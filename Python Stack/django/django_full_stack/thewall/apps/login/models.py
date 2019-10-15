from django.db import models
import re
# Create your models here.
class UserManager(models.Manager):
    def validate(self, postData):
        errors = {}
        if len(postData['First_Name']) < 3:
            errors['first_name'] = "You must put more than 2 letters for your first name"
        if len(postData['Last_Name']) < 3:
            errors['last_name'] = "You must put more than 2 letters for your last name."
        if len(postData['Email']) <3:
            errors['email'] = "You must put more than 2 letters for your email"
        if len(postData['Password']) < 8:
            errors['password'] = "You must put more than 8 letters for your password."
        if postData['Confirm_Password'] != postData['Password']:
            errors['confirmpass'] = "Passwords do not match!"
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        if not EMAIL_REGEX.match(postData['Email']):
            errors['emailinvalid'] = "Invalid Email!"
        return errors
    def validate2(self, postData):
        errors = {}
        if len(postData['Password2']) < 8:
            errors['password2'] = "You must put more than 8 letters for your password."
        if len(postData['Email2']) <3:
            errors['email2'] = "You must put more than 2 letters for your email"
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        if not EMAIL_REGEX.match(postData['Email2']):
            errors['emailinvalid2'] = "Invalid Email!"
        return errors
class Users(models.Model):
    First_Name=models.CharField(max_length=255)
    Last_Name=models.CharField(max_length=255)
    Email=models.CharField(max_length=255)
    Password=models.CharField(max_length=255)
    updated_at = models.DateTimeField(auto_now=True)
    created_at = models.DateTimeField(auto_now_add=True)
    objects = UserManager()
    def __repr__(self):
        return f"User: {self.id} {self.First_Name} {self.Last_Name} {self.Email}"