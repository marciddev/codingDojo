users1 = [
{
	first_name: "Kevin",
	last_name: "Cox",
	Languages: [
	"Python","Javascript","Python"
	]
},
{
	first_name: "Hunter",
	last_name: "Krewall",
	Languages: ["Python", "HTML"]
}
]


function userLanguages(users) {
	for(var i=0;i<users.length;i++) {
		console.log("" + users[i].first_name + " knows " + users[i].Languages);
	}
}
userLanguages(users1);