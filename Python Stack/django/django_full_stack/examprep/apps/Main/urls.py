from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.registration),
    url(r'^register-user$', views.registerUser),
    url(r'^login-user$', views.login),
    url(r'^books$', views.books),
    url(r'^logout$', views.logout),
    url(r'^create-review$', views.create_review),
    url(r'^process-review$',views.process_review),
    url(r'^books/(?P<id>\d+)$', views.bookprofile),
    url(r'^books/delete/(?P<revid>\d+)$', views.deletereview),
    url(r'^books/(?P<id>\d+)/addview', views.addview),
    url(r'^books/users/(?P<id>\d+)', views.users)
]