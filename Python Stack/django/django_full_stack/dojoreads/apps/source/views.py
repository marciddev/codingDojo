from django.shortcuts import render, redirect
from django.contrib import messages
from .models import *
import bcrypt
# Create your views here.
def home(request):
    return render(request, "source/index.html")
def register(request):
    if request.POST["hide"] == "register":
        errors = User.objects.validateRegistration(request.POST)
        if len(errors) > 0:
            for k,v in errors.items():
                messages.error(request, v)
            return redirect("/")
        else:
            password = request.POST["register_password"]
            secretpass = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
            new_user =User.objects.create(first_name=request.POST["register_first_name"], 
                last_name=request.POST["register_last_name"], email=request.POST["register_email"], 
                    password=secretpass)
            new_user.save()
            request.session["id"] = new_user.id
            return redirect("/books")
def login(request):
    user = User.objects.filter(email=request.POST["login_email"])
    if user:
        logged_user = user[0]
        if bcrypt.checkpw(request.POST["login_password"].encode(), logged_user.password.encode()):
            request.session["id"] = logged_user.id
            return redirect("/books")
    messages.error(request, "Password failed")
    return redirect("/")
def bookspage(request):
    context = {
        "user": User.objects.get(id=request.session["id"]).first_name,
        "allreviews": Review.objects.all()
    }
    return render(request, "source/books.html", context)
def clear(request):
    request.session.clear()
    return redirect("/")
def bookprofile(request, id):
    request.session["bookid"] = id
    context = {
        "book": Book.objects.get(id=id),
        "reviews": Book.objects.get(id=id).book_reviews.all(),
        "username": User.objects.get(id=request.session["id"])
    }
    return render(request, "source/bookprofile.html", context)
def submitreview(request):
    if request.method == "POST":
        rev = Review.objects.create(rating=request.POST["review_submit_rating"], message=request.POST["review_submit_message"],
            book=Book.objects.get(id=request.session["bookid"]),user=User.objects.get(id=request.session["id"]))
        rev.save()
    request.session["created_review"] = Review.objects.get(id=rev.id)
    return redirect(f"/books/{rev.book.id}")
def deletereview(request):
    if request.method == "POST":
        Review.objects.get(id=request.POST["hide"]).delete()
        return redirect(f"/books/{request.session['bookid']}")
def userprofile(request, id):
    count = 0
    for review in Review.objects.filter(user=User.objects.get(id=id)):
        count += 1
    context = {
        "user": User.objects.get(id=id),
        "amount": count,
        "reviews": Review.objects.filter(user=User.objects.get(id=id))
    }
    return render(request, "source/userprofile.html", context)
def addbook(request):
    context = {
        "authors": Author.objects.all()
    }
    return render(request, "source/addbook.html", context)
def add_book(request):
    if request.method == "POST":
        new_book = Book.objects.create(title=request.POST["add_book_book_title"], author=Author.objects.get(id=request.POST["authorlist"]))
        new_book.save()
        new_book.book_reviews.add(rating=request.POST["newbook_rating"], message=request.POST["newbook_review"], 
            user=User.objects.get(id=request.session["id"]), book=Book.objects.get(id=new_book.id))
        return redirect("/books")