const express = require('express');
const app = express();
const mongoose = require('mongoose');
const path = require('path');
app.use(express.static(__dirname + '/public/dist/public'));
app.listen(1337);
app.use(express.json());

mongoose.connect('mongodb://localhost/authors', {
    useNewUrlParser: true
});

const authorSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        minlength: 3
    }
});
const Author = new mongoose.model('Author', authorSchema);

app.get('/api', (request, response) => {
console.log("inside of app.get('/')");
    Author.find({})
    .then(data => {
        console.log("inside of .then(data)");
        console.log(data);
        response.json(data);
    })
    .catch(err => {
        console.log(err);
    })
})
app.delete('/api/delete/:id', (request, response) => {
    console.log("inside of deleete");
    Author.deleteOne({_id: request.params.id})
      .then(data => {
          response.json(data);
      })
      .catch(err => {
          response.json(data);
          console.log(err);
      })
})
app.post('/api', (request, response) => {
    console.log("inside of post api before promise");
    Author.create(request.body)
      .then(data => {
          console.log("inside of post api");
          console.log(data);
          response.json(data);
      })
      .catch(err => {
          console.log(err);
      })
})
app.put('/edit/:id', (request, response) => {
    Author.findOneAndUpdate({_id: request.params.id}, request.body)
      .then(data => {
          response.json(data);
      })
      .catch(err => {
          console.log(err);
      })
})
app.all('*', (request, response, next) => {
    console.log("inside of response.sendFile");
    response.sendFile(path.resolve("./public/dist/public/index.html"));
})