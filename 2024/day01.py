import adventofcode

input = adventofcode.read_input(1)

left_list = []
right_list = []

for i in range(len(input)):
    left_str = ""
    right_str = ""
    for j in range(len(input[i])):
        if input[i][j] == " ":
            break
        left_str += input[i][j]
    for j in range(len(input[i])-1, -1, -1):
        if input[i][j] == " ":
            break
        right_str = input[i][j] + right_str
    left_list.append(int(left_str))
    right_list.append(int(right_str))

left_list.sort()
right_list.sort()

# Part 1

total_distance = 0

for i in range(len(left_list)):
    total_distance += abs(left_list[i] - right_list[i])

print("Total distance:", total_distance)

# Part 2

similarity_score = 0

for i in range(len(left_list)):
    count = 0
    for j in range(len(right_list)):
        if left_list[i] == right_list[j]:
            count += 1
    similarity_score += left_list[i] * count

print("Similarity score:", similarity_score)
