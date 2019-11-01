const express = require("express");
const app = express();
app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
const session = require('express-session');
app.use(express.urlencoded({extended: true}));
app.use(session({
  secret: 'keyboardkitteh',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}))
app.get("/", (request, response) => {
    console.log(request.originalUrl);
    if(!request.session.ran) {
        request.session.ran = Math.floor(Math.random() * 10);
    }
    response.render("index", {ran: request.session.ran});
})
app.post("/guess_num", (request, response) => {
    console.log(request.session.ran);
    if(request.body.num == request.session.ran) {
        var cont = true;
    } else {
        var cont = false;
    }
    console.log(request.originalUrl);
    response.render("result", {bool: cont});
})
app.get("/reset", (request, response) => {
    request.session.destroy();
    response.redirect("/")
    
})
app.listen(8000, () => console.log("listening on port 8000"));