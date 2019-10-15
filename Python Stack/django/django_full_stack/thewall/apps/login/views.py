from django.shortcuts import render, redirect
from django.contrib import messages
from .models import *
import bcrypt

# Create your views here.
def root(request):
    return render(request, "login/index.html")
def register(request):
    errors = Users.objects.validate(request.POST)
    
    if len(errors) > 0:
        for k,v in errors.items():
            messages.error(request, v)
        return redirect("/")
    else:
        if request.method == "POST":
            if request.POST['hide'] == "regist":
                first = request.POST['First_Name']
                last = request.POST['Last_Name']
                email = request.POST['Email']
                password = request.POST['Password']
                pw_hash = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
                confpass = request.POST['Confirm_Password']
                user = Users.objects.create(First_Name=first, Last_Name=last, Email=email, Password=pw_hash)
                user.save()
                request.session['id'] = user.id
                request.session['username'] = Users.objects.get(id=user.id).First_Name
        return redirect("/wall")
def login(request):
    errors = Users.objects.validate2(request.POST)
    if len(errors) > 0:
        for k,v in errors.items():
            messages.error(request, v)
        return redirect("/")
    else:
        if request.method == "POST":
            if request.POST['hide'] == "log":
                email = Users.objects.filter(Email=request.POST["Email2"])
                print("post log is email")
                if email:
                    print("ema success")
                    logged_user = email[0]
                    if bcrypt.checkpw(request.POST['Password2'].encode(), logged_user.Password.encode()):
                        print("passwords match")
                        request.session['id'] = logged_user.id
                        request.session['username'] = Users.objects.get(id=logged_user.id).First_Name
                        return redirect("/wall")
            return redirect("/")
def success(request):
    context = {
    "allusers": Users.objects.all()
    }
    if 'id' not in request.session:
        return redirect("/")
    else:
        return render(request, "login/success.html", context)
def logout(request):
    if request.method == "POST":
        if request.POST['hide'] == "logout":
            request.session.clear()
            return redirect("/")