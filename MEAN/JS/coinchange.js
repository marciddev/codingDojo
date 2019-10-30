function coinChange(integer) {
	dollar = 0;
	penny = 0;
	dime = 0;
	quarter = 0;
	nickel = 0;
	if(integer > 100) {
		while(integer > 100) {
			integer -= 100;
			dollar += 1;
		}
	}
	if(integer > 25 && integer < 100) {
		while(integer > 25) {
			integer -= 25;
			quarter += 1;
		}
	}
	if(integer > 10 && integer < 25) {
		while(integer > 10) {
			integer-=10;
			dime += 1;
		}
	}
	if(integer > 5 && integer < 10) {
		while(integer > 5) {
			integer -= 5;
			nickel += 1;
		}
	}
	if(integer > 1 && integer < 5) {
		while(integer > 1) {
			integer -= 1;
			penny += 1;
		}
	}
	return "Dollars: " + dollar + ", Quarters: " + quarter + ", dimes: " + dime + ", nickels: " + nickel + ", pennies: " + penny;
}
i = coinChange(512);
