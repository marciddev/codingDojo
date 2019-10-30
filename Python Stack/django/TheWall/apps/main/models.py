from __future__ import unicode_literals
from django.db import models
import re, bcrypt

class UserManager(models.Manager):
    def basic_validator(self, postData):
        errors={}
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9.+_-]+\.[a-zA-Z0-9]+$')
        if not EMAIL_REGEX.match(postData['email']):
            errors['email'] = ("Invalid email address.")
        if User.objects.filter(email=postData['email']):
            errors["email_exists"] = "This email address is already linked to another account."
        if len(postData['first']) <3:
            errors['first']  = "First name should be longer than 3 character."
        if len(postData['last']) <3:
            errors['last']  = "Last name should be longer than 3 character."
        if len(postData['pw']) <8:
            errors['pw']  = "Password must be longer than 8 characters."
        if postData['pw'] != postData['pw2']:
            errors ['pw2'] = "Sorry, try again. Your passwords dont appear to match."
        return errors

    def loginVal(self, postData):
        user = User.objects.filter(email = postData['email'])
        errors = {}
        if not user:
            errors['email']="Email not found in database. Please try again."
        if user and not bcrypt.checkpw(postData['pw'].encode(), user[0].password.encode()):
            errors['pw'] = "invalid password"
        return errors

class User(models.Model):
    first = models.CharField(max_length=225)
    last = models.CharField(max_length=225)
    email = models.CharField(max_length=225)
    password = models.CharField(max_length=225)
    objects = UserManager()
  # message = list of messages for from this user

class Messages(models.Model):
    comments = models.TextField()
    user = models.ForeignKey(User, related_name="message")
    created = models.DateTimeField(auto_now_add=True)
    updated = models.DateTimeField(auto_now_add=True)
