from django.db import models

# Create your models here.
class ShowManager(models.Manager):
    def validate(self, postData):
        errors = {}
        if len(postData['showtitle']) < 1:
            errors['showtitle'] = "Title must be more than 1 letter"
        if len(postData['networkname']) < 1:
            errors['networkname'] = "Network name must be more than 1 letter"
        if len(postData['showdesc']) < 1:
            errors['showdesc'] = "Description must be more than 1 letter"
        return errors
class Show(models.Model):
    title=models.CharField(max_length=255)
    network=models.CharField(max_length=10)
    release_date=models.DateField()
    description=models.TextField()
    updated_at=models.DateTimeField(auto_now=True)
    created_at=models.DateTimeField(auto_now_add=True)
    objects = ShowManager()
    def __repr__(self):
        return f"ID: {self.id} Title: {self.title} Network: {self.network} Release Date: {self.release_date}"