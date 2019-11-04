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
let allusers = [];
let chats = [];
const io = require('socket.io')(server);
let counter = 0;
io.on('connection', function(socket) {
    socket.on('new-user', function(data) {
        io.emit('updated_user', {user: data.user});
    })
    socket.on('message', function(data) {
        io.emit('updated_message', {msg: data.msg});
    })
})
app.get("/", (request, response) => {
    if(!request.session.count) {
        request.session.count = 0;
    } else {
        request.session.count++;
    }
    response.render("index", {count: request.session.count, zero: 0});
})