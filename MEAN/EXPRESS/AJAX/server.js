const express = require("express");
const app = express();
const axios = require("axios");
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
app.get('/peoplee:id', function(req, res){
  // use the axios .get() method - provide a url and chain the .then() and .catch() methods
  const { id } = req.params;
  axios.get(`https://swapi.co/api/people/?page=${id}`)
  .then(request => {
      // log the data before moving on! 
      console.log(request.data.results);
      // rather than rendering, just send back the json data!
      res.json(request.data)
  })
  .catch(error => {
      // log the error before moving on!
      console.log(error);
      res.json(error);
  })
});



app.listen(8000, () => console.log("listening on port 8000"));