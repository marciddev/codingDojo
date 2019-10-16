from django.conf.urls import url
from . import views

#url patterns here
urlpatterns = [
    url(r'^$', views.home),
    url(r'^register$', views.register),
    url(r'^success$', views.success),
    url(r'^login$', views.login),
    url(r'^delete$', views.delete),
    url(r'^books$', views.books),
    url(r'add_book', views.add_book),
    url(r'^books/(?P<id>\d+)', views.view_book),
    url(r'^books/unfavorite_book$', views.unfav),
    url(r'^books/favorite_book$', views.fav),
    url(r'^updatedesc', views.descupdate)
]