from flask import Flask, render_template, request
app = Flask(__name__)
@app.route("/")
def index():
    return render_template("index.html")
@app.route("/result", methods=["POST"])
def process():
    print("testing")
    return render_template("process.html", name=request.form['name']
    , loc=request.form['Location'], lang=request.form['Language']
    , com=request.form['comment'])



if __name__ == "__main__":
    app.run(debug=True)