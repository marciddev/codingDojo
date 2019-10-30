from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.welcome),
    url(r'^register-species$', views.register),
    url(r'^logout$', views.logout),
    url(r'^sign-in-species$', views.signin_species)
]