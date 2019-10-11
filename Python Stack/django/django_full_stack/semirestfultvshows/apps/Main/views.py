from django.shortcuts import render, HttpResponse, render, redirect
from apps.Main.models import *
# Create your views here.
def homepage(request):
    return redirect("/shows")
def newshows(request):#GET METHOD: Shows the create a show form...
    return render(request, "Main/newshowstemplate.html")
def createshow(request):#POST METHOD: Gathers the new show data and adds to db and redirects to /shows/<id>
    if request.method == "POST":
        if request.POST["hide"] == "createshow":
            n=Show.objects.create(title=request.POST['showtitle'],network=request.POST['networkname'],release_date=request.POST['showdate'],description=request.POST['showdesc'])
            n.save()
    return redirect(f"/shows/{n.id}")
def viewshow(request, grabid):#GET METHOD: Showing the individual show's "profile"
    request.session['ident'] = grabid
    context = {
        "title" : Show.objects.get(id=request.session['ident']).title,
        "network": Show.objects.get(id=request.session['ident']).network,
        "releasedate": Show.objects.get(id=request.session['ident']).release_date,
        "description": Show.objects.get(id=request.session['ident']).description,
        "updated": Show.objects.get(id=request.session['ident']).updated_at,
        "id": Show.objects.get(id=request.session['ident']).id,
        "allshows": Show.objects.all()
    }
    return render(request, "Main/showprofile.html", context)
def showstable(request):#GET METHOD: Rendering the template with the data table
    context = {
        "allshows": Show.objects.all()
    }
    return render(request, "Main/tabletemplate.html", context)
def editshow(request, grabid2):#GET METHOD: Rendering the template with the edit show feature.
    context = {
        "iden" : grabid2
    }
    return render(request, "Main/editshows.html", context)
def updateshow(request, grabid3):#POST METHOD: Udpating the information they input to the appropriate show id.
    if request.method == "POST":
        if request.POST['hide'] == "editshow":
            n2= Show.objects.get(id=grabid3)
            n2.title=request.POST['editshowtitle']
            n2.network=request.POST['editnetworkname']
            n2.release_date=request.POST['editshowdate']
            n2.description=request.POST['editshowdesc']
            n2.save()
    context = {
        "thirdid": grabid3
    }
    return redirect(f"/shows/{n2.id}", context)#POST METHOD: Deletes the show
def deleteshow(request, grabid4):
    if request.method == "POST":
        if request.POST['hide'] == "destroy2":
            c=Show.objects.get(id=grabid4)
            c.delete()
    return redirect("/shows")