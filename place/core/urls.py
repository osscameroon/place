from django.urls import path
from . import views


urlpatterns = [
    path("", views.index, name="home"),
    path("htmx/events", views.htmx_events, name="htmx-events"),
]
