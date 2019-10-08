from django.shortcuts import render
from time import gmtime, strftime

# Create your views here.
def dateandtime(request):
    context = {
        'time': strftime("%Y-%m-%d %H:%M %p", gmtime())
    }
    return render(request, 'first_app/index.html', context)