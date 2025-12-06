import adventofcode as aoc

input = aoc.read_input(day=6, InputType=aoc.Input.Real)

def part1(input):
    # 1. find blank columns
    blank_columns = []
    for x in range(len(input[0])):
        all_blank = True
        for y in range(len(input)):
            if x < len(input[y]) and input[y][x] != ' ':
                all_blank = False
        if all_blank:
            blank_columns.append(x)
    # 2. split input into problems by blank columns
    problems = []
    start_x = 0
    for blank_x in blank_columns:
        problem = []
        for y in range(len(input)):
            problem.append(input[y][start_x:blank_x])
        problems.append(problem)
        start_x = blank_x + 1
    # add last problem
    problem = []
    for y in range(len(input)):
        problem.append(input[y][start_x:])
    problems.append(problem)
    # 3. solve each problem
    sum_of_results = 0
    for problem in problems:
        nums = []
        for i in range(len(problem) - 1):
            nums.append(int(problem[i].strip()))
        if problem[-1].strip() == '+':
            sum_of_results += sum(nums)
        elif problem[-1].strip() == '*':
            result = 1
            for num in nums:
                result *= num
            sum_of_results += result
        else:
            aoc.error("Unknown operator:", problem[-1].strip())
    aoc.answer("Part1:", sum_of_results)

def part2(input):
    # 1. find blank columns
    blank_columns = []
    for x in range(len(input[0])):
        all_blank = True
        for y in range(len(input)):
            if x < len(input[y]) and input[y][x] != ' ':
                all_blank = False
        if all_blank:
            blank_columns.append(x)
    # 2. split input into problems by blank columns
    problems = []
    start_x = 0
    for blank_x in blank_columns:
        problem = []
        for y in range(len(input)):
            problem.append(input[y][start_x:blank_x])
        problems.append(problem)
        start_x = blank_x + 1
    # add last problem
    problem = []
    for y in range(len(input)):
        problem.append(input[y][start_x:])
    problems.append(problem)
    # 3. solve each problem
    sum_of_results = 0
    for problem in problems:
        nums = []
        for x in range(999):
            num_str = ""
            for y in range(len(problem)):
                if x < len(problem[y]):
                    if problem[y][x] not in ' +*':
                        num_str += problem[y][x]
            if len(num_str) > 0:
                nums.append(int(num_str.strip()))
        if problem[-1].strip() == '+':
            sum_of_results += sum(nums)
        elif problem[-1].strip() == '*':
            result = 1
            for num in nums:
                result *= num
            sum_of_results += result
        else:
            aoc.error("Unknown operator:", problem[-1].strip())
    aoc.answer("Part2:", sum_of_results)

part1(input)
part2(input)
