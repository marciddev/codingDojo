from django.shortcuts import render, redirect
import random
# Create your views here.
def home(request):
    return render(request, "index.html")
def process(request):
    request.session['log'] = []
    request.session['badlist'] = [0, 3, 5, 9, 20, 50]
    if 'count' not in request.session:
        request.session['count'] = 0
    if request.method == "POST":
        if request.POST['hide'] == 'farm':
            request.session['count'] += random.randint(10, 20)
        elif request.POST['hide'] == 'cave':
            request.session['count'] += random.randint(5, 10)
        elif request.POST['hide'] == 'house':
            request.session['count'] += random.randint(2, 5)
        elif request.POST['hide'] == 'casino':
            request.session['casino'] = random.randint(0, 50)
            request.session['tempcount'] = request.session['count']
            for i in request.session['badlist']:
                if request.session['casino'] == i:
                    request.session['count'] -= request.session['casino']
                    break
            if request.session['count'] == request.session['tempcount']:
                request.session['count'] += request.session['casino'] 

    else:
        print("GET")
    return redirect("/")