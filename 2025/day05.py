import adventofcode as aoc
import colorama

input = aoc.read_input(day=5, InputType=aoc.Input.Real)

def part1(input):
    fresh_available_id_count = 0
    empty_line_index = input.index('')
    fresh_ranges = input[:empty_line_index]
    available_ids = input[empty_line_index+1:]
    for id in available_ids:
        for rng in fresh_ranges:
            if id_in_range(id, rng):
                fresh_available_id_count += 1
                print(f"{colorama.Fore.CYAN}Ingredient ID {id} found in fresh range {rng}{colorama.Style.RESET_ALL}")
                break
    aoc.answer("Part1: Fresh and available ID count: ", fresh_available_id_count)

def id_in_range(id, rng):
    start, end = rng.split('-')
    return int(start) <= int(id) <= int(end)

part1(input)
