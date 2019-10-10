from django.shortcuts import render, HttpResponse, redirect
from apps.Main.models import *

# Create your views here.
def blist(request):
    context = {
            "allbooks": Book.objects.all()
        }
    return render(request, 'Main/booklist.html', context)
def alist(request):
    context = {
        "allauthors": Author.objects.all()
    }
    return render(request, 'Main/authorlist.html', context)
def bprofile(request, id):
    request.session['bidentity'] = id
    context = {
        'title': Book.objects.get(id=id).title,
        'desc': Book.objects.get(id=id).desc,
        'id': Book.objects.get(id=id).id,
        'authors': Book.objects.get(id=id).authors.all(),
        'totalauthors': Author.objects.all()
    }
    return render(request, "Main/bookprofile.html", context)
def aprofile(request, aid):
    request.session['aidentity'] = aid
    context = {
        'id': Author.objects.get(id=aid).id,
        'firstname': Author.objects.get(id=aid).first_name,
        'lastname': Author.objects.get(id=aid).last_name,
        'notes': Author.objects.get(id=aid).notes,
        'books': Author.objects.get(id=aid).books.all(),
        'totalbooks': Book.objects.all()
    }
    return render(request, "Main/authorprofile.html", context)
def procbooks(request):
    if request.method == "POST":
        titlevar = request.POST['thetitle'],
        descvar = request.POST['description']
        Book.objects.create(title=titlevar,desc=descvar)
    return redirect("/")
def procauthors(request):
    if request.method == "POST":
        firstvar = request.POST['first_name'],
        lastvar = request.POST['last_name']
        notesvar=request.POST['notes']
        Author.objects.create(first_name=firstvar, last_name=lastvar,notes=notesvar)
    return redirect("/authorlist")
def addedauthor(request):
    if request.method == "POST":
        option = request.POST['selection']
        Book.objects.get(id=request.session['bidentity']).authors.add(Author.objects.get(id=option))
    return redirect(f"/bookprofile/{request.session['bidentity']}")
def addedbook(request):
    if request.method == "POST":
        option2 = request.POST['selection2']
        Author.objects.get(id=request.session['aidentity']).books.add(Book.objects.get(id=option2))
    return redirect(f"/authorprofile/{request.session['aidentity']}")