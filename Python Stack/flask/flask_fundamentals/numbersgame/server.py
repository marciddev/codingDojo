from flask import Flask, session, redirect, render_template, request, url_for
import random
app = Flask(__name__)
app.secret_key = "4684"
randomNum = random.randint(0, 100)
@app.route("/")
def home():
    session['ranNum'] = randomNum
    print(session['ranNum'])
    return render_template("index.html")
@app.route("/dumb", methods=["POST"])
def inf():
    session['number'] = int(request.form['inputt'])
    return redirect("/redir")
@app.route("/redir")
def ren():
    return render_template("information.html")
@app.route("/destroy")
def destr():
    session.clear()
    return "destroyed session"


if __name__ == "__main__":
    app.run(debug=True)