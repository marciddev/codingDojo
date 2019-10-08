from django.conf.urls import url, include
from apps.random_words import views

urlpatterns = [
    url(r'^helloworld$', views.defaulty),
    url(r'^randomword$', views.randomwordgen)
]