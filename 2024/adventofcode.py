def read_input(day, example=False):
    if example:
        path = f'input/day{day:02}-example.txt'
    else:
        path = f'input/day{day:02}.txt'
    with open(path, 'r') as file:
        input = file.readlines()
        # remove \n from each line
        input = [line.rstrip() for line in input]
        return input
    