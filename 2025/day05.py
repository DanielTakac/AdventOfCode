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
    # 1. convert str input into array of int ranges
    empty_line_index = input.index('')
    fresh_ranges_str = input[:empty_line_index]
    fresh_ranges = []
    for rng_str in fresh_ranges_str:
        start_str, end_str = rng_str.split('-')
        fresh_ranges.append([int(start_str), int(end_str)])
    # 2. find unique id ranges
    unique_id_ranges = []
    for rng in fresh_ranges:
        aoc.info(f"Scanning range {fresh_ranges.index(rng)+1}, [{rng[0]}-{rng[1]}], length: {rng[1] - rng[0] + 1}")
        # check if overlaps with any other already seen range
        unique = True
        identical = False
        for seen_range in unique_id_ranges:
            if check_if_overlap(rng, seen_range):
                unique = False
                aoc.yellow(f"Range [{rng[0]}-{rng[1]}] is not unique")
                if rng[0] == seen_range[0] and rng[1] == seen_range[1]:
                    aoc.red(f"Range [{rng[0]}-{rng[1]}] is identical to already seen range")
                    identical = True
                break
        if unique:
            unique_id_ranges.append(rng)
            aoc.cyan(f"Found new unique range: [{rng[0]}-{rng[1]}]")
        if not unique and not identical:
            split_until_no_overlap(rng, unique_id_ranges)
    # 3. count unique ids from found ranges
    unique_id_count = 0
    for rng in unique_id_ranges:
        unique_id_count += (rng[1] - rng[0] + 1)
    aoc.answer("Part2: Unique fresh ID count:", unique_id_count)

def check_if_overlap(rng1, rng2):
    return max(rng1[0], rng2[0]) <= min(rng1[1], rng2[1])

def split_until_no_overlap(rng, unique_id_ranges):
    ranges_to_process = [rng]
    while len(ranges_to_process) > 0:
        current_range = ranges_to_process.pop(0)
        overlap_found = False
        for seen_range in unique_id_ranges:
            if check_if_overlap(current_range, seen_range):
                overlap_found = True
                aoc.magenta(f"Splitting range [{current_range[0]}-{current_range[1]}] due to overlap with [{seen_range[0]}-{seen_range[1]}]")
                # split current_range into non-overlapping parts
                if current_range[0] < seen_range[0]:
                    new_range = [current_range[0], seen_range[0] - 1]
                    ranges_to_process.append(new_range)
                if current_range[1] > seen_range[1]:
                    new_range = [seen_range[1] + 1, current_range[1]]
                    ranges_to_process.append(new_range)
                break
        if not overlap_found:
            unique_id_ranges.append(current_range)

part1(input)
part2(input)
