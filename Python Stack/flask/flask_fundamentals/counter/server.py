from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = "123"
count = 0
@app.route("/")
def home():
    if 'count' in session:
        print('key exits')
        session['count'] +=1
    else:
        print('key does not exist')
        session['count'] = 0

    return render_template("index.html", num = session['count'])
@app.route("/destroy_session")
def destroy():
    session.clear()
    return render_template("destro.html")
if(__name__ == "__main__"):
    app.run(debug=True)