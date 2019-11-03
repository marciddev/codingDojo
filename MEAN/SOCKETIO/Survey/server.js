const express = require("express");
const app = express();
const server = app.listen(1337);
app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
const session = require('express-session');
app.use(express.urlencoded({extended: true}));
app.use(session({
  secret: 'keyboardkitteh',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}))
const io = require('socket.io')(server);
var counter = 0;
io.on('connection', function(socket) {
    console.log("connected");
    socket.on('posting_form', function(data) {
        socket.emit('updated_message', {msg: `Name: ${data.name}, language: ${data.language}, location: ${data.location}, comment: ${data.comment}` });
        socket.emit('random_number', {num: Math.floor(Math.random() * 1000)});
    })
})
app.get("/", (request, response) => {
    response.render("index");
})