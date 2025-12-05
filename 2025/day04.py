import adventofcode as aoc

input = aoc.read_input(day=4, InputType=aoc.Input.Real)

def part1(input):
    accessible_count = 0
    grid_width = len(input[0])
    grid_height = len(input)
    for y in range(grid_height):
        for x in range(grid_width):
            if input[y][x] == '@':
                adjacent = get_adjacent_cells(x, y, grid_width, grid_height)
                if less_than_4_adjacent_paper(input, adjacent):
                    accessible_count += 1
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

part1(input)
