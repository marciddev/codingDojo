from flask import Flask, render_template, redirect, request, session
import random

app = Flask(__name__)
app.secret_key = "123"
@app.route("/")
def homePage():
    session['log'] = {}
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
    return render_template("index.html", goldNum = session['goldCounts'],p = "<h1>test</h1>", log = [], randFarm = random.randint(10, 20), randCave = random.randint(5, 10), 
    randHouse = random.randint(2, 5), randCasino = random.randint(0, 50))
@app.route("/process_money", methods = ["POST"])
def moneyProcess():
    if request.form["hide"] == "farm":
        session["farm"] = random.randint(10, 20)
        session['goldCounts'] += session["farm"]
    elif request.form["hide"] == "cave":
        session["cave"] = random.randint(5, 10)
        session['goldCounts'] += session["cave"]
    elif request.form["hide"] == "house":
        session["house"] = random.randint(2, 5)
        session['goldCounts'] += session["house"]
    elif request.form["hide"] == "casino":
        print(f"{session['badlist']}")
        session["casino"] = random.randint(0, 50)
        session['tempCount'] = session['goldCounts']
        for number in session['badlist']:
            if number == session["casino"]:
                session["goldCounts"] -= session["casino"]
                print(f"{session['casino']} REMOVED FROM GOLD")
                break
        if session['tempCount'] == session["goldCounts"]:
            session["goldCounts"] += session['casino']
            print(f"{session['casino']} GOLD ADDED")
        
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