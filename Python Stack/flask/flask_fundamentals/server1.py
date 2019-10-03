from flask import Flask 
 
app = Flask(__name__)

@app.route("/")
def display():
    return "<h1>Hello World!!</h1>"
@app.route("/dojo")
def dojo():
    return "dojo"
@app.route("/say/<name>")
def displayName(name):
    return name
@app.route("/repeat/<word>/<times>")
def repeatRoute(word, times):
    repeat = ""
    for i in range(int(times)):
        repeat += " " + word
    return repeat
if "__main__" == __name__:
    app.run(debug=True)