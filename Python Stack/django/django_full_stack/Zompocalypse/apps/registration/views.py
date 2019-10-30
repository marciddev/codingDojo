from django.shortcuts import render, redirect
from .models import User
from django.contrib import messages
import bcrypt
# Create your views here.
def welcome(request):
    return render(request, "registration/index.html")
def register(request):
    if request.method == "POST":
        if request.POST["hide"] == "register":
            errors = User.objects.validateRegister(request.POST)
            if len(errors) > 0:
                for k,v in errors.items():
                    messages.error(request, v)
                return redirect("/")
            else:
                password = bcrypt.hashpw(request.POST["register_password"].encode(), bcrypt.gensalt())
                user = User.objects.create(first_name=request.POST["register_first_name"]
                    ,last_name=request.POST["register_last_name"], email=request.POST["register_email"],
                    username=request.POST["register_username"], password=password,species=request.POST["register_species"])
                user.save()
                request.session["id"] = user.id
                return redirect("/success")
def logout(request):
    request.session.clear()
    return redirect("/")
def signin_species(request):
    if request.method == "POST":
        if request.POST["hide"] == "signin":
            errors = User.objects.validateSignIn(request.POST)
            if len(errors) > 0:
                for k,v in errors.items():
                    messages.error(request, v)
                return redirect("/")
            else:
                usernameExists = User.objects.filter(username=request.POST["signin_username"])
                if usernameExists:
                    print("username exists")
                    logged_user = usernameExists[0]
                    if bcrypt.checkpw(request.POST["signin_password"].encode(), logged_user.password.encode()):
                        request.session["id"] = logged_user.id
                        print("password match")
                        return redirect("/success")
                    else:
                        print("password fail")
                        messages.error(request, "Invalid password!")
                        return redirect("/")
                else:
                    print("no username found")
                    messages.error(request, "No username found!")
                    return redirect("/")