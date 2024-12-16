import adventofcode

input_str = adventofcode.read_input(7, True)

input = []

for i in range(len(input_str)):
    split = input_str[i].split(": ")
    test_value = int(split[0])
    nums = split[1].split(" ")
    for j in range(len(nums)):
        nums[j] = int(nums[j])
    nums.insert(0, test_value)
    input.append(nums)

def generate_possible_answers(nums):
    answers = []
    
    # i give up

    return answers

total = 0

for i in range(len(input)):
    possible_answers = generate_possible_answers(input[i][1:])

    for j in range(len(possible_answers)):
        if input[i][0] == possible_answers[j]:
            total += 1

print(f"Total calibration result: {total}")
