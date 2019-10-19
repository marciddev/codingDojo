from django.shortcuts import render, redirect
from django.contrib import messages
from .models import *
import bcrypt
from datetime import datetime, date, timedelta

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
                birthday = request.POST["birthday_login"]
                password = request.POST['Password']
                pw_hash = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
                confpass = request.POST['Confirm_Password']
                coppa = timedelta(days=365*13)
                if datetime.now() > datetime.strptime(birthday, "%Y-%m-%d") and datetime.strptime(birthday, "%Y-%m-%d") < datetime.now() - coppa:
                    user = Users.objects.create(First_Name=first, Last_Name=last, Email=email, Password=pw_hash, Birthday=birthday)
                    user.save()
                    request.session['id'] = user.id
                    request.session['username'] = Users.objects.get(id=user.id).First_Name
                    return redirect("/success")
                else:
                    messages.error(request, "Invalid birthday!")
                    return redirect("/")
def login(request):
    errors = Users.objects.validate2(request.POST)
    if len(errors) > 0:
        for k,v in errors.items():
            messages.error(request, v)
        return redirect("/")
    else:
        if request.method == "POST":
            print("POST")
            if request.POST['hide'] == "log":
                print("hide is log")
                ema = Users.objects.filter(Email=request.POST["Email2"])
                if ema:
                    print("user in db")
                    logged_user = ema[0]
                    if bcrypt.checkpw(request.POST['Password2'].encode(), logged_user.Password.encode()):
                        print("password match")
                        request.session['id'] = logged_user.id
                        request.session['username'] = Users.objects.get(id=logged_user.id).First_Name
                        return redirect("/success")
                    else:
                        print("password fail")
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
    request.session.clear()
    return redirect("/")