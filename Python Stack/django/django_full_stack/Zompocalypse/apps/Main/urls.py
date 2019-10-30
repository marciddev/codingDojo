from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^success$', views.success),
    url(r'^admin$', views.admin),
    url(r'^delete-user/(?P<id>\d+)', views.delete_user),
    url(r'^activity-log$', views.activity),
    url(r'^attack-user$', views.attack_user),
    url(r'^profile$', views.profile),
    url(r'^leaderboard$', views.leaderboard),
    url(r'^logclear$', views.logclear),
    url(r'^generate-zombie-users$', views.genzombieusers),
    url(r'^delete-zombie-users$', views.deletezombieusers),
    url(r'^generate-human-users$', views.genhumanusers),
    url(r'^delete-human-users$', views.deletehumanusers)
]