const express = require("express");
const app = express();
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
app.get('/users', (request, response) => {
   var users = [
       {name: "Kevin", email: "kevin.kvc34@gmail.com"},
       {name: "Andrew", email: "amason@victory.com"}
   ];
   response.render('users', {users: users});
});
app.use(express.static(__dirname + "/static"))
app.listen(8000, () => console.log("listening on port 8000"));