from flask import Flask, render_template, redirect, request, session
import random
app = Flask(__name__)
app.secret_key = "123"
def actLog(who, count):
    if who == "farm":
        session["log"].append(f"<p style='color: green; font-style: italic; font-weight: bold; line-height: 3.5px;'>You have earned {session['farm']} gold from farm!</p>")
        session['count'] += 1
    elif who == "cave":
        session["log"].append(f"<p style='color: green; font-style: italic; font-weight: bold; line-height: 3.5px;'>You have earned {session['cave']} gold from cave!</p>")
        session['count'] += 1
    elif who == "house":
        session["log"].append(f"<p style='color: green; font-style: italic; font-weight: bold; line-height: 3.5px;'>You have earned {session['house']} gold from house!</p>")
        session['count'] += 1
def casinoLog(gain, count):
    if gain == True:
        session["log"].append(f"<p style='color: green; font-style: italic; font-weight: bold; line-height: 3.5px;'>You have earned {session['casino']} gold from the casino!</p>")
        session['count'] += 1
    else:
        session["log"].append(f"<p style='color: red; font-style: italic; font-weight: bold; line-height: 3.5px;'>You have lost {session['casino']} gold from the casino!</p>")
        session['count'] += 1
@app.route("/")
def homePage():
    if 'count' not in session: 
        session['count'] = 0
    if 'log' not in session:
        session['log'] = []
    session['badlist'] = []
    if 'farm' not in session:
        session['farm'] = 0
    elif 'cave' not in session:
        session['cave'] = 0
    elif 'house' not in session:
        session['house'] = 0
    for index in range(0, 45, 1):
        session['badlist'].append(random.randint(0, 50))
    if 'goldCounts' not in session:
        session['goldCounts'] = 0
    return render_template("index.html", goldNum = session['goldCounts'], p = "<h1>test</h1>", log = [], randFarm = random.randint(10, 20), randCave = random.randint(5, 10), 
    randHouse = random.randint(2, 5), randCasino = random.randint(0, 50))
@app.route("/process_money", methods = ["POST"])
def moneyProcess():
    if request.form["hide"] == "farm":
        session["farm"] = random.randint(10, 20)
        session['goldCounts'] += session["farm"]
        actLog("farm", session["farm"])
        session['istrue'] = True
        print(session['log'])
    elif request.form["hide"] == "cave":
        session["cave"] = random.randint(5, 10)
        session['goldCounts'] += session["cave"]
        actLog("cave", session["cave"])
        session['istrue'] = True
    elif request.form["hide"] == "house":
        session["house"] = random.randint(2, 5)
        session['goldCounts'] += session["house"]
        actLog("house", session["house"])
        session['istrue'] = True
    elif request.form["hide"] == "casino":
        print(f"{session['badlist']}")
        session["casino"] = random.randint(0, 50)
        session['tempCount'] = session['goldCounts']
        for number in session['badlist']:
            if number == session["casino"]:
                session["goldCounts"] -= session["casino"]
                casinoLog(False, session["casino"])
                print(f"{session['casino']} REMOVED FROM GOLD")
                session['istrue'] = False
                break
        if session['tempCount'] == session["goldCounts"]:
            session["goldCounts"] += session['casino']
            casinoLog(True, session["casino"])
            print(f"{session['casino']} GOLD ADDED")
            session['istrue'] = True          
    return redirect("/")
@app.route("/sclear", methods=["POST"])
def clears():
    if request.form["reset"] == "value":
        session.clear()
    return redirect("/")
if(__name__ == "__main__"):
    app.run(debug=True)


    # for i in log:
    #     <p>this</p>