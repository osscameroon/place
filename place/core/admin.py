from django.contrib import admin
from .models import Category, Event


# Register your models here.
@admin.register(Category)
class Category(admin.ModelAdmin):
    list_display = ("name", "icon")


@admin.register(Event)
class Event(admin.ModelAdmin):
    list_display = ("title", "datetime", "location", "category", "status")
    list_filter = ("category", "status", "datetime")
    date_hierarchy = "datetime"
