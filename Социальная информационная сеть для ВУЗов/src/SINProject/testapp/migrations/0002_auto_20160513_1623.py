# -*- coding: utf-8 -*-
# Generated by Django 1.9.6 on 2016-05-13 12:23
from __future__ import unicode_literals

from django.conf import settings
from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        migrations.swappable_dependency(settings.AUTH_USER_MODEL),
        ('testapp', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='BlogMassage',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('massage', models.TextField(null=True)),
                ('created', models.DateTimeField(auto_now=True)),
                ('author', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
            ],
        ),
        migrations.CreateModel(
            name='Comment',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('massage', models.TextField(null=True)),
                ('created', models.DateTimeField(auto_now=True)),
                ('author', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
                ('upper_comment', models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, related_name='lower', to='testapp.Comment')),
            ],
        ),
        migrations.CreateModel(
            name='Event',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('datetime', models.DateTimeField(null=True)),
                ('title', models.CharField(max_length=200)),
                ('description', models.TextField(null=True)),
            ],
        ),
        migrations.CreateModel(
            name='ForumSection',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('title', models.CharField(max_length=200)),
            ],
        ),
        migrations.CreateModel(
            name='ForumTheme',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('title', models.CharField(max_length=200)),
                ('created', models.DateTimeField(auto_now=True)),
                ('active', models.BooleanField(default=True)),
                ('fixed', models.BooleanField(default=False)),
                ('author', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
                ('root_comment', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Comment', unique=True)),
                ('section', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.ForumSection')),
            ],
        ),
        migrations.CreateModel(
            name='Lesson',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('datetime', models.DateTimeField(null=True)),
                ('auditorium', models.CharField(max_length=10)),
                ('template', models.BooleanField(default=False)),
                ('lecturer', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
            ],
        ),
        migrations.CreateModel(
            name='News',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('massage', models.TextField(null=True)),
                ('created', models.DateTimeField(auto_now=True)),
                ('author', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
                ('root_comment', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Comment', unique=True)),
            ],
        ),
        migrations.CreateModel(
            name='Subject',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=200)),
                ('description', models.TextField(null=True)),
                ('lecturer', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
            ],
        ),
        migrations.CreateModel(
            name='SubunitToSubject',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('subject', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Subject')),
            ],
        ),
        migrations.AddField(
            model_name='userprofile',
            name='birthday',
            field=models.DateField(null=True),
        ),
        migrations.AddField(
            model_name='userprofile',
            name='description',
            field=models.TextField(null=True),
        ),
        migrations.AlterField(
            model_name='subunit',
            name='upper_subunit',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, related_name='lower', to='testapp.Subunit'),
        ),
        migrations.AlterField(
            model_name='userprofile',
            name='subunit',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, to='testapp.Subunit'),
        ),
        migrations.AddField(
            model_name='subunittosubject',
            name='subunit',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Subunit'),
        ),
        migrations.AddField(
            model_name='news',
            name='subunit',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Subunit'),
        ),
        migrations.AddField(
            model_name='lesson',
            name='subject',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Subject'),
        ),
        migrations.AddField(
            model_name='event',
            name='subunit',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Subunit'),
        ),
        migrations.AddField(
            model_name='blogmassage',
            name='root_comment',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='testapp.Comment', unique=True),
        ),
        migrations.AddField(
            model_name='subunit',
            name='forum',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, to='testapp.ForumSection', unique=True),
        ),
    ]
