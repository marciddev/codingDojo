from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^wall$', views.wall),
    url(r'^logoff$', views.logoff),
    url(r'^post-message$', views.postmsg),
    url(r'^post-comment$', views.commentmsg),
    url(r'^delete-post/(?P<postid>\d+)$', views.deletepost)
]