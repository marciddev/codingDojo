#1.
x = [ [5,2,3], [10,8,9] ] 
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]
#changing 10 to 15 in x
for i in range(len(x)):
    for j in range(len(x[i])):
        if x[i][j] == 10:
            x[i][j] = 15
print(x)
#changing last_name of first student from jordan to bryant
for i in range(len(students)):
    if students[i]['last_name'] == 'Jordan':
        students[i]['last_name'] = 'Bryant'
print(students)
#changing messi to andres
for i in range(len(sports_directory)):
    if sports_directory['soccer'][i] == 'Messi':
        sports_directory['soccer'][i] = 'Andres'
print(sports_directory)

#changing 20 in z to 30
for i in range(len(z)):
    if(z[i]['y']==20):
        z[i]['y'] = 30
print(z)

#2.
students = [
         {'first_name':  'Michael', 'last_name' : 'Jordan'},
         {'first_name' : 'John', 'last_name' : 'Rosales'},
         {'first_name' : 'Mark', 'last_name' : 'Guillen'},
         {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]
for i in range(len(students)):
    for k,v in students[i].items():
        print(k + ' - ',v)

#3.
def valueIterator(li=students, key='first_name'):
    for i in range(len(li)):
        print(li[i][key])
valueIterator()
#4.
dojo = {
   'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}
def iterDictList(li=dojo):
    for i in li:
        print(len(i), i)
        for j in li[i]:
            print(j)
iterDictList()