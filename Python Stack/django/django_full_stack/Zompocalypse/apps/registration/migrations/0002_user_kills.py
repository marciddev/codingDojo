# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2019-10-24 18:04
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('registration', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='user',
            name='kills',
            field=models.IntegerField(default=0),
        ),
    ]