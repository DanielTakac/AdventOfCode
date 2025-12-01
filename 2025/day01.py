import adventofcode as aoc

input = aoc.read_input(day=1, InputType=aoc.Input.Real)

def part1(input):
    dial = 50
    zero_count = 0
    for line in input:
        dir = line[0]
        val = int(line[1:])

        if dir.upper() not in  ['L', 'R']:
            aoc.warn("Unexpected direction:", dir)
        
        dial = rotate(dial, dir, val)

        aoc.info("Dial is now at:", dial)

        if dial == 0:
            zero_count += 1
            aoc.magenta("Dial hit zero!")
        
    aoc.answer(dial, zero_count)

def part2(input):
    dial = 50
    zero_count = 0
    for line in input:
        dir = line[0]
        val = int(line[1:])

        if dir.upper() not in  ['L', 'R']:
            aoc.warn("Unexpected direction:", dir)
        
        dial, zero_count = rotate(dial, dir, val, True, zero_count)

        aoc.info("Dial is now at:", dial)
        
    aoc.answer(dial, zero_count)

def rotate(dial, dir, val, part2=False, zero_count=0):
    new_dial = dial
    if dir.upper() == 'R':
        for i in range(val):
            if new_dial == 99:
                new_dial = 0
            else:
                new_dial += 1
            # part 2
            if part2 and new_dial == 0:
                zero_count += 1
                aoc.magenta("Dial hit zero!")
    elif dir.upper() == 'L':
        for i in range(val):
            if new_dial == 0:
                new_dial = 99
            else:
                new_dial -= 1
            # part 2
            if part2 and new_dial == 0:
                zero_count += 1
                aoc.magenta("Dial hit zero!")
    else:
        aoc.warn("Unexpected direction in rotate:", dir)
    return new_dial, zero_count

part2(input)

