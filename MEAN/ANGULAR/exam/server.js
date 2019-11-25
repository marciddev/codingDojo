const express = require('express');
const app = express();
const mongoose = require('mongoose');
const path = require('path');

app.use(express.json());
app.use(express.static(__dirname + '/public/dist/public'));

app.listen(1337);

mongoose.connect('mongodb://localhost/restauraunts');
const reviewSchema = new mongoose.Schema({
    name: {type: String, required: [true, "Name must be longer than 3 characters!"], minlength: 3},
    stars: {type: Number, required: [true, "Number must be Entered"], min: 0, max: [5, "Too high of a number!"]},
    description: {type: String, required: [true, "Description must be at least 3 characters!"], minlength: 3}
})
const Review = new mongoose.model('Review', reviewSchema);
const restaurauntSchema = new mongoose.Schema({
    name: {type: String, required: [true, ' Name Must be longer than 3 characters!'], minlength: 3},
    cuisine: {type: String, required: [true, 'Cuisine Must be longer than 3 characters!'], minlength: 3},
    reviews: [reviewSchema]
})
const Restauraunt = new mongoose.model('Restauraunt', restaurauntSchema);

app.get('/restauraunts/list', (request, response) => {
    Restauraunt.find({})
      .then(data => {
          response.json(data);
      })
      .catch(err => {
          response.json(err);
      })
})
app.post('/restauraunts/create', (request, response) => {
    Restauraunt.create(request.body)
      .then(data => {
          response.json({data: data, status: true});
      })
      .catch(err => {
        let allerrors = [];
        for(var x in err.errors) {
            allerrors.push(err.errors[x].message);
        }
        response.json({status: false, errors: allerrors});
      })
})
app.delete('/delete/:id', (request, response) => {
    Restauraunt.remove({_id: request.params.id})
      .then(data => {
          response.json(data);
      })
      .catch(err => {
          response.json(err);
      })
}) 
app.get('/rest/:id', (request, response) => { 
    Restauraunt.find({_id: request.params.id})
      .then(data => {
          console.log(data);
          response.json(data);
      })
      .catch(err => {
          console.log(err);
      })
})
app.put('/rest/:id', (request, response) => {
    Restauraunt.findOneAndUpdate({_id: request.params.id}, request.body, {runValidators: true})
      .then(data => {
          response.json({data: data, status: true});
      })
      .catch(err => {
        let allerrors = [];
        for(var x in err.errors) {
            allerrors.push(err.errors[x].message);
        }
        response.json({status: false, errors: allerrors});  
      })
})
app.get('/reviewsapi/all', (request, response) => {
    Review.find({})
      .then(data => {
          response.json(data);
      }).sort({stars: -1}) 
      .err(err => {
          response.json(err);
      })
})
app.post('/reviewsapi/new/:id', (request, response) => {
    Review.create(request.body)
      .then(data => {
          Restauraunt.findOneAndUpdate({_id: request.params.id}, {$push: {reviews: data}})
            .then(data2 => {
                console.log("**********" + data2);
                response.json({status: true, data: data2});
            })
            .catch(err => {
                console.log(err);
            })
      })
      .catch(err => {
        let allerrors = [];
        for(var x in err.errors) {
            allerrors.push(err.errors[x].message);
        }
        response.json({status: false, errors: allerrors});  
      })
})
app.all("*", (request, response, next) => {
    response.sendFile(path.resolve("./public/dist/public/index.html"));
})