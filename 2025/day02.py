import adventofcode as aoc

input = aoc.read_input(day=2, InputType=aoc.Input.Real)

if len(input) != 1:
    aoc.error("Input should be a single line of ranges")

def part1(input):
    invalid_id_sum = 0
    ranges = input[0].split(',')
    for r in ranges:
        ids = r.split('-')
        aoc.info("Checking range:", ids[0], "to", ids[1])
        for id in range(int(ids[0]), int(ids[1]) + 1):
            if not check_id_validity(str(id)):
                invalid_id_sum += id
    aoc.answer("Part1: Sum of invalid IDs:", invalid_id_sum)

def check_id_validity(id):
    split_index = len(id) // 2
    first_half = id[:split_index]
    second_half = id[split_index:]
    return not (first_half == second_half)
    
def part2(input):
    invalid_id_sum = 0
    ranges = input[0].split(',')
    for r in ranges:
        ids = r.split('-')
        aoc.info("Checking range:", ids[0], "to", ids[1])
        for id in range(int(ids[0]), int(ids[1]) + 1):
            if not check_id_validity2(str(id)):
                invalid_id_sum += id
    aoc.answer("Part2: Sum of invalid IDs:", invalid_id_sum)

def check_id_validity2(id):
    if len(id) == 1:
        return True
    for i in range(1, len(id)):
        substr = id[0:i]
        all_equal = True
        for j in range(i + 1, len(id) + 1, i):
            subtr2 = id[j-1:j+i-1]
            if substr != subtr2:
                all_equal = False
                break
        if all_equal:
            return False
    return True

part1(input)
part2(input)
