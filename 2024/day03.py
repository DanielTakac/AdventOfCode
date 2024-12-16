import adventofcode
import re

input = adventofcode.read_input(3)

sum = 0

def mul(instr):
        instr = instr[4:len(instr) - 1]
        nums = instr.split(",")
        return int(nums[0]) * int(nums[1])

for i in range(len(input)):
    regex = re.findall(r'(mul\(\d{1,3},\d{1,3}\))', input[i])

    for i in range(len(regex)):
        sum += mul(regex[i])

print(f"Sum: {sum}")
