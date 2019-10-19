from django.shortcuts import render, redirect
from .models import *
from django.contrib import messages
import bcrypt
# Create your views here.
def home(request):
    return render(request, "Main/index.html")
def register(request):
    errors = User.objects.validateRegister(request.POST)

    if len(errors) > 0:
        for k,v in errors.items():
            messages.error(request, v)
        return redirect("/")
    else:
        if request.method == "POST":
            print("request is post")
            if request.POST["hide"] == "registration":
                print("hide is registration")
                firstname = request.POST["register_first_name"]
                lastname = request.POST["register_last_name"]
                email = request.POST["register_email"]
                password = request.POST["register_password"]
                hashed_password = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
                newUser = User.objects.create(First_Name = firstname, Last_Name = lastname, Email=email, Password=hashed_password)
                newUser.save()
                request.session["id"] = newUser.id
                print(User.objects.get(id=newUser.id))
                return redirect("/books")
        return redirect("/")
def success(request):
    if 'id' not in request.session:
        return redirect("/")
    else:
        context = {
            "allusers" : User.objects.all()
        }
        return render(request, "Main/success.html", context)
def login(request):
    errors = User.objects.validateLogin(request.POST)
    if len(errors) > 0:
        for k,v in errors.items():
            messages.error(request, v)
        return redirect("/")
    else:
        user = User.objects.filter(Email=request.POST["login_email"])
        if user:
            print("email in list")
            logged_user = user[0]
            if bcrypt.checkpw(request.POST["login_password"].encode(), logged_user.Password.encode()):
                print("password match! logging in...")
                request.session["id"] = logged_user.id
                return redirect("/books")
def delete(request):
    request.session.clear()
    print("session cleared!")
    return redirect("/")
def books(request):
    context = {
        "username": User.objects.get(id=request.session["id"]),
        "books": Book.objects.all()
    }
    return render(request, "Main/books.html", context)
def view_book(request, id):
    request.session["bookid"] = id
    context = {
        "title": Book.objects.get(id=id).title,
        "description": Book.objects.get(id=id).description,
        "created": Book.objects.get(id=id).created_at,
        "by": Book.objects.get(id=id).uploaded_by.First_Name,
        "updated": Book.objects.get(id=id).updated_at,
        "user": User.objects.get(id=request.session["id"]),
        "like_by": Book.objects.get(id=id).liked_by.all(),
        "id": Book.objects.get(id=id),
        "sessionid" : User.objects.get(id=request.session["id"]),
        "likedbooks": User.objects.get(id=request.session["id"]).liked_books.all()
    }
    return render(request, "Main/viewbook.html", context)
def add_book(request):
    errors = Book.objects.validateNewBook(request.POST)
    if len(errors) > 0:
        for k,v in errors.items():
            messages.error(request, v)
        return redirect("/books")
    else:
        b =Book.objects.create(title=request.POST["new_book_title"], description=request.POST["new_book_description"], 
            uploaded_by=User.objects.get(id=request.session["id"]))
        b.liked_by.add(User.objects.get(id=request.session["id"]))
        b.save()
        return redirect(f"/books/{b.id}")
def unfav(request):
    book = Book.objects.get(id=request.session["bookid"])
    book.liked_by.remove(User.objects.get(id=request.session["id"]))
    book.save()
    return redirect(f"/books/{book.id}")
def fav(request):
    book2 = Book.objects.get(id=request.session["bookid"])
    book2.liked_by.add(User.objects.get(id=request.session["id"]))
    book2.save()
    return redirect(f"/books/{book2.id}")
def descupdate(request):
    desc = Book.objects.get(id=request.session["bookid"])
    desc.description = request.POST['update_desc']
    desc.save()
    return redirect(f"/books/{desc.id}")
def favbook(request, bid):
    us = User.objects.get(id=request.session["id"])
    us.liked_books.add(Book.objects.get(id=bid))
    return redirect("/books")
def allfavbooks(request):
    context = {
        "all": User.objects.get(id=request.session["id"]).liked_books.all()
    }
    return render(request, "Main/favorite_books.html", context)