const express = require("express");
const app = express();
app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
app.get("/cats", (request, response) => {
    var cat_array = [
        {name: "Tom", image: "cat3.jpg", age: 3},
        {name: "Jerry", image: "downloadcat.jfif", age: 5}
    ]
    response.render("cats", {cats: cat_array});
});
app.get("/Tom", (request, response) => {
    var cat_array = [
        {name: "Tom", image: "cat3.jpg", age: 3}
    ]
    response.render("profile", {cat: cat_array});
});
app.get("/Jerry", (request, response) => {
    var cat_array = [
        {name: "Jerry", image: "downloadcat.jfif", age: 5}
    ]
    response.render("profile", {cat: cat_array});
});
app.listen(8000, () => console.log("listening on port 8000"));