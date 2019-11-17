const express = require('express');
const app = express();
const path = require('path');
const mongoose = require('mongoose');
app.listen(1337);
app.use(express.json());
app.use(express.static(__dirname + '/public/dist/public'));
mongoose.connect('mongodb://localhost/products', {useNewUrlParser: true});
const productSchema = new mongoose.Schema({
    name: {type: String, required: [true, 'product must be of longer length!'], minlength: 5},
    price: {type: Number, required: [true, 'Must be a number!(price)']},
    image: {type: String, required: false}
})
const Product = new mongoose.model('Product', productSchema);
app.get('/products/all', (request, response) => {
    Product.find({})
      .then(data => {
          response.json(data);
      })
      .catch(err => {
          console.log(err);
      })
})
app.post('/products/new', (request, response) => {
    Product.create(request.body)
      .then(data => {
          response.json(data);
      })
      .catch(err => {
        let errorsarray = [];
          for(let x in err.errors) {
              errorsarray.push(err.errors[x].message);
          }
          response.json({errors: errorsarray});
      })
})
app.delete('/products/remove/:id', (request, response) => {
    Product.findOneAndDelete({_id: request.params.id})
      .then(data => {
          response.json(data);
      })
      .catch(err => {
          console.log(err);
      })
})
app.put('/products/editprod/:id', (request, response) => {
    Product.findOneAndUpdate({_id: request.params.id}, request.body, {runValidators: true})
      .then(data => {
          response.json(data);
      })
      .catch(err => {
        let errorsarray = [];
        for(let x in err.errors) {
            errorsarray.push(err.errors[x].message);
        }
        response.json({errors: errorsarray});
      })
})
app.get('/products/profile/:id', (request, response) => {
    Product.findOne({_id: request.params.id})
      .then(data => {
          response.json(data);
      })
      .catch(err => {
          console.log(err);
      })
})
app.all("*", (request, response, next) => {
    response.sendFile(path.resolve("./public/dist/public/index.html"));
})