import adventofcode as aoc

input = aoc.read_input(day=2, InputType=aoc.Input.Example)

def part1(input):
    invalid_id_sum = 0
    if len(input) != 1:
        aoc.error("Input should be a single line of ranges")
        return
    ranges = input[0].split(',')
    for r in ranges:
        ids = r.split('-')
        if len(ids) != 2:
            aoc.error("Range should have two IDs:", r)
            return
        aoc.info("Checking range:", ids[0], "to", ids[1])
        for id in range(int(ids[0]), int(ids[1]) + 1):
            if not check_id_validity(str(id)):
                invalid_id_sum += id
    aoc.answer("Sum of invalid IDs:", invalid_id_sum)

def check_id_validity(id):
    if id[0] == '0':
        aoc.error("ID has a leading zero:", id)
        return False
    digit_count = {}
    for digit in id:
        if not digit.isdigit():
            aoc.error("ID is not all digits:", id)
            return False
        if digit in digit_count:
            digit_count[digit] += 1
        else:
            digit_count[digit] = 1
    for digit, count in digit_count.items():
        if count != 2:
            aoc.cyan("ID is valid:", id)
            return True
    aoc.magenta("ID is not valid:", id)
    return False

part1(input)
