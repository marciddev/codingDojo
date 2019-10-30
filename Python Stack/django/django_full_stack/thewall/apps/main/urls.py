from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^login$', views.index),
    url(r'^login/validate', views.validate),
    url(r'^login/success$', views.success),
    url(r'^login/login$', views.login),
    url(r'^login/logout$', views.logout),
    url(r'^wall/postMessage$', views.postMessage),
    url('^wall$', views.wall),
]