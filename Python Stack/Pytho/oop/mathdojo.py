class MathDojo:
    def __init__(self):
        self.result = 0
    def add(self, num, *nums):
        for i in range(len(nums)):
            self.result += nums[i]
        self.result += num
        return self
    def subtract(self, num, *nums):
        for i in range(len(nums)):
            self.result -= nums[i]
        self.result -= num
        return self
mj = MathDojo()
x = mj.add(2).add(2, 5, 1, 3).subtract(1,2).result
print(x)