from django.shortcuts import render, HttpResponse, render, redirect
from .models import *
from apps.login.views import *
# Create your views here.
def wall(request):
    context = {
        "user": Users.objects.get(id=request.session['id']).First_Name,
        "posts": Post.objects.all(),
        "comments": Comment.objects.all()
    }
    return render(request, "wall/index.html", context)
def logoff(request):
    request.session.clear()
    return redirect("/")
def postmsg(request):
    if request.method == "POST":
        if request.POST['hide'] == "postmessage":
            Post.objects.create(message=request.POST["post_message"], User=Users.objects.get(id=request.session['id']))
    return redirect("/wall")
def commentmsg(request):
    if request.method=="POST":
        if request.POST['hide'] == "hiddencomment":
            Comment.objects.create(comment=request.POST["comment"], User=Users.objects.get(id=request.session['id']), Post=Post.objects.get(id=request.POST["postid"]))
            return redirect("/wall")
    return redirect("/wall")