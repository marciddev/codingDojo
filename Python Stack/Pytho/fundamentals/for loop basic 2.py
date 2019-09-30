# def biggieSize(li):
#     for x in range(0, len(li)):
#         if(li[x] > -1):
#             li[x] = ("big")
#     return li
# print(biggieSize([-5, 1, 3]))
# def countPositives(li):
#     count = 0
#     for x in li:
#         if(x > 0):
#             count = count + 1
#     li.pop()
#     li.append(count)
#     return li
# print(countPositives([3, 5, 6, 2, -1]))
# def sumTotal(li):
#     sum = 0
#     for x in li:
#         sum = sum + x
#     return sum
# print(sumTotal([3, 5]))
# def average(li):
#     sum = 0
#     avg = 0
#     for x in li:
#         sum = sum + x
#     avg = sum/len(li)
#     return avg
# print(average([1, 5, 10]))
# def length(li):
#     return len(li)
# print(length(1, 2, 3))
# def minimum(li):
#     min = li[0]
#     for x in li:
#         if min > x:
#             min = x
#         else:
#             pass
#     if(len(li) <= 0):
#         return False
#     return min
# print(minimum([1, 5]))
# def max(li):
#     max = 0
#     for x in li:
#         if max < x:
#             max = x
#     if(len(li) == 0):
#         return False
#     return max
# print(max([2, 6, 7]))
# def ultAnalysis(li):
#     sum = 0
#     avg = 0
#     max = 0
#     min = li[0]
#     length = len(li)
#     for x in li:
#         sum = sum + x
#         if(max < x):
#             max = x
#         if(min > x):
#             min = x
#     avg = sum/length
#     newDict = {'max': max, 'min': min, 'sum': sum,'length': length, 'avg': avg}
#     return newDict
# print(ultAnalysis([3, 5, 6, 7]))
# def reverseList(li):
#     for x in range(0, int(len(li)/2)):
#         temp = li[x]
#         li[x] = li[len(li)-1-x]
#         li[len(li)-1-x] = temp
#     return li
# print(reverseList([3, 5, 6, 7]))
