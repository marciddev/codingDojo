import random
def randIntt(min='', max=''):
    if min == '' and max == '':
        num = random.random() * 100
    elif min == '':
        num = random.random() * max
    elif max == '':
        num = random.random() * 110 + min
    else:
        num = random.random() * max + min
    return round(num)
print(randIntt(min=50, max=500))
print(randIntt())
print(randIntt(min=50))
print(randIntt(max=500))