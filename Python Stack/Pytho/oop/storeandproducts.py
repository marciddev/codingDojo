class Store:
    def __init__(self, name):
        self.name = name
        self.products = []
    def add_product(self, new_product):
        self.products.append(new_product)
        return self
    def sell_product(self, id):
        self.products -= self.products[id]
        print(self.products)
class Product:
    def __init__(self, name, price, category):
        self.name = name
        self.price = price
        self.category = category
    def udpate_price(self, percent_change, is_increased):
        if is_increased == True:
            self.price += percent_change
        else:
            self.price -= percent_change
    def print_info(self):
        print(self.name, self.price, self.category)
walmart=Store('wallyworld')
product1=Product('ps4', 300, 'gaming')
product2=Product('computer', 1300, 'gaming')
product3=Product('iPhone', 1000, 'electronic')  
walmart.add_product(product1).add_product(product2).add_product(product3)
for i in range(len(walmart.products)):
    print(walmart.products[i].name)
   