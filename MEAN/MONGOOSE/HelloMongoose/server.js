const express = require("express");
const app = express();
const server = app.listen(1337);
const mongoose = require('mongoose');
app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
const session = require('express-session');
app.use(express.urlencoded({
    extended: true
}));
app.use(session({
    secret: 'keyboardkitteh',
    resave: false,
    saveUninitialized: true,
    cookie: {
        maxAge: 60000
    }
}))
const io = require('socket.io')(server);
var counter = 0;
io.on('connection', function (socket) {
    console.log("connected");
})
app.get("/", (request, response) => {
    User.find()
        .then(data => response.render('index', {
            user: data
        }))
        .catch(error => response.json(error));
});
mongoose.connect('mongodb://localhost/hello_mongoose_db', {
    useNewUrlParser: true
});
const UserSchema = new mongoose.Schema({
    name: String,
    age: Number
})
const User = mongoose.model('User', UserSchema);
app.post('/users', (request, response) => {
    const user = new User();
    user.name = request.body.name;
    user.age = request.body.age;
    user.save()
        .then(newUserData =>
            console.log('user created: ', newUserData))
        .catch(err => console.log(err))
    response.redirect("/")
})