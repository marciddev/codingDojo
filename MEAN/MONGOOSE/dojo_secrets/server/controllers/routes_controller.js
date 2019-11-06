const mongoose = require('mongoose');
const User = require('../models/user');
const bcrypt = require('bcrypt');
const Secret = mongoose.model('Secret');
const Comment = mongoose.model('Comment');

module.exports = {
    index: (request, response) => {
        response.render('index');
    },
    register: (request, response) => {
        User.findOne({
                email: request.body.email
            })
            .then(data => {
                if (data != null) {
                    console.log("DATA EXISTS");
                    request.flash('registration', 'That user exists already!');
                    response.redirect("/");
                } else {
                    if (request.body.password == request.body.confirm_password) {
                        const input_pass = request.body.password;
                        bcrypt.hash(input_pass, 10)
                            .then(data2 => {
                                console.log(input_pass);
                                User.create({
                                        first_name: request.body.first_name,
                                        last_name: request.body.last_name,
                                        email: request.body.email,
                                        password: data2,
                                        birthday: request.body.birthday
                                    })
                                    .then(data3 => {
                                        request.session.user_id = data3._id;
                                        response.redirect('/home');
                                    })
                                    .catch(err => {
                                        console.log(err);
                                        for (var key in err.errors) {
                                            request.flash('registration', err.errors[key].message);
                                        }
                                        response.redirect('/');
                                    })
                            })
                            .catch(err => {
                                console.log(err);
                            })
                    } else {
                        request.flash('registration', 'passwords do not match!');
                        response.redirect('/');
                    }
                }
            })
            .catch(err => {
                console.log(err);
            })
    },
    home: (request, response) => {
        User.find({})
            .then(data => {
                User.findOne({
                        _id: request.session.user_id
                    })
                    .then(data2 => {
                        Secret.find({})
                            .then(data3 => {
                                response.render('home', {
                                    allusers: data,
                                    logged_user: data2,
                                    allsecrets: data3
                                });
                            })
                            .catch(err => {
                                console.log(err);
                            })
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
        if (request.body.login_email.length < 1 || request.body.login_password.length < 1) {
            request.flash('login', 'Please enter something in both of the fields!');
            response.redirect('/');
        }
        User.findOne({
                email: request.body.login_email
            })
            .then(data => {
                if (data == null) {
                    request.flash('login', 'No email was found in the database!');
                    response.redirect('/');
                } else {
                    console.log(data);
                }
                bcrypt.compare(request.body.login_password, data.password)
                    .then(data2 => {
                        if (data2 == false) {
                            request.flash('login', 'The password is incorrect!');
                            response.redirect('/');
                        } else {
                            request.session.user_id = data._id;
                            response.redirect('/home');
                        }
                    })
                    .catch(err => {
                        console.log("***********************************************" + err);
                    })
            })
            .catch(err => {
                console.log("**********************************************************" + err);
            })
    },
    logout: (request, response) => {
        request.session.destroy();
        response.redirect('/');
    },
    secretcreate: (request, response) => {
        Secret.create({
                secret: request.body.secret_name
            })
            .then(data => {
                User.findOneAndUpdate({
                        _id: request.session.user_id
                    }, {
                        $push: {
                            secrets: data
                        }
                    })
                    .then(data2 => {
                        response.redirect('/home');
                    })
            })
            .catch(err => {
                console.log(err);
                for (var key in err.errors) {
                    request.flash('secret_creation', err.errors[key].message);
                }
                response.redirect('/home');
            })
    },
    view_secret: (request, response) => {
        const {
            id
        } = request.params;
        Secret.find({
                _id: id
            })
            .then(data => {
                Comment.find({})
                    .then(data2 => {
                        response.render('secret', {
                            secret: data,
                            comment: data2
                        });
                    })
                    .catch(err => {
                        console.log(err);
                    })
            })
            .catch(err => {
                console.log(err);
            })
    },
    secretdelete: (request, response) => {
        const {
            id
        } = request.params;
        Secret.remove({
                _id: id
            })
            .then(data => {
                response.redirect('/home');
            })
            .catch(err => {
                console.log(err);
            })
    },
    make_comment: (request, response) => {
        const { id } = request.params;
        Comment.create({
            comment: request.body.comment
        })
          .then(data => {
              Secret.findOneAndUpdate({_id: id}, {$push: {comments: data}})
                .then(data2 => {
                    response.redirect(`/secret/${id}`);
                })
                .catch(err => {
                    console.log(err);
                })
          })
          .catch(err => {
              console.log(err);
              for(var key in err.errors) {
                  request.flash('make_comment', err.errors[key].message);
              }
              response.redirect(`/secret/${id}`);
          })
    }
}