from flask import Flask, render_template  
app = Flask(__name__)    
@app.route("/play")
def play():
    return render_template("index2.html")
@app.route('/play/<times>')
def boxes(times):
    return render_template('index.html', num_times=int(times))
@app.route('/play/<times>/<color>')
def color(times, color):
    return render_template('index3.html', num_times = int(times), type_color = color)
@app.route('/success')
def success():
    return "success"  
if __name__=="__main__":  
    app.run(debug=True)    