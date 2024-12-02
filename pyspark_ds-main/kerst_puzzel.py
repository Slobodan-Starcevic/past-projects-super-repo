all_rows = [[[0, 0, 3], [0, 1, 0], [0, 0, 0], [0, 0, 5]],
            [[0, 6, 3], [0, 0, 5], [0, 2, 4], [0, 5, 0], [6, 0, 0]],
            [[0, 0, 0], [0, 0, 0], [0, 0, 0], [2, 0, 0], [0, 0, 0], [0, 0, 3]],
            [[0, 3, 5], [0, 0, 0], [1, 4, 0], [0, 0, 0], [0, 0, 0], [2, 6, 0], [0, 6, 0]],
            [[0, 0, 0], [0, 0, 3], [0, 0, 0], [0, 1, 3], [0, 0, 5], [0, 0, 0]],
            [[4, 0, 0], [6, 0, 0], [0, 0, 0], [0, 0, 0], [0, 5, 3]],
            [[6, 0, 0], [0, 0, 5], [0, 5, 4], [0, 0, 0]]]

def get_totals(all_rows):
    x_totals = {
        37: [all_rows[0][3][1], all_rows[0][3][2], all_rows[1][4][1], all_rows[1][4][2],
             all_rows[2][5][1], all_rows[2][5][2], all_rows[3][6][1], all_rows[3][6][2]],
        43: [all_rows[0][2][1], all_rows[0][2][2], all_rows[1][3][1], all_rows[1][3][2],
             all_rows[2][4][1], all_rows[2][4][2], all_rows[3][5][1], all_rows[3][5][2], all_rows[4][5][1], all_rows[4][5][2]],
        47: [all_rows[0][1][1], all_rows[0][1][2], all_rows[1][2][1], all_rows[1][2][2], all_rows[2][3][1], all_rows[2][3][2],
             all_rows[3][4][1], all_rows[3][4][2], all_rows[4][4][1], all_rows[4][4][2], all_rows[5][4][1], all_rows[5][4][2]],
        52: [all_rows[0][0][1], all_rows[0][0][2], all_rows[1][1][1], all_rows[1][1][2], all_rows[2][2][1], all_rows[2][2][2],
             all_rows[3][3][1], all_rows[3][3][2], all_rows[4][3][1], all_rows[4][3][2], all_rows[5][3][1], all_rows[5][3][2], all_rows[6][3][1], all_rows[6][3][2]],
        60: [all_rows[1][0][1], all_rows[1][0][2], all_rows[2][1][1], all_rows[2][1][2], all_rows[3][2][1], all_rows[3][2][2],
             all_rows[4][2][1], all_rows[4][2][2], all_rows[5][2][1], all_rows[5][2][2], all_rows[6][2][1], all_rows[6][2][2]],
        38: [all_rows[2][0][1], all_rows[2][0][2], all_rows[3][1][1], all_rows[3][1][2], all_rows[4][1][1], all_rows[4][1][2],
             all_rows[5][1][1], all_rows[5][1][2], all_rows[6][1][1], all_rows[6][1][2]],
        39: [all_rows[3][0][1], all_rows[3][0][2], all_rows[4][0][1], all_rows[4][0][2],
             all_rows[5][0][1], all_rows[5][0][2], all_rows[6][0][1], all_rows[6][0][2]],
    }

    y_totals = {
        29: [all_rows[0][0][0], all_rows[0][0][1], all_rows[1][0][0], all_rows[1][0][1],
             all_rows[2][0][0], all_rows[2][0][1], all_rows[3][0][0], all_rows[3][0][1]],
        30: [all_rows[0][1][0], all_rows[0][1][1], all_rows[1][1][0], all_rows[1][1][1],
             all_rows[2][1][0], all_rows[2][1][1], all_rows[3][1][0], all_rows[3][1][1], all_rows[4][0][0], all_rows[4][0][1]],
        45: [all_rows[0][2][0], all_rows[0][2][1], all_rows[1][2][0], all_rows[1][2][1], all_rows[2][2][0], all_rows[2][2][1],
             all_rows[3][2][0], all_rows[3][2][1], all_rows[4][1][0], all_rows[4][1][1], all_rows[5][0][0], all_rows[5][0][1]],
        65: [all_rows[0][3][0], all_rows[0][3][1], all_rows[1][3][0], all_rows[1][3][1], all_rows[2][3][0], all_rows[2][3][1],
             all_rows[3][3][0], all_rows[3][3][1], all_rows[4][2][0], all_rows[4][2][1], all_rows[5][1][0], all_rows[5][1][1], all_rows[6][0][0], all_rows[6][0][1]],
        47: [all_rows[1][4][0], all_rows[1][4][1], all_rows[2][4][0], all_rows[2][4][1], all_rows[3][4][0], all_rows[3][4][1],
             all_rows[4][3][0], all_rows[4][3][1], all_rows[5][2][0], all_rows[5][2][1], all_rows[6][1][0], all_rows[6][1][1]],
        33: [all_rows[2][5][0], all_rows[2][5][1], all_rows[3][5][0], all_rows[3][5][1], all_rows[4][4][0], all_rows[4][4][1],
             all_rows[5][3][0], all_rows[5][3][1], all_rows[6][2][0], all_rows[6][2][1]],
        24: [all_rows[3][6][0], all_rows[3][6][1], all_rows[4][5][0], all_rows[4][5][1],
             all_rows[5][4][0], all_rows[5][4][1], all_rows[6][3][0], all_rows[6][3][1]],
    }

    z_totals = {
        28: [all_rows[0][0][0], all_rows[0][0][2], all_rows[0][1][0], all_rows[0][1][2],
             all_rows[0][2][0], all_rows[0][2][2], all_rows[0][3][0], all_rows[0][3][2]],
        39: [all_rows[1][0][0], all_rows[1][0][2], all_rows[1][1][0], all_rows[1][1][2],
             all_rows[1][2][0], all_rows[1][2][2], all_rows[1][3][0], all_rows[1][3][2], all_rows[1][4][0], all_rows[1][4][2]],
        36: [all_rows[2][0][0], all_rows[2][0][2], all_rows[2][1][0], all_rows[2][1][2], all_rows[2][2][0], all_rows[2][2][2],
             all_rows[2][3][0], all_rows[2][3][2], all_rows[2][4][0], all_rows[2][4][2], all_rows[2][5][0], all_rows[2][5][2]],
        61: [all_rows[3][0][0], all_rows[3][0][2], all_rows[3][1][0], all_rows[3][1][2], all_rows[3][2][0], all_rows[3][2][2],
             all_rows[3][3][0], all_rows[3][3][2], all_rows[3][4][0], all_rows[3][4][2], all_rows[3][5][0], all_rows[3][5][2], all_rows[3][6][0], all_rows[3][6][2]],
        46: [all_rows[4][0][0], all_rows[4][0][2], all_rows[4][1][0], all_rows[4][1][2], all_rows[4][2][0], all_rows[4][2][2],
             all_rows[4][3][0], all_rows[4][3][2], all_rows[4][4][0], all_rows[4][4][2], all_rows[4][5][0], all_rows[4][5][2]],
        54: [all_rows[5][0][0], all_rows[5][0][2], all_rows[5][1][0], all_rows[5][1][2], all_rows[5][2][0], all_rows[5][2][2],
             all_rows[5][3][0], all_rows[5][3][2], all_rows[5][4][0], all_rows[5][4][2]],
        34: [all_rows[6][0][0], all_rows[6][0][2], all_rows[6][1][0], all_rows[6][1][2],
             all_rows[6][2][0], all_rows[6][2][2], all_rows[6][3][0], all_rows[6][3][2]],
    }
    combined_totals = {}
    combined_totals.update(x_totals)
    combined_totals.update(y_totals)
    combined_totals.update(z_totals)

    return combined_totals


dice_combinations = [
    [4, 1, 2], [2, 1, 3], [3, 1, 5], [5, 1, 4], [1, 2, 4], [4, 2, 6], [6, 2, 3], [3, 2, 1],
    [1, 3, 2], [2, 3, 6], [6, 3, 5], [5, 3, 1], [1, 4, 5], [5, 4, 6], [6, 4, 2], [2, 4, 1],
    [1, 5, 3], [3, 5, 6], [6, 5, 4], [4, 5, 1], [2, 6, 4], [4, 6, 5], [5, 6, 3], [3, 6, 2]
]


def is_totals_valid(board):
    combined_totals = get_totals(board)

    for value in combined_totals.values():
        if all(v != 0 for v in value):
            for key, value in combined_totals.items():
                key_sum = key
                value_sum = sum(value)

                if key_sum != value_sum:
                    return False

            return True
        else:
            break
    return True


def is_valid_dice(faces):
    non_zero_faces = [face for face in faces if face != 0]
    for face in non_zero_faces:
        if 7 - face in non_zero_faces:
            return False
    return True


def is_valid(board, row, die, die_face, num):
    if num in board[row][die]:
        return False

    temp_faces = board[row][die][:]
    temp_faces[die_face] = num
    if not is_valid_dice(temp_faces):
        return False

    return True


def is_one_left(die):
    return len([face for face in die if face != 0]) == 2


def find_last_face(positions):
    left, top, right = positions

    for combination in dice_combinations:
        if (left == combination[0] or left == 0) and \
           (top == combination[1] or top == 0) and \
           (right == combination[2] or right == 0):
            if left == 0:
                return combination[0]
            elif top == 0:
                return combination[1]
            elif right == 0:
                return combination[2]
    return None


def solve_game(board):
    for i in range(len(board)):
        for j in range(len(board[i])):
            for k in range(len(board[i][j])):
                if board[i][j][k] == 0:
                    if is_one_left(board[i][j]):
                        last_face = find_last_face(board[i][j])
                        board[i][j][k] = last_face
                        print(f" {i, j, k} going")
                        if solve_game(board):
                            if is_totals_valid(board):
                                return True
                        board[i][j][k] = 0  # Backtrack if not valid
                    for num in range(1, 7):
                        if is_valid(board, i, j, k, num):
                            board[i][j][k] = num
                            print(f"going {i, j, k}")
                            if solve_game(board):
                                if is_totals_valid(board):
                                    return True
                            board[i][j][k] = 0  # Backtrack if not valid
                    return False  # No valid number found
    return True  # All cells filled successfully



def print_board(board):
    for i, row in enumerate(board):
        if i == 0:
            print("\n               ", row)
        elif i == 1:
            print("          ", row)
        elif i == 2:
            print("     ", row)
        elif i == 3:
            print(row)
        elif i == 4:
            print("     ", row)
        elif i == 5:
            print("          ", row)
        elif i == 6:
            print("               ", row)


print("\nDice puzzle:")
print_board(all_rows)
print("\nSolving...\n")
if solve_game(all_rows):
    print("Solution:")
    print_board(all_rows)
else:
    print("No solution found.")
