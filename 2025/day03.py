import adventofcode as aoc

input = aoc.read_input(day=3, InputType=aoc.Input.Real)

# each bank has some amount of batteries
# eac battery has a value from 1 to 9
# within each bank, exactly two batteries have to be turned on
# the joltage of the bank is equal to the number formed by the digits of the two turned on batteries
# for example a bank [12345] with batteries 2 and 4 turned on has a joltage of 24 jolts
# we need to find the largest possible joltage of each bank

def part1(input):
    total_joltage = 0
    for bank in input:
        aoc.info(f"Searching bank: {bank}")
        battery_pairs = {}
        primary_battery_indexes = get_indexes_of_max_value_batteries(bank[:-1])
        for primary_index in primary_battery_indexes:
            secondary_battery_indexes = get_indexes_of_max_value_batteries(bank[primary_index+1:])
            secondary_battery_indexes = [sec_index + primary_index + 1 for sec_index in secondary_battery_indexes] # add offset
            battery_pairs[primary_index] = secondary_battery_indexes
        primary = bank[next(iter(battery_pairs.keys()))]
        secondary = bank[next(iter(battery_pairs.values()))[0]]
        joltage = int(f"{primary}{secondary}")
        total_joltage += joltage
        aoc.cyan(f"joltage: {joltage}")
    aoc.answer(total_joltage)

def get_indexes_of_max_value_batteries(bank):
    indexes = []
    for search_value in range(9, 1, -1):
        # break if already found in last loop
        if len(indexes) != 0:
            break
        for battery_index in range(len(bank)):
            if int(bank[battery_index]) == search_value:
                indexes.append(battery_index)
    return indexes

part1(input)
