var eeyore = 
{
	character: "Eeyore"
};
var Heffalumps = 
{
	character: "Heffalumps"
};
var Kanga = 
{
	character: "Kanga"
};
var chris = 
{
	character: "Christopher Robin"
};
var owl = 
{
	character: "Owl"
};
var rabbit = 
{
	character: "Rabbit"
};
var Gopher = 
{
	character: "Gopher"
};
var Bees = 
{
	character: "Bees"
};
var winnie = 
{
	character: "Whinnie the poo"
};
var piglet = 
{
	character: "Piglet"
};
var tigger = 
{
	character: "tigger"
};
eeyore.east = Heffalumps;
eeyore.south = Kanga;
Heffalumps.west = Eeyore;
Kanga.north = eeyore;
Kanga.south = chris;
chris.north = Kanga;
chris.west = owl;
chris.east = rabbit;
chris.south = winnie;
owl.east = chris;
owl.south = piglet;
rabbit.west = chris;
rabbit.south = bees;
rabbit.east = Gopher;
Gopher.west = rabbit;
piglet.north = owl;
piglet.east = winnie;
winnie.north = chris;
whinnie.west = piglet;
winnie.east = bees;
winnie.south = tigger;
bees.north = rabbit;
bees.west = winnie;
tigger.north = winnie;



