import random
class Card:
    def __init__(self, suite, value, name):
        self.suite = suite
        self.value = value
        self.name = name

class Deck:
    def __init__(self):
        self.deck = []
        for i in range(1,13):
            self.cardHelper("Hearts", i)
        for i in range(1,13):
            self.cardHelper("Diamonds", i)
        for i in range(1,13):
            self.cardHelper("Spades", i)
        for i in range(1,13):
            self.cardHelper("Clubs", i)

    def cardHelper(self, suite, value):
        if (value == 1):
            self.deck.append(Card(suite, value, "Ace"))
        elif(value == 11):
            self.deck.append(Card(suite, value, "Jack"))
        elif(value == 12):
            self.deck.append(Card(suite, value, "Queen"))
        elif(value == 13):
            self.deck.append(Card(suite, value, "King"))
        else:
            self.deck.append(Card(suite, value, str(value)))
    
    def shuffle(self):
        for i in range(len(self.deck)-1):
            ran = random.randint(0, len(self.deck)-1)
            self.deck[i] = self.deck[ran]
    def deal(self):
        top = self.deck[len(self.deck)-1].name
        self.deck.pop(len(self.deck)-1)
        return top
deck1 = Deck()
deck1.shuffle()
for i in range(len(deck1.deck)):
    print(deck1.deck[i].name)
print(f"*{deck1.deal()}**************")
# class Player:
#     # a Player instance should have a "hand" that holds 5 Card instances.
#     # a Player instance should have a "name" as well

#     # create a method called "draw" that adds a Card instance into
#     # the player's hand. Remember, they can only have 5 compile

#     # create a method called "discard" that removes a Card instance
#     # from the player's "hand"

#     # create a method called "show" that prints out the player's Card 
#     # instance in their hand