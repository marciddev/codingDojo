from django.conf.urls import url
from . import views

urlpatterns= [
    url(r'^bookprofile/(?P<id>\d+)$', views.bprofile),
    url(r'^$', views.blist),
    url(r'^authorlist$', views.alist),
    url(r'^authorprofile/(?P<aid>\d+)$', views.aprofile),
    url(r'^processbooks$', views.procbooks),
    url(r'^processauthors$', views.procauthors),
    url(r'^addauthor$', views.addedauthor),
    url(r'^addbook$', views.addedbook)
]