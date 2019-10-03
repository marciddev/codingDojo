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
@app.route('/lists')
def render_lists():
    student_info = [
        {'first_name' : 'Michael', 'last_name' : 'Choi'},
        {'first_name' : 'John', 'last_name' : 'Supsupin'},
        {'first_name' : 'Mark', 'last_name' : 'Guillen'},
        {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]
    return render_template("lists.html", students = student_info)
if __name__=="__main__":  
    app.run(debug=True)    