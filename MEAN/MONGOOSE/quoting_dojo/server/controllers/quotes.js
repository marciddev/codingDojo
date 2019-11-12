const mongoose = require('mongoose');
const Quote = mongoose.model('Quote');

module.exports = {
    index: (request, response) => {
        Quote.find({})
            .then(quotes => {
                response.render('index', {
                    quotes: quotes
                });
            })
            .catch(err => {
                console.log(err);
            })
    },
    post_index: (request, response) => {
        Quote.create(request.body)
            .then(newQuote => {
                console.log(newQuote);
                response.redirect('/');
            })
            .catch(err => {
                //send this to the client i.e. express-flash, this is what the mongoose error is
                console.log(err);
                for (var key in err.errors) {
                    request.flash('quotes_error', err.errors[key].message);
                }
                response.redirect("/");
            })
    }
}