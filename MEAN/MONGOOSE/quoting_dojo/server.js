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
const flash = require('express-flash');
app.use(flash());
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

//connecting mongoose
mongoose.connect('mongodb://localhost/quoting_dojo', { useNewUrlParser: true});

//creating blueprint for db obj
const quoteSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 3},
    quote: String,//sort with {obj: -1(descending) 1 for ascending},
    created_at: {type: Date, default: Date.now()}
});

//creating the 'collections' 'quotes' b/c Quote turns lowercase and plural
const Quote = mongoose.model('Quote', quoteSchema);
//Quote > mongoose object


//creating the rendering of template at /quotes
app.get('/', (request, response)=> {
    Quote.find({})
      .then(quotes=> {
          response.render('index', {quotes: quotes});
      })
      .catch(err=> {
          console.log(err);
      })
})

//creating the form submission function
app.post('/', function(request, response) {
    Quote.create(request.body)
      .then(newQuote => {
          console.log(newQuote);
          response.redirect('/');
      })
      .catch(err => {
          //send this to the client i.e. express-flash, this is what the mongoose error is
          console.log(err);
          for(var key in err.errors) {
              request.flash('quotes_error', err.errors[key].message);
          }
          response.redirect("/");
      })
})