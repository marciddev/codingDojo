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
    response.render("index");
})
app.post("/results", (request, response)=> {
    var data_submitted = 
        {
            name: request.body.name, 
            loc: request.body.loc,
            lang: request.body.lang,
            comment: request.body.comment
        }
    response.render("results", {info: data_submitted});
})
app.listen(8000, () => console.log("listening on port 8000"));