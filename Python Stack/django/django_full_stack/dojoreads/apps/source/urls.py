from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.home),
    url(r'^register-user$', views.register),
    url(r'^login-user$', views.login),
    url(r'^books$', views.bookspage),
    url(r'^clear$', views.clear),
    url(r'^books/(?P<id>\d+)$', views.bookprofile),
    url(r'^books/submit-review$', views.submitreview),
    url(r'^delete-review$', views.deletereview),
    url(r'^users/(?P<id>\d+)$', views.userprofile),
    url(r'^books/add$', views.addbook),
    url(r'^books/add-book$', views.add_book)
]