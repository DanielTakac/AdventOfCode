import adventofcode as aoc
import colorama
import time
import os

input = aoc.read_input(day=4, InputType=aoc.Input.Real)

def part1(input):
    accessible_count = 0
    grid_width = len(input[0])
    grid_height = len(input)
    removed_cells = []
    for y in range(grid_height):
        for x in range(grid_width):
            if input[y][x] == '@':
                adjacent = get_adjacent_cells(x, y, grid_width, grid_height)
                if less_than_4_adjacent_paper(input, adjacent):
                    accessible_count += 1
                    removed_cells.append((x, y))
    print_grid(input, removed_cells)
    aoc.answer("Part1: Accessible cells:", accessible_count)

def less_than_4_adjacent_paper(input, adjacent):
    adjacent_paper_count = 0
    for cell in adjacent:
        xx, yy = cell
        if input[xx][yy] == '@':
            adjacent_paper_count += 1
    if adjacent_paper_count < 4:
        return True
    return False

def get_adjacent_cells(x, y, grid_width, grid_height):
    adjacent = []
    # left
    if x != 0:
        adjacent.append((y, x - 1))
    # right
    if x != grid_width - 1:
        adjacent.append((y, x + 1))
    # up
    if y != 0:
        adjacent.append((y - 1, x))
    # down
    if y != grid_height - 1:
        adjacent.append((y + 1, x))
    # up-left
    if x != 0 and y != 0:
        adjacent.append((y - 1, x - 1))
    # up-right
    if x != grid_width - 1 and y != 0:
        adjacent.append((y - 1, x + 1))
    # down-left
    if x != 0 and y != grid_height - 1:
        adjacent.append((y + 1, x - 1))
    # down-right
    if x != grid_width - 1 and y != grid_height - 1:
        adjacent.append((y + 1, x + 1))
    return adjacent

def part2(input, print_delay=0, clear_screen=False):
    accessible_count = 0
    grid_width = len(input[0])
    grid_height = len(input)
    previous_run = 0
    removed_cells = []
    grid = input
    first_run = True
    while previous_run != 0 or first_run:
        first_run = False
        previous_run = 0
        removed_cells = []
        for y in range(grid_height):
            for x in range(grid_width):
                if grid[y][x] == '@':
                    adjacent = get_adjacent_cells(x, y, grid_width, grid_height)
                    if less_than_4_adjacent_paper(grid, adjacent):
                        removed_cells.append((x, y))
                        accessible_count += 1
                        previous_run += 1
        # clear the terminal before printing
        if clear_screen:
            os.system('cls' if os.name == 'nt' else 'clear')
        print_grid(grid, removed_cells, delay=print_delay)
        for cell in removed_cells:
            xx, yy = cell
            grid[yy] = grid[yy][:xx] + '.' + grid[yy][xx+1:]
    aoc.answer("Part2: Accessible cells:", accessible_count)

def print_grid(grid, removed_cells=[], delay=0):
    for x in range(len(grid[0])):
        print("-", end='')
    print()
    for y in range(len(grid)):
        for x in range(len(grid[0])):
            cell = grid[y][x]
            if (x, y) in removed_cells:
                print(f"{colorama.Fore.GREEN}{cell}{colorama.Style.RESET_ALL}", end='')
            elif cell == '@':
                print(f"{colorama.Fore.CYAN}{cell}{colorama.Style.RESET_ALL}", end='')
            else:
                print(f"{colorama.Fore.BLUE}{cell}{colorama.Style.RESET_ALL}", end='')
        print()
    if delay > 0:
        time.sleep(delay)

part1(input)
part2(input, print_delay=0.1, clear_screen=False)
