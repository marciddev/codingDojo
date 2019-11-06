const mongoose = require('mongoose');
const commentSchema = require('./comment');

const secretSchema = new mongoose.Schema({
    secret: {
        type: String,
        required: [true, 'You must enter a secret to tell!'],
        minlength: 5
    },
    comments: [commentSchema]
})

mongoose.model('Secret', secretSchema);
module.exports = secretSchema;