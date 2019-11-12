const mongoose = require('mongoose');



//creating blueprint for db obj
const quoteSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        minlength: 3
    },
    quote: String, //sort with {obj: -1(descending) 1 for ascending},
    created_at: {
        type: Date,
        default: Date.now()
    }
});
module.exports = mongoose.model('Quote', quoteSchema);