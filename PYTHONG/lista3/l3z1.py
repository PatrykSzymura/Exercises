from module import importFromFile 
from module import menu
import random

class Pole:

    def __init__(self,id,nazwa) :

        self.id = id
        self.nazwa = nazwa

    def __str__(self):
        return " id = {} \n nazwa = {}".format(self.id,self.nazwa)
    
    def standOn(self):
        pass

class PoleKupne(Pole):

    def __init__(self, id, nazwa,cenaKupna):
        self.cenaKupna = cenaKupna
        super().__init__(id, nazwa)

    def __str__(self):
        return super().__str__()+"\n cena kupna = {}".format(self.cenaKupna)
    
class PoleKolej(PoleKupne):

    def __init__(self, id, nazwa, cenaKupna,mnoznik):
        self.mnoznik = mnoznik
        super().__init__(id, nazwa, cenaKupna)

    def __str__(self):
        return super().__str__()+"\n oplata za postoj = {}".format(str(self.ustalOplate()))
    
    def ustalOplate(self):
        return self.cenaKupna*self.mnoznik
    
class Plansza:

    def __init__(self,board,numPlayers):
        self.board = board 
        self.numPlayers = numPlayers
        self.positionOfPlayers = []

    def createBoard(self):
        self.board = []
        for i in range(0,12):
            self.board.append(PoleKolej(i,"nazwa"+str(i),100*i,0))
        return self.board
    
    # def showBoard(self):
    #     for i in self.board:
    #         print("#"*50)
    #         for i in self.positionOfPlayers:
    #             if i == self.positionOfPlayers[i][1]:
    #                 print(self.positionOfPlayers[i][0])
    #         print(i)

    def showBoard(self):
        for field_index, (player, position) in enumerate(self.positionOfPlayers):
            field = self.board[position]
            print(f"Field {field_index}: {field} - Player: {player.name}")


    def setPlayersPositions(self):
        for i in range(0,self.numPlayers):
            row = [Player(i,"gracz "+str(i)) , 0]
            self.positionOfPlayers.append(row)
    
    def movePlayer(self,who):
        x = self.positionOfPlayers[who][0].rollDice()
        print(x)

        



class Player():

    def __init__(self, id, name,money = 100,position = 0):
        self.name = name
        self.id = id
        self.money = money
        self.position = position

    def __str__(self):
        return self.name
        
    def transferMoney(self,amount,player):
        if (self.money != 0) and self.money > amount:
            self.money = self.money - amount
            player.money = player.money + amount
        else :
            return "transfer nieudany"
    def rollDice():
        return random.randrange(1,6)
    
    def buyEstate(self,currentPos):
        row = [currentPos,1]
        self.estate.append(row)





monopol = Plansza([],3)
monopol.createBoard()
monopol.setPlayersPositions()
monopol.showBoard()