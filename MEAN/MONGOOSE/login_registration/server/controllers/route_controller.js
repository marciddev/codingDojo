const mongoose = require('mongoose');
const User = mongoose.model('User');
const bcrypt = require('bcrypt');

module.exports = {
    index: (request, response) => {
        response.render('index');
    },
    new_user: (request, response) => {
        User.create(request.body)
            .then(data => {
                data.save();
                console.log('*'.repeat(90));
                console.log(data);
                console.log('*'.repeat(90));
                response.json(data);
            })
            .catch(err => {
                console.log(err);
            })
    },
    all_user: (request, response) => {
        User.find({})
            .then(data => {
                response.json(data);
            })
            .catch(err => {
                console.log(err);
            })
    },
    register: (request, response) => {
        bcrypt.hash(request.body.password, 10)
            .then(pass => {
                User.create({
                        first_name: request.body.first_name,
                        last_name: request.body.last_name,
                        email: request.body.email,
                        birthday: request.body.birthday,
                        password: pass
                    })
                    .then(data => {
                        console.log(data);
                        response.send("successfully created user " + data)
                    })
                    .catch(err => {
                        console.log(err);
                    })
            })
            .catch(err => {
                console.log(err);
            })

    },
    login: (request, response) => {
        User.findOne({
                email: request.body.email
            })
            .then(data => {
                const pass = data.password;
                const input_pass = request.body.password
                bcrypt.compare(input_pass, pass)
                    .then(data2 => {
                        response.send(data2);
                    })
                    .catch(err => {
                        response.send(err);
                    })
            })
            .catch(err => {
                console.log(err);
            })
    }
}