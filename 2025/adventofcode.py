from enum import Enum
import colorama

class Input(Enum):
    Example = True
    Real = False


def read_input(day, InputType):
    if InputType == Input.Example:
        path = f'input/day{day:02}-example.txt'
    else:
        path = f'input/day{day:02}.txt'
    with open(path, 'r') as file:
        input = file.readlines()
        # remove \n from each line
        input = [line.rstrip() for line in input]
        return input

def info(*args):
    print(f"{colorama.Fore.BLUE}INFO:", *args, end=colorama.Style.RESET_ALL + "\n")

def warn(*args):
    print(f"{colorama.Fore.YELLOW}WARNING:", *args, end=colorama.Style.RESET_ALL + "\n")

def error(*args):
    print(f"{colorama.Fore.RED}ERROR:", *args, end=colorama.Style.RESET_ALL + "\n")

def answer(*args):
    print(f"{colorama.Fore.GREEN}ANSWER:", *args, end=colorama.Style.RESET_ALL + "\n")

def blue(*args):
    print(f"{colorama.Fore.BLUE}", *args, end=colorama.Style.RESET_ALL + "\n")

def yellow(*args):
    print(f"{colorama.Fore.YELLOW}", *args, end=colorama.Style.RESET_ALL + "\n")

def red(*args):
    print(f"{colorama.Fore.RED}", *args, end=colorama.Style.RESET_ALL + "\n")

def green(*args):
    print(f"{colorama.Fore.GREEN}", *args, end=colorama.Style.RESET_ALL + "\n")

def cyan(*args):
    print(f"{colorama.Fore.CYAN}", *args, end=colorama.Style.RESET_ALL + "\n")

def magenta(*args):
    print(f"{colorama.Fore.MAGENTA}", *args, end=colorama.Style.RESET_ALL + "\n")
