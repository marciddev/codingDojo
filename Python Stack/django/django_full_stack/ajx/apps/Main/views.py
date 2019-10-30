from django.shortcuts import render

# Create your views here.
def default(request):
    return render(request, "Main/index.html")
def test(request):
    return render(request, "Main/test.html")