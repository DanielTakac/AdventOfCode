import adventofcode as aoc
import colorama

input = aoc.read_input(day=3, InputType=aoc.Input.Real)

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

def part2(input):
    # same as part 1 but now we need 12 batteries per bank instead of 2
    total_joltage = 0
    for bank in input:
        battery_indexes = []
        b = bank
        for i in range(12):
            # we need to leave room for the remaining batteries
            unfound_batteries = 12 - (i + 1)
            if unfound_batteries > 0:
                b = b[:-unfound_batteries]
            index = get_first_index_of_max_value_batteries(b)
            # offset index to map to original bank instead of b
            if i > 0:
                index += battery_indexes[-1] + 1
            battery_indexes.append(index)
            b = bank[battery_indexes[-1]+1:]
        joltage = int(''.join([bank[i] for i in battery_indexes]))
        total_joltage += joltage
        print_bank(bank, battery_indexes)
        aoc.cyan(f"joltage: {joltage}")
    aoc.answer(total_joltage)

def get_first_index_of_max_value_batteries(bank):
    for search_value in range(9, 0, -1):
        for battery_index in range(len(bank)):
            if int(bank[battery_index]) == search_value:
                return battery_index

# debug
def print_bank(bank, battery_indexes):
    output = ""
    for i in range(len(bank)):
        if i in battery_indexes:
            output += f"{colorama.Fore.GREEN}{bank[i]}{colorama.Style.RESET_ALL}"
        else:
            output += f"{colorama.Fore.BLUE}{bank[i]}{colorama.Style.RESET_ALL}"
    aoc.cyan(output)

part1(input)
part2(input)
