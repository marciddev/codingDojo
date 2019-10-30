from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from .models import User, Messages
import bcrypt

def index(request):
    print('*'*70)
    print("index route reached.")
    print('*'*70)
    return render(request, 'main/index.html')

def validate(request):
    print('*'*70)
    print("validaiton route reached.")
    print(request.POST)
    print('*'*70)
    errors = User.objects.basic_validator(request.POST)
    if len(errors) > 0:
        for key, value in errors.items():
            messages.error(request, value)
        return redirect('/login')
    else:
        pwh = bcrypt.hashpw(request.POST['pw'].encode(), bcrypt.gensalt())
        User.objects.create(first=request.POST['first'], last=request.POST['last'], email=request.POST['email'], password=pwh)
        messages.success(request, "User successfully added!")
    return redirect('/login/success')

def success(request):
    context ={
        "user":User.objects.last()
    }
    print('*'*70)
    print("sucess route reached.")
    print('*'*70)
    if 'email' not in request.session:
        messages.error(request, "You are not currently logged in. Please sign in.")
        return redirect('/login')
    else: 
        return render(request, 'main/wall.html', context)

def login(request):
    errors=User.objects.loginVal(request.POST)
    if len(errors) >0:
        for key, value in errors.items():
            messages.error(request, value)
        return redirect('/')
    else:
        user = User.objects.filter(email=request.POST['email'])
        logged_user=user[0]
        request.session['email']= logged_user.id
        return redirect('/login/success')
    print("*"*70)
    print("recieved this info from HTML form")
    print(request.POST)
    print("*"*70)
    return redirect ("/")

def logout(request):
    print("*"*70)
    print("logout request reached")
    print("*"*70)
    request.session.clear()
    return redirect ('/login')

def postMessage(request):
    print("*"*70)
    if request.method=="POST":
        print("postMessage reached")
        print("*"*70)
        Messages.objects.create(user=User.objects.get(id=request.session["email"]), comments=request.POST['message'])
        return redirect('/wall')

def wall(request):
    context ={
        "m":Messages.objects.all()
    }
    print("*"*70)
    print("message should be stored in db an placed in context for wall")
    print("*"*70)
    return render(request, 'main/wall.html', context)