# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2019-10-09 18:43
from __future__ import unicode_literals

from django.db import migrations, models
import django.utils.timezone


class Migration(migrations.Migration):

    dependencies = [
        ('Main', '0002_auto_20191009_1339'),
    ]

    operations = [
        migrations.AddField(
            model_name='dojos',
            name='created_at',
            field=models.DateTimeField(auto_now_add=True, default=django.utils.timezone.now),
            preserve_default=False,
        ),
        migrations.AddField(
            model_name='dojos',
            name='updated_at',
            field=models.DateTimeField(auto_now=True),
        ),
        migrations.AddField(
            model_name='ninjas',
            name='created_at',
            field=models.DateTimeField(auto_now_add=True, default=django.utils.timezone.now),
            preserve_default=False,
        ),
        migrations.AddField(
            model_name='ninjas',
            name='updated_at',
            field=models.DateTimeField(auto_now=True),
        ),
    ]