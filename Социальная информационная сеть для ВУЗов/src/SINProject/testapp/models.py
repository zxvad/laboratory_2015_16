from django.db import models
from django.contrib.auth.models import User

class ForumSection(models.Model):
    title = models.CharField(max_length=200)

class Subunit(models.Model):
    name = models.CharField(max_length=60)
    upper_subunit = models.ForeignKey("self", related_name='lower', null=True, blank=True)
    forum = models.ForeignKey(ForumSection, unique=True, null=True, blank=True)

class UserProfile(models.Model):
    user = models.ForeignKey(User, unique=True, related_name='profile')
    subunit = models.ForeignKey(Subunit, null=True, blank=True)
    birthday = models.DateField(null=True)
    description = models.TextField(null=True)

class Comment(models.Model):
    author = models.ForeignKey(User)
    massage = models.TextField(null=True)
    created = models.DateTimeField(auto_now=True)
    upper_comment = models.ForeignKey('self', related_name='lower', null=True)

class BlogMassage(models.Model):
    massage = models.TextField(null=True)
    created = models.DateTimeField(auto_now=True)
    author = models.ForeignKey(User)
    root_comment = models.ForeignKey(Comment, unique=True)

class News(models.Model):
    massage = models.TextField(null=True)
    created = models.DateTimeField(auto_now=True)
    root_comment = models.ForeignKey(Comment, unique=True)
    author = models.ForeignKey(User)
    subunit = models.ForeignKey(Subunit)

class ForumTheme(models.Model):
    section = models.ForeignKey(ForumSection)
    title = models.CharField(max_length=200)
    author = models.ForeignKey(User)
    root_comment = models.ForeignKey(Comment, unique=True)
    created = models.DateTimeField(auto_now=True)
    active = models.BooleanField(default=True)
    fixed = models.BooleanField(default=False)

class Subject(models.Model):
    name = models.CharField(max_length=200)
    description = models.TextField(null=True)
    lecturer = models.ForeignKey(User)
    subunits = models.ManyToManyField(Subunit)

class Lesson(models.Model):
    lecturer = models.ForeignKey(User)
    subject = models.ForeignKey(Subject)
    datetime = models.DateTimeField(null=True)
    auditorium = models.CharField(max_length=10)
    template = models.BooleanField(default=False)

class Event(models.Model):
    datetime = models.DateTimeField(null=True)
    title = models.CharField(max_length=200)
    description = models.TextField(null=True)
    subunit = models.ForeignKey(Subunit)
