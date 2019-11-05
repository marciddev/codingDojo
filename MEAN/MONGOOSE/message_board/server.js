const express = require('express');
const app = express();
const mongoose = require('mongoose');
const flash = require('express-flash');
const session = require('express-session');

app.use(session({
    secret: 'keyboardkitteh',
    resave: false,
    saveUninitialized: true,
    cookie: {
        maxAge: 60000
    }
}))
app.use(flash());
app.use(express.static(__dirname + '/static'));
app.use(express.urlencoded());
app.set('views', __dirname + '/views');
app.set('view engine', 'ejs');

mongoose.connect('mongodb://localhost/message_board_db', {
    useNewUrlParser: true
});

const CommentSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        minlength: 3
    },
    message: {
        type: String,
        required: true,
        minlength: 10
    }
})
const MessageSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        minlength: 3
    },
    message: {
        type: String,
        required: true,
        minlength: 10
    },
    created_at: {
        type: Date,
        default: Date.now()
    },
    comments: [CommentSchema]
})

const Comment = mongoose.model('Comment', CommentSchema);
const Message = mongoose.model('Message', MessageSchema);

app.get('/', (request, response) => {
    Message.find({})
        .then(message_find => {
            console.log(message_find);
            response.render('index', {
                message: message_find
            });
        })
        .catch(err => {
            console.log(err);
        })
})
app.post('/create_message', (request, response) => {
    Message.create(request.body)
        .then(msg => {
            console.log(msg);
            msg.save();
            response.redirect('/');
        })
        .catch(err => {
            console.log(err);
            for (var key in err.errors) {
                request.flash('make_msg', err.errors[key].message);
            }
            response.redirect('/');
        })
})
app.post('/create_comment/:id', (request, response) => {
    const id = request.params.id;
    Comment.create(request.body)
        .then(data => {
            Message.findOneAndUpdate({
                    _id: id
                }, {
                    $push: {
                        comments: data
                    }
                })
                .then(data2 => {
                    console.log(data2);
                    response.redirect('/');
                })
                .catch(err2 => {
                    console.log(err2);
                })
        })
        .catch(err => {
            console.log(err);
            for (var key in err.errors) {
                request.flash('make_comment', err.errors[key].message);
            }
            response.redirect('/');
        })
})






























app.listen(1337);