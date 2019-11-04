//import express
const express = require('express');
//import mongoose
const mongoose = require('mongoose');
//setting the app
const app = express();
//running the server
//setting up the configuration of the app
// set up builtin middleware
//static
app.use(express.static(__dirname + "/static"));
//setup the post methods 
app.use(express.urlencoded());
//set the view files up
app.set('views', __dirname + '/views');
//set up the view engine itself
app.set('view engine', 'ejs');

//mongoose config ---------------------------
mongoose.connect('mongodb://localhost/mongoose_dashboard_db', {useNewUrlParser: true});

//schema blueprint
const mongooseSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 3},
    age: Number,
    created_at: {type: Date, default: Date.now()}
})

//create collections
const Mongoose = mongoose.model('mongoose', mongooseSchema);

//--------------------------------------------

app.get('/mongooses/edit/:editid', (request, response) => {
    const editid = request.params.editid;
    Mongoose.findOne({_id: editid})
      .then(mongoose => {
          console.log(mongoose);
          response.render('edit', {mongoose: mongoose});
      })
      .catch(error => {
          console.log(error);
      })
})

app.get('/', (request, response) => {
    Mongoose.find({})
      .then(mongooses => {
          //if successful(promise), do this.
          response.render('index', {mongeese: mongooses});
      })
      .catch(err => {
          //if unsuccessful, do this.
          console.log(err);
      })
})
app.post('/mongooses', (request, response) => {
    Mongoose.create(request.body)
      .then(newMon => {
          console.log(newMon);
          response.redirect('/');
      })
      .catch(err => {
          console.log(err);
      })
})
app.get('/mongooses/new', (req, response)=> {
    response.render('newmongoose');
})
app.get('/mongooses/destroy/:id', (request, response) => {
    const id = request.params.id;
    Mongoose.remove({_id: id})
      .then(deletedMongoose => {
          response.redirect('/');
      })
      .catch(err => {
          console.log(err);
      })
})
app.get('/mongooses/:id', (request, response) => {
    const id = request.params.id;
    Mongoose.findOne({_id: id})
      .then(mongoose => {
          console.log(mongoose);
          response.render('profile', {mongoose_profile: mongoose});
      })
      .catch(err => {
          console.log(err);
      })
})
app.post('/mongooses/:id', (request, response) => {
    const id=request.params.id;
    Mongoose.updateOne({_id: id}, {
        name: request.body.name,
        age: request.body.age
    })
      .then(mongoose => {
          console.log(mongoose);
          response.redirect(`/mongooses/${id}`);
      })
      .catch(err => {
          console.log(err);
      })
})
app.listen(1337);