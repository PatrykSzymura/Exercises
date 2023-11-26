import random

#=====================================================================#
#                 Base Classes of Elemants for Monopoly               #
#=====================================================================#
class Field:
    def __init__(self,id,name):
        self.id = id
        self.name = name
        
    
    def __str__(self):
        return f"id: {self.id} | Name: {self.name}"
    
    def standOn(self):
        pass

class Start(Field) :    
    def __init__(self, id,name = "Start",buyable = False):
        self.buyable = buyable
        self.name = name
        super().__init__(id,name)
    
    def standOn(self,player):
        player.receive_Money(300)

class Tax(Start) :
    def __init__(self, id,name = "Tax",buyable = False):
        self.name = name
        self.buyable = buyable
        super().__init__(id,name)
    
    def standOn(self,player):
        tax_value = int(player.check_Value_Of_Properties() / 100)
        #print (tax_value)
        player.receive_Money(-tax_value)

class Rails(Field) :
    def __init__(self, id, name , buyable = True):
        self.owner = -1
        self.multiplier = 1
        self.price = 100
        self.buyable = buyable
        super().__init__(id, name)
    
    def set_Price(self,id):
        self.price = int(id * self.multiplier * 100)

    def calculate_fee(self):
        return self.price * self.multiplier
    
    def calculate_Buy_Price(self):
        return self.calculate_fee() * 10
    


    def __str__(self):
        if self.owner == -1:
            return super().__str__()+f" | Fee: {self.calculate_fee()}"
        else:
            return super().__str__()+f" | Fee: {self.calculate_fee()} | Owner: {self.owner}"
    
    def standOn(self,player):
        pass

class City(Rails) :

    def __init__(self, id, name,buyable = True):
        self.number_of_houses = 1
        self.buyable = buyable
        super().__init__(id, name)

    def calculate_fee(self):
        return super().calculate_fee()*self.number_of_houses
    def __str__(self):
        return super().__str__() 

    def standOn(self,player):
        pass 

class Player() :
    def __init__(self,id,name,base_money_value = 1000):
        self.id = id
        self.name = name
        self.money = base_money_value
        self.is_active = True
        self.list_Of_Properties = []
        self.position = 0

    def __str__(self):
        return f"{self.id} {self.name}"
    
    def show_Player_Card(self):
        print("="*50)
        print(f" Id: {self.id} \n Name: {self.name} \n Money: {self.money}$ \n Value of Properties: {self.check_Value_Of_Properties()}")
        print(F" Current position : {self.position}")
        print("="*50)

    def roll_Dice(self) :
        return random.randrange(1,7)

    def show_Account_Balance(self):
        return f"Account Balance of '{self.name}' : {self.money}$"

    def receive_Money(self, amount):
        self.money += amount
        
    
    def buy_Field(self, property, list_Of_players ):
        #property = Rails(10,"temp")
        print(property.buyable)
        print(property)
        if property.buyable:
            print("po if 1")
            buyPrice = property.calculate_Buy_Price()
            if property.owner == -1:
                if self.money >= buyPrice:
                    self.list_Of_Properties.append(property)
                    self.receive_Money(-buyPrice)
                    property.owner = self.id
                    return [True,"Buying Field Succeded"]
            
                else:
                    return [False,"Lack of Funds"]
            else:
                owner = list_Of_players[property.owner]
                cho = input(f"{owner.name} -  Do you want sell {property.name} for {buyPrice}$ to {self.name}? [Y/N] ").lower()
                if cho == "y":
                    if self.money >= buyPrice:
                        self.receive_Money(-buyPrice)
                        owner.receive_Money(buyPrice)
                        self.list_Of_Properties.append(property)
                        property.owner = self.id
                        return [True,f"Buying Field From {owner.name} Succeded"]
                else:
                    return [False,f"{owner.name} Don't Want Sell {property.name} to {self.name}"]

        else:
            return [False,"Not buyable or Field is owned"]

    def check_Value_Of_Properties(self) :
        tmp = 0
        for field in range(len(self.list_Of_Properties)):
            tmp += self.list_Of_Properties[field].calculate_Buy_Price()
        return tmp
    
    def still_In_Game(self) :
        if self.money <= 0 :
            return False
        else: 
            return True
        
class Game():
    def __init__(self,number_Of_Players,size_Of_Board):
        self.size_of_Board     = size_Of_Board
        self.number_Of_Players = number_Of_Players
        self.list_of_Players   = self.asign_Players()
        self.board             = self.create_Board(size_Of_Board)

    #=====================================================================#
    #                    Board Creation and Displays                      #
    #=====================================================================#
    
    def create_Board(self,size_Of_Board):
        board = []
        for i in range(0,size_Of_Board):
            if   i == 0 :
                board.append(Start(i))
            elif i % 4 == 0:
                board.append(Rails(i,f"Rails {i}",True))
            elif i % int(size_Of_Board/2) == 0:
                board.append(Tax(i))
            else:
                board.append(City(i,f"City {i}",True))
        return board
    
    def display_Full_Board(self):
        for field in self.board:
            print(field)
    
    def display_Simplified_Board(self):
        print("|",end="")
        for field in self.board:
            print(f" {field.id} |",end="")
        print("\n")

    #=====================================================================#
    #               Player Asigment , Actions and Displays                #
    #=====================================================================#

    def asign_Players(self):
        list_of_players = []
        for player_id in range(0,self.number_Of_Players):
            list_of_players.append(Player(player_id,f"Player {player_id + 1}"))
        return list_of_players

    def show_Players(self):
        for player in self.list_of_Players:
            print(player)
    
    def move_Player_Position(self,id_Of_Player):
        player = self.list_of_Players[id_Of_Player]
        dice_Result = player.roll_Dice()
        
        player.position = (player.position + dice_Result) % len(self.board)

        if player.position < dice_Result and player.position != 0 :
            self.board[0].standOn(player)

        self.board[player.position].standOn(player)

    def player_Buy_Field(self,player_Id = 0):
        player = self.list_of_Players[player_Id]
        property = self.board[player.position]

        operation_Result = player.buy_Field(property)

        if  operation_Result[0] == True:
            print(operation_Result[1])
        else:
            print(f"You cannot buy this Field !!!\nReason: {operation_Result[1]}")


    
    





monopoly = Game(2,12)
monopoly.board[1].owner = 1
monopoly.board[2].owner = 1
monopoly.board[3].owner = 1
monopoly.board[4].owner = 1
monopoly.display_Full_Board()