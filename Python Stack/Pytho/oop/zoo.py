class Zoo:
    def __init__(self, name, population, ticketPrice):
        self.name = name
        self.population = population
        self.ticketPrice = ticketPrice
        self.animals = []
    def add_animal(self, animal):
        self.animals.append(animal)

class Animals:
    def __init__(self, legs=4, gender='none', name='none', health=100, happiness=100, age=15):
        self.legs = legs
        self.gender = gender
        self.name = name
        self.health = health
        self.happiness = happiness
    def display_info(self, animal):
        print(f"happiness: {animal}, health: {animal}, name: {animal}")
    def feed(self):
        if self == Tiger:
            self.health +=20
            self.happiness +=5
        elif self == Panda:
            self.health +=100
            self.happiness =+1000
        else:
            self.health += 10
            self.happiness += 1
class Tiger(Animals):
    def __init__(self, legs=4, gender='none', name='none', health=100, happiness=100, age=15, stripe_color='black'):
        super().__init__(legs, gender, name, health, happiness, age)
        self.stripe_color = stripe_color
class Panda(Animals):
    def __init(self, legs=4, gender='none', name='none', health=100, happiness=100, age=15, fave_food = ''):
        super().__init__(legs, gender, name, health, happiness,age)
        self.fave_food = fave_food
class Lion(Animals):
    def __init(self, legs=4, gender='none', name='none', health=100, happiness=100, age=15, best_friend = 'lion'):
        super().__init__(legs, gender, name, health, happiness,age)
myTiger = Tiger(gender='male', name='richard the tiger', age = 201, health=50, happiness=75)
myPanda = Panda(gender='female',name='moby the panda', age=506,health=90,happiness=999)
myLion = Lion(name='noel the lion', gender='male', age=5, health = 25, happiness=50)
myZoo = Zoo('madagascar', 100000, '$20')
myZoo.add_animal(myTiger.name)
myZoo.add_animal(myPanda.name)
myZoo.add_animal(myLion.name)
print(myZoo.animals)