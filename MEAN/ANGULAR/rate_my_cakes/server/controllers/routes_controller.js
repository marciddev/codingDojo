const mongoose = require('mongoose');
const Cake = mongoose.model('Cake');
const Review = mongoose.model('Review');
module.exports = {
    home: function(request, response) {
        response.json("hello");
    },
    create: function(request, response) {
        Cake.create(request.body)
          .then(data => {
              data.save();
              response.json(data);
          })
          .catch(err => {
              console.log(err);
          })
    },
    allcakes: function(request, response) {
        Cake.find({})
          .then(data => {
              response.json(data);
          })
          .catch(err => {
              console.log(err);
          })
    },
    addRev: function(request, response) {
        Review.create(request.body) 
          .then(data => {
              Cake.findOneAndUpdate({_id: request.params.id}, {$push: {reviews: data}})
                .then(data2 => {
                    response.json(data2 + data);
                })
                .catch(err => {
                    console.log(err);
                })
          })
          .catch(err => {
              console.log(err);
          })
    },
    oneCake: function(request, response)  {
        Cake.find({_id: request.params.id})
          .then(data => {
              response.json(data);
          })
          .catch(err => {
              console.log(err);
          })
    }
}