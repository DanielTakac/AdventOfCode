import adventofcode

input = adventofcode.read_input(2)

reports = []

for i in range(len(input)):
    report = input[i].split()
    for j in range(len(report)):
        report[j] = int(report[j])
    reports.append(report)

def check_safety(report):
    diffs = []
    for i in range(len(report) - 1):
        diff = report[i] - report[i + 1]
        diffs.append(diff)
        if abs(diff) < 1 or abs(diff) > 3:
            return False
    if all(diff < 0 for diff in diffs) or all(diff > 0 for diff in diffs):
        return True
    else:
        return False

safety = [None] * len(reports)

for i in range(len(reports)):
    safety[i] = check_safety(reports[i])
    if safety[i] == False:
        for j in range(len(reports[i])):
            temp_report = reports[i][:]
            del temp_report[j]
            if check_safety(temp_report):
                safety[i] = True

for i in range(len(reports)):
    for j in range(len(reports[i])):
        print(reports[i][j], end=" ")
    print("Safe" if safety[i] else "Unsafe")

print(safety.count(True))