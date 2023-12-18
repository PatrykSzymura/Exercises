import tkinter as tk
from tkinter import messagebox

class Game:
    def __init__(self, root,board_Size):
        self.board_Size = board_Size
        self.grid = [[None for _ in range(board_Size)] for _ in range(board_Size)]
        self.click_count = 0
        self.board = [[0 for _ in range(board_Size)] for _ in range(board_Size)]

        root.title(f"Tic Tac Toe {board_Size}x{board_Size}")

        for i in range(board_Size):
            for j in range(board_Size):
                button = tk.Button(root, width=10, height=4, command=lambda row=i, col=j: self.button_click(row, col))
                button.grid(row=i, column=j)
                self.grid[i][j] = button

    def __str__(self):
        print("="*self.board_Size*5)
        for row in self.board:
            for field in row:
                print(f"| {field} |",end="")
            print("")
            print("="*self.board_Size*5)
        return""

    def insert_Value(self,row , col):
        if self.click_count % 2 == 0:
            self.board[row][col] = -1
        else:
            self.board[row][col] = 1
        
    def check_Fields(self):
        #print(f"row  {self.check_Row()}")
        #print(f"col  {self.check_Col()}")
        #print(f"diag {self.check_Diag()}")
        who_Won = "tekst"
        check1 = self.check_Row()
        check2 = self.check_Col()
        check3 = self.check_Diag()

        if check1[0]:
            who_Won = check1[1]
        elif check2[0]:
            who_Won = check2[1]
        elif check3[0]:
            who_Won = check3[1]

        if check1[0] or check2[0] or check3[0]:
            for row in range(self.board_Size):
                for col in range(self.board_Size):
                    self.grid[row][col].config(state=tk.DISABLED)
            messagebox.showinfo("Game Ended",f" {who_Won} WON")
        
    

    def check_Row(self):
        for row in self.board:
            counter_X = 0
            counter_O = 0
            for field in row:
                if field == -1:
                    counter_X += 1
                    counter_O = 0
                elif field == 1:
                    counter_X = 0
                    counter_O += 1
            if counter_X >= 3:
                return [True,"x"]
            elif counter_O >= 3:
                return [True,"o"]
            else:
                continue
        return [False,None]

    def check_Col(self):
        for row in range(self.board_Size):
            counter_X = 0
            counter_O = 0
            for col in range(self.board_Size):
                field = self.board[col][row] 
                if field == -1:
                    counter_X += 1
                    counter_O = 0
                elif field == 1:
                    counter_X = 0
                    counter_O += 1
            if counter_X >= 3:
                return [True,"x"]
            elif counter_O >= 3:
                return [True,"o"]
            else:
                continue
        return [False,None]
                
    def check_Diag(self):
        field = grid.board
        tmp = 0
        
        for i in range(1,grid.board_Size-1):
            for j in range(1,grid.board_Size-1):
                if field[i][j] == field[i-1][j-1] and field[i][j] == field[i+1][j+1]:
                    tmp = field[i][j]
                    break
                elif field[i-1][j+1] == field[i][j] and field[i][j] == field[i+1][j-1]:
                    tmp = field[i][j]
                    break
                else:
                    continue
        if tmp == -1:
            return [True,"x"]
        elif tmp == 1:
            return [True,"o"]
        else:
            return [False,None]

                    

                
                 


    def button_click(self, row, col):
        self.click_count += 1

        if self.click_count % 2 == 0:
            text = "X"
        else:
            text = "O"

        self.grid[row][col].config(text=text, state=tk.DISABLED)
        self.insert_Value(row,col)
        str(self)
        self.check_Fields()
        

# Przykład użycia
root = tk.Tk()
grid = Game(root, 5)
x = 1

#grid.check_Fields()
#print(grid.board)
root.mainloop()
