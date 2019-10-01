class User:
    def __init__(self, name):
        self.name=name
        self.user_balance = 0
    def make_deposit(self, amount):
        self.user_balance += amount
        return self
    def make_withdrawl(self,amount):
        self.user_balance -= amount
        return self
    def display_user_balance(self):
        print(self.user_balance)
        return self
    def transfer_money(self, amount, user):
        self.user_balance -= amount
        user.user_balance += amount
        print(self.name + ' has transferred ' + str(amount) + ' to ' + user.name)
        return self
user2 = User('kevin')
user3 = User('andrew')
user4 = User('amber')
user2.make_deposit(15).make_deposit(15).make_deposit(15).make_withdrawl(5).display_user_balance()
user3.make_deposit(10).make_deposit(15).make_withdrawl(5).make_withdrawl(3).display_user_balance()
user4.make_deposit(500).make_withdrawl(5).make_withdrawl(10).make_withdrawl(15).display_user_balance()
user2.display_user_balance()
user4.display_user_balance()
user2.transfer_money(35, user4)
user2.display_user_balance()
user4.display_user_balance()

class BankAccount:
    def __init__(self, int_rate, bal):
        self.int_rate = int_rate
        self.bal = bal
    def deposit(self, amount):
        self.bal += amount
        return self
    def withdrawl(self, amount):
        if(self.bal <= 0):
            print("insufficient funds")
        else:
            self.bal -= amount
            return self
    def display_account_info(self):
        print('balance: ', str(self.bal))
    def yield_interest(self):
        if(self.bal > 0):
            self.bal = self.bal*self.int_rate
        return self

account1=BankAccount(0.2, 500)
account2=BankAccount(0.9, 1000)
account1.deposit(10).deposit(12).deposit(14).withdrawl(5).yield_interest().display_account_info()
account2.deposit(10).deposit(20).withdrawl(5).withdrawl(5).withdrawl(2).withdrawl(3).yield_interest().display_account_info()