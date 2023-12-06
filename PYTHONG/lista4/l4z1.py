from tkinter import *

class Game:
    def __init__(self,root,board_Size):
        self.root = root
        self.board_Size = board_Size
        self.board = self.create_board()

    def create_board(self):
        board = []
        
        for row in range(0,self.board_Size):
            tmp = []
            for field in range(0,self.board_Size):
                print(field)
                tmp.append(Button(self.root,text=f"field"))
            board.append(tmp)
        return board
    
    def display_Board(self):
        for row in self.board:
            for field in row:
                field.pack()
    
root = Tk()
x = Game(root,3)

y = Button(root,text="hfjhdlz")
y.pack()

x.create_board()
root.mainloop(0)