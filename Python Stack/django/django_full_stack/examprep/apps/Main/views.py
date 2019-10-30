from django.shortcuts import render, redirect
from .models import *
from django.contrib import messages
from datetime import datetime
import bcrypt
# Create your views here.
def registration(request):
    context = {
        "register": "register",
        "login": "login"
    }
    return render(request, "Main/index.html", context)
def registerUser(request):
    if request.method == "POST":
        if request.POST["hide"] == "register":
            errors = User.objects.validateRegister(request.POST)
            if len(errors) > 0:
                for k,v in errors.items():
                    messages.error(request, v)
                return redirect("/")
            else:
                print("no errors")
                try:
                    datetime.strptime(request.POST["register_birthday"], "%Y-%m-%d")
                except:
                    messages.error(request, "Invalid birthday!")
                first_name=request.POST["register_first_name"]
                last_name = request.POST["register_last_name"]
                email=request.POST["register_email"]
                birthday=request.POST["register_birthday"]
                password=bcrypt.hashpw(request.POST["register_password"].encode(), bcrypt.gensalt())
                User.objects.create(first_name=first_name,last_name=last_name,email=email, birthday=birthday,password=password)
                return redirect("/")
def login(request):
    if request.method == "POST":
        if request.POST["hide"] == "login":
            errors = User.objects.validateLogin(request.POST)
            emails = User.objects.filter(email=request.POST["login_email"])
            if emails:
                logged_user = emails[0]
                if bcrypt.checkpw(request.POST["login_password"].encode(), logged_user.password.encode()):
                    print("Successfully logged in")
                    request.session["id"] = logged_user.id
                    print("id put in session")
                    return redirect("/books")
                else:
                    messages.error(request, "Email or password is invalid!")
                    return redirect("/")
            messages.error(request, "Email or password is invalid!")
            print("failed")
            return redirect("/")
def books(request):
    if 'id' not in request.session:
        return redirect("/")
    for book in Book.objects.all():
        if len(book.reviews.all()) > 0:
            hasReview = True
    context = {
        "user": User.objects.get(id=request.session["id"]),
        "reviews": Review.objects.all(),
        "true": hasReview
    }
    return render(request, "Main/books.html", context)
def logout(request):
    request.session.clear()
    return redirect("/")
def create_review(request):
    context = {
        "authors": Author.objects.all()
    }
    return render(request, "Main/create_review.html", context)
def process_review(request):
    if request.method == "POST":
        if request.POST["hide"] == "create_review":
            book = Book.objects.create(title=request.POST["create_title"], author=Author.objects.get(id=request.POST["create_author"]))
            review = Review.objects.create(message=request.POST["create_review"],rating=request.POST["create_rating"],user=User.objects.get(id=request.session["id"]),book=Book.objects.get(id=book.id))
            book.reviews.add(Review.objects.get(id=review.id))
            return redirect("/books")
def bookprofile(request, id):
    context = {
        "book": Book.objects.get(id=id),
    }
    return render(request, "Main/bookprofile.html", context)
def deletereview(request,revid):
    User.objects.get(id=request.session["id"]).reviews.get(id=revid).delete()
    return redirect("/books")
def addview(request, id):
    if request.method=="POST":
        n=Review.objects.create(user=User.objects.get(id=request.session['id']),book=Book.objects.get(id=id),message=request.POST["textarea_add_review"], rating=request.POST["rating_to_add"])
        n.save()
        return redirect(f"/books/{id}")
def users(request, id):
    count=0
    for i in User.objects.get(id=id).reviews.all():
        count += 1
    context ={
        "user":User.objects.get(id=id),
        "sum": count,
        "reviews": User.objects.get(id=id).reviews.all()
    }
    return render(request, "Main/user.html", context)
