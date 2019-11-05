const mongoose = require('mongoose');
const Mongoose = mongoose.model('Mongoose');

module.exports = {
    index: (request, response) => {
        const editid = request.params.editid;
        Mongoose.findOne({
                _id: editid
            })
            .then(mongoose => {
                console.log(mongoose);
                response.render('edit', {
                    mongoose: mongoose
                });
            })
            .catch(error => {
                console.log(error);
            })
    },
    root: (request, response) => {
        Mongoose.find({})
            .then(mongooses => {
                //if successful(promise), do this.
                response.render('index', {
                    mongeese: mongooses
                });
            })
            .catch(err => {
                //if unsuccessful, do this.
                console.log(err);
            })
    },
    mongooses_post: (request, response) => {
        Mongoose.create(request.body)
            .then(newMon => {
                console.log(newMon);
                response.redirect('/');
            })
            .catch(err => {
                console.log(err);
            })
    },
    new_mongoose: (request, response) => {
        response.render('newmongoose');
    },
    destroy_mongoose: (request, response) => {
        const id = request.params.id;
        Mongoose.remove({
                _id: id
            })
            .then(deletedMongoose => {
                response.redirect('/');
            })
            .catch(err => {
                console.log(err);
            }) 
    },
    get_mongoose: (request, response) => {
        const id = request.params.id;
        Mongoose.findOne({
                _id: id
            })
            .then(mongoose => {
                console.log(mongoose);
                response.render('profile', {
                    mongoose_profile: mongoose
                });
            })
            .catch(err => {
                console.log(err);
            })
    },
    post_mongoose: (request, response) => {
        const id = request.params.id;
        Mongoose.updateOne({
                _id: id
            }, {
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
    }
}