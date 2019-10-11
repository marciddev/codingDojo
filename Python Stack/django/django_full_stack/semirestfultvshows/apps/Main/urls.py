from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.homepage),
    url(r'^shows/new$', views.newshows),
    url(r'^shows/create$', views.createshow),
    url(r'^shows/(?P<grabid>\d+)$', views.viewshow),
    url(r'^shows$', views.showstable),
    url(r'^shows/(?P<grabid2>\d+)/edit$', views.editshow),
    url(r'^shows/(?P<grabid3>\d+)/update$', views.updateshow),
    url(r'^shows/(?P<grabid4>\d+)/delete', views.deleteshow)
]