from django.db import models

# Create your models here.
class Dojos(models.Model):
    name=models.CharField(max_length=255)
    city=models.CharField(max_length=255)
    state=models.CharField(max_length=2)
    desc=models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return f"Dojo: {self.name}, {self.city}, {self.state}, created at {self.created_at}, {self.id}"

class Ninjas(models.Model):
    dojo = models.ForeignKey(Dojos)
    first_name=models.CharField(max_length=255)
    last_name=models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    def __repr__(self):
        return f"Ninja: {self.first_name} {self.last_name}, From the dojo {self.dojo.name}, {self.id}"
