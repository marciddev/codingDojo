from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string

# Create your views here.
def defaulty(request):
    return HttpResponse("Test")
def randomwordgen(request):
    if 'count' not in request.session:
        request.session['count'] = 0
    if 'ranStr' not in request.session:
        request.session['ranStr'] = "GENERATE A STRING!"
    if request.method == "POST":
        if request.POST['generate'] == "ran":
            if 'ranStr' not in request.session:
                pass
            else:
                request.session['ranStr'] = get_random_string(length = 14)
                request.session['count'] += 1
        elif request.POST['generate'] == "reset":
            request.session['ranStr'] = "GENERATE A STRING BELOW!"
            del request.session['count']
        return redirect("/randomword")
    if request.method == "GET":
        return render(request, "random_words/index.html")