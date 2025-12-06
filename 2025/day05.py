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
    aoc.answer("Part1: Fresh and available ID count:", fresh_available_id_count)

def id_in_range(id, rng):
    start, end = rng.split('-')
    return int(start) <= int(id) <= int(end)

def part2(input):
    unique_fresh_ids = []
    empty_line_index = input.index('')
    fresh_ranges = input[:empty_line_index]
    for rng in fresh_ranges:
        start_str, end_str = rng.split('-')
        start = int(start_str)
        end = int(end_str)
        aoc.info(f"Scanning range {fresh_ranges.index(rng)+1}, length: {end - start}")
        for id in range(start, end + 1):
            if id not in unique_fresh_ids:
                unique_fresh_ids.append(id)
    aoc.answer("Part2: Unique fresh ID count:", len(unique_fresh_ids))

# part1(input)
part2(input)
