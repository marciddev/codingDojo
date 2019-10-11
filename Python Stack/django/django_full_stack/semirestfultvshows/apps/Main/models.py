from django.db import models

# Create your models here.
class Show(models.Model):
    title=models.CharField(max_length=255)
    network=models.CharField(max_length=10)
    release_date=models.DateField()
    description=models.TextField()
    updated_at=models.DateTimeField(auto_now=True)
    created_at=models.DateTimeField(auto_now_add=True)
    def __repr__(self):
        return f"ID: {self.id} Title: {self.title} Network: {self.network} Release Date: {self.release_date}"