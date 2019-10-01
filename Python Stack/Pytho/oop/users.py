class User:
    def __init__(self, name):
        self.name=name
        self.user_balance = 0
    def make_deposit(self, amount):
        self.user_balance += amount
    def make_withdrawl(self,amount):
        self.user_balance -= amount
    def display_user_balance(self):
        print(self.user_balance)
    def transfer_money(self, amount, user):
        self.user_balance -= amount
        user.user_balance += amount
        print(self.name + ' has transferred ' + str(amount) + ' to ' + user.name)
user2 = User('kevin')
user3 = User('andrew')
user4 = User('amber')
user2.make_deposit(15)
user2.make_deposit(15)
user2.make_deposit(15)
user2.make_withdrawl(5)
user2.display_user_balance()
user3.make_deposit(10)
user3.make_deposit(15)
user3.make_withdrawl(5)
user3.make_withdrawl(3)
user3.display_user_balance()
user4.make_deposit(500)
user4.make_withdrawl(5)
user4.make_withdrawl(10)
user4.make_withdrawl(15)
user2.display_user_balance()
user4.display_user_balance()
user2.transfer_money(35, user4)
user2.display_user_balance()
user4.display_user_balance()
