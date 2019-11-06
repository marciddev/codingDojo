const mongoose = require('mongoose');

const commentSchema = new mongoose.Schema({
    comment: {type: String, required: [true, 'You must enter something!'], minlength: 3}
})
mongoose.model('Comment', commentSchema);
module.exports = commentSchema;