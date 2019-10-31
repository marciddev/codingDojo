const express = require("express");
const app = express();
app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
const session = require('express-session');
app.use(session({
  secret: 'keyboardkitteh',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}))
app.get("/", (request, response) => {
    if(request.session.count == null) {
        request.session.count = 0;
    }
    request.session.count += 1;
    response.render("index", {count: request.session.count});
})
app.get("/double", (request, response) => {
    request.session.count +=1;
    response.redirect("/");
})
app.get("/clear", (request, response) => {
    request.session.destroy();
    response.redirect("/");
})
app.listen(8000, () => console.log("listening on port 8000"));