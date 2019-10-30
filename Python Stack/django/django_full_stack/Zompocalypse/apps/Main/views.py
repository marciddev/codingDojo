from django.shortcuts import render, redirect, HttpResponse
from apps.registration.views import *
from apps.registration.models import *
# Create your views here.
def success(request):
    context = {
        "user": User.objects.get(id=request.session["id"]),
        "zombie": "Zombie",
        "human": "Human"
    }
    return render(request, "Main/index.html", context)
def admin(request):
    if User.objects.get(id=request.session["id"]).username == "kevin.kvc34":
        context = {
            "user": User.objects.get(id=request.session["id"]),
            "allusers": User.objects.all(),
            "zombie": "Zombie"
        }
        return render(request, "Main/admin_page.html", context)
    else:
        messages.error(request, "You are not allowed to access this page...")
        return redirect("/success")
def delete_user(request, id):
    User.objects.get(id=id).delete()
    return redirect("/admin")
def activity(request):
    context = {
        "user": User.objects.get(id=request.session["id"]),
        "species": User.objects.get(id=request.session["id"]).species,
        "zombies": User.objects.filter(species="Zombie"),
        "humans": User.objects.filter(species="Human"),
        "zombie": "Zombie",
        "human": "Human",
        "admin": "kevin.kvc34",
        "messages": Log.objects.order_by("-updated_at")
    }
    return render(request, "Main/activity.html", context)
def attack_user(request):
    if request.method == "POST":
        logged_user = User.objects.get(id=request.session["id"])
        attacked_user = User.objects.get(id=request.POST["username_for_attack"])
        if request.POST["hide"] == "attack_user":
            mess = Log.objects.create(message=request.POST["method_of_attack"])
            if request.POST["method_of_attack"] == "1":
                mess.message = f"{logged_user.username} just slashed {attacked_user.username}'s neck! -15 health."
                attacked_user.health = attacked_user.health -15
                attacked_user.save()
                mess.save()
                if attacked_user.health < 1:
                    logged_user.kills = logged_user.kills + 1
                    logged_user.save()
                    attacked_user.delete()
                    mess.message= mess.message + f"{attacked_user.username} has died."
                    mess.save()
                    if logged_user.kills == 10:
                        mess.message = mess.message + f"{logged_user.username} is on a 10 killstreak!"
                        mess.save()
                    elif logged_user.kills == 20:
                        mess.message = mess.message + f"{logged_user.username} is on a 20 killstreak!"
                        mess.save()
                    elif logged_user.kills == 50:
                        mess.message = mess.message + f"{logged_user.username} is on a 50 killstreak!"
                        mess.save()
            elif request.POST["method_of_attack"] == "2":
                mess.message = f"{logged_user.username} just shot {attacked_user.username}'s thigh! - 30 health."
                attacked_user.health = attacked_user.health - 30
                attacked_user.save()
                mess.save()
                if attacked_user.health < 1:
                    logged_user.kills = logged_user.kills + 1
                    logged_user.save()
                    attacked_user.delete()
                    mess.message= mess.message + f"{attacked_user.username} has died."
                    mess.save()
                    if logged_user.kills == 10:
                        mess.message = mess.message + f"{logged_user.username} is on a 10 killstreak!"
                        mess.save()
                    elif logged_user.kills == 20:
                        mess.message = mess.message + f"{logged_user.username} is on a 20 killstreak!"
                        mess.save()
                    elif logged_user.kills == 50:
                        mess.message = mess.message + f"{logged_user.username} is on a 50 killstreak!"
                        mess.save()
            elif request.POST["method_of_attack"] == "3":
                mess.message = f"{logged_user.username} just tore {attacked_user.username}'s eye out of their socket! - 50 health."
                attacked_user.health = attacked_user.health - 50
                attacked_user.save()
                mess.save()
                if attacked_user.health < 1:
                    logged_user.kills = logged_user.kills + 1
                    logged_user.save()
                    attacked_user.delete()
                    mess.message= mess.message + f"{attacked_user.username} has died."
                    mess.save()
                    if logged_user.kills == 10:
                        mess.message = mess.message + f"{logged_user.username} is on a 10 killstreak!"
                        mess.save()
                    elif logged_user.kills == 20:
                        mess.message = mess.message + f"{logged_user.username} is on a 20 killstreak!"
                        mess.save()
                    elif logged_user.kills == 50:
                        mess.message = mess.message + f"{logged_user.username} is on a 50 killstreak!"
                        mess.save()
            context = {
                "msg": mess
            }
            print("post hide is attack_user")
            return render(request, "Main/activities.html", context)
def profile(request):
    context = {
        "user": User.objects.get(id=request.session["id"]),
        "zombie": "Zombie"
    }
    return render(request, "Main/profile.html", context)
def leaderboard(request):
    context = {
        "user": User.objects.get(id=request.session["id"]),
        "allusers": User.objects.order_by("-kills"),
        "zombie": "Zombie"
    }
    return render(request, "Main/leaderboard.html", context)
def logclear(request):
    Log.objects.all().delete()
    return redirect("/activity-log")
def genzombieusers(request):
    for i in range(100):
        password = bcrypt.hashpw(f"zombietestpw{i}".encode(), bcrypt.gensalt())
        User.objects.create(first_name=f"Test{i}", last_name=f"Test{i}", username=f"zombieusername{i}",
        email=f"testzombieemail{i}@email.com", password=password, species="Zombie")
    return redirect("/admin")
def deletezombieusers(request):
    for i in range(100):
        User.objects.filter(username=f"zombieusername{i}").delete()
    return redirect("/admin")
def genhumanusers(request):
    for i in range(100):
        password = bcrypt.hashpw(f"humantestpw{i}".encode(), bcrypt.gensalt())
        User.objects.create(first_name=f"Test{i}", last_name=f"Test{i}", username=f"humanusername{i}",
        email=f"testzombieemail{i}@email.com", password=password, species="Human")
    return redirect("/admin")
def deletehumanusers(request):
    for i in range(100):
        User.objects.filter(username=f"humanusername{i}").delete()
    return redirect("/admin")