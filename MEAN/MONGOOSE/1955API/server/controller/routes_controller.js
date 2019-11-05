const mongoose = require('mongoose');
const Person = mongoose.model('Person');

module.exports = {
    index: (request, response) => {
        Person.find({})
          .then(data => {
              response.json(data);
          })
          .catch(err => {
              console.log(err);
          })
    },
    new_person: (request, response) => {
        const { name } = request.params;
        Person.create({
            name: name
        })
          .then(data => {
              response.redirect('/');
          })
          .catch(err => {
              console.log(err);
          })
    },
    delete_person: (request, response) => {
        const { name } = request.params;
        Person.deleteOne({name: name})
          .then(data => {
            response.redirect('/');
          })
          .catch(err => {
              console.log(err);
          })
    },
    view_person: (request, response) => {
        const { name } = request.params;
        Person.find({name: name})
          .then(data => {
              response.json(data);
          })
          .catch(err => {
              console.log(err);
          })
    }
}