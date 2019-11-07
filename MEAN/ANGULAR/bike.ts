class Bike {
    price: number;
    max_speed: number;
    miles: number;
    constructor(price: number, max_speed: number, miles?: number) {
        this.price = price;
        this.max_speed = max_speed;
        this.miles = 0;
    }
    displayInfo() {
        return (`The price of this bike is ${this.price} and the max speed is ${this.max_speed}`)
    }
    ride() {
        this.miles += 10;
        return ("riding");
    }
    reverse() {
        this.miles -= 5;
        return ("reversing...");
    }
}
const bike1 = new Bike(500, 5000);
bike1.ride();
bike1.ride();
bike1.ride();
bike1.reverse();
bike1.displayInfo();
const bike2 = new Bike(40, 500);
bike2.ride();
bike2.ride();
bike2.reverse();
bike2.reverse();
bike2.displayInfo();
const bike3 = new Bike(20, 400);
bike3.reverse();
bike3.reverse();
bike3.reverse();
bike3.displayInfo();