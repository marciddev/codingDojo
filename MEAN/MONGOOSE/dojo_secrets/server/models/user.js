const mongoose = require('mongoose');
const secretSchema = require('./secret');

var validateEmail = function(email) {
    var re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    return re.test(email)
};
const userSchema = new mongoose.Schema({
    first_name: {type: String, required: [true, 'Your name must be longer!'], minlength: 3},
    last_name: {type: String, required: [true, 'Your name must be longer!'], minlength: 3},
    email:  {
        type: String,
        trim: true,
        lowercase: true,
        unique: true,
        required: 'Email address is required',
        validate: [validateEmail, 'Please fill a valid email address'],
        match: [/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/, 'Please fill a valid email address']
    },
    password: {type: String, required: [true, 'Your password is not long enough!'], minlength: 8},
    birthday: {type: Date, required: [true, 'Please enter a birthday!']},
    secrets: [secretSchema]
})
module.exports = mongoose.model('User', userSchema);