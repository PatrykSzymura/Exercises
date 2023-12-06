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

    def build_House(self):
        return [False,"You Cannot Build Houses There"]

class Start(Field) :    
    def __init__(self, id = 0,name = "Start",buyable = False):
        self.buyable = buyable
        self.name = name
        super().__init__(id,name)
    
    def standOn(self,player,board = []):
        player.receive_Money(300)

class Tax(Start) :
    def __init__(self, id = 0,name = "Tax",buyable = False):
        self.name = name
        self.buyable = buyable
        super().__init__(id,name)
    
    def standOn(self,player,board):
        tax_value = int(player.check_Value_Of_Properties(board) / 100)
        player.receive_Money(-tax_value)

class Rails(Field) :
    def __init__(self, id = 1, name  = "Rails", buyable = True):
        self.owner = -1
        self.multiplier = 1
        self.price = id * 100
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
            return super().__str__()+f" | Houses: {self.multiplier-1} | Fee: {self.calculate_fee()} | Owner id: {self.owner}"
    
    def standOn(self,player,board):
        if self.owner != -1:
            player.receive_Money(-self.calculate_fee())

class City(Rails) :

    def __init__(self, id = 1, name = "City",buyable = True):
        self.buyable = buyable
        super().__init__(id, name)


    def __str__(self):
        return super().__str__() 
    
    def standOn(self, player, board):
        return super().standOn(player, board)

class Player() :
    def __init__(self,id = 0,name = "Example",base_money_value = 10000):
        self.id = id
        self.name = name
        self.money = base_money_value
        self.is_active = self.still_In_Game()
        self.position = 0

    def __str__(self):
        return f"{self.id} {self.name}"
    
    def show_Player_Card(self,board):
        print("="*50)
        print(f" Id: {self.id} \n Name: {self.name} \n Money: {self.money}$ \n Value of Properties: {self.check_Value_Of_Properties(board)}$")
        print(F" Current position : {self.position}")
        print(" Properties: ")
        self.show_Player_Properties(board)
        print("="*50)

    def roll_Dice(self) :
        return random.randrange(1,7)

    def show_Account_Balance(self):
        return f"Account Balance of '{self.name}' : {self.money}$"

    def receive_Money(self, amount):
        self.money += amount     
    
    def buy_Property(self, property, list_Of_players ):
        if property.buyable: 
            buyPrice = property.calculate_Buy_Price()
            if property.owner == -1:
                if self.money >= buyPrice:
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
                        property.owner = self.id
                        return [True,f"Buying Field From {owner.name} Succeded"]
                else:
                    return [False,f"{owner.name} Don't Want Sell {property.name} to {self.name}"]
        else:
            return [False,f"You cannot buy {property.name}"]

    def check_Value_Of_Properties(self,board) :
        tmp = 0
        for field in board:
            if field.buyable == True and field.owner == self.id:
                tmp += field.calculate_Buy_Price()
        return tmp
    
    def build_House(self,property_To_Build_On):
        if property_To_Build_On.id == self.id:
            if property_To_Build_On.multiplier < 6:
                money_To_Pay = property_To_Build_On.calculate_Buy_Price() / 5
                if self.money >= money_To_Pay:
                    property_To_Build_On.multiplier += 1
                    print(property_To_Build_On.calculate_fee())
                    self.receive_Money(-money_To_Pay)
                    return [True,f"{property_To_Build_On.name} Belongs To {self.name} And Has {property_To_Build_On.multiplier-1}/4 Houses"]
            return [True,f"{property_To_Build_On.name} Belongs To {self.name}"]
        else:
            return [False,f"{property_To_Build_On.name} Not Belongs To {self.name} And Has {property_To_Build_On.multiplier-1} Houses"]

    def show_Player_Properties(self,board):
        for field in board:
            if field.buyable == True and field.owner == self.id:
                print(f"  {field.name} localization: {field.id} houses: {field.multiplier}")

    def still_In_Game(self) :
        if self.money < 0 :
            return False
        else: 
            return True
        
class Game():
    
    #=====================================================================#
    #                         Default Settings                            #
    #=====================================================================#
    
    def __init__(self,number_Of_Players = 2,size_Of_Board = 10, starter_Money = 10000):
        self.size_of_Board     = size_Of_Board
        self.number_Of_Players = number_Of_Players
        self.starter_Money     = starter_Money
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
            list_of_players.append(Player(player_id,f"Player {player_id + 1}",self.starter_Money))
        return list_of_players

    def show_Players(self,board):
        for player in self.list_of_Players:
            print(f"id:{player.id} name: {player.name} position id: {player.position} position name: {board[player.position].name}")
    
        
    
    def move_Player_Position(self,id_Of_Player):
        player = self.list_of_Players[id_Of_Player]
        dice_Result = player.roll_Dice()
        
        player.position = (player.position + dice_Result) % len(self.board)

        if player.position < dice_Result and player.position != 0 :
            self.board[0].standOn(player)

        self.board[player.position].standOn(player,self.board) 

    #=====================================================================#
    #                          Game Engine                                #
    #=====================================================================#
    
    def check_Players_Status(self):
        actives = 0
        for player in self.list_of_Players:
            if player.is_active :
                actives += 1
        if actives > 1:
            return [True,f"There Is {actives} Of {self.number_Of_Players} Active Players"]
        else:
            return [False,f"There Is Winner"]
    
    def ask_Player(self,current_Player_Id):
        current_Player = self.list_of_Players[current_Player_Id]
        current_Location = self.board[current_Player.position]

        options = "make decision:\n - move - Move By Amount Rolled By Dice \n - buy  - Buy Property \n - check - Check Player Info \n - build - Build House \n - full - Display Full Board\n"

        cho = str(input(f"{options}").lower())

        if   cho == "move":
            self.move_Player_Position(current_Player_Id)
        elif cho == "buy":
            if current_Location.buyable:
                print(f"Account balance: {current_Player.money}")
                cho2 = input(f"Do you want buy {current_Location.name} for {current_Location.calculate_Buy_Price()}$? (Y/N)").lower()
                if cho2 == "y":
                    res = current_Player.buy_Property(current_Location,self.list_of_Players)
                    print(res[1])
            else:
                print("You cannot buy This field")
                self.ask_Player(current_Player_Id)
        elif cho == "check":
            current_Player.show_Player_Card(self.board)
            self.ask_Player(current_Player)
        elif cho == "build":
            current_Player.build_House(current_Location)
        elif cho == "full":
            self.display_Full_Board()
            self.ask_Player(current_Player)
        else:
            self.ask_Player(current_Player)
        
    def start(self):
        i = 0
        while self.check_Players_Status()[0] :
            current_Player_Id = i % self.number_Of_Players
            current_Player = self.list_of_Players[current_Player_Id]

            self.show_Players(self.board)

            if current_Player.is_active:
                self.display_Simplified_Board()
                print(f"Current Player : {self.list_of_Players[current_Player_Id].name}")
                self.ask_Player(current_Player_Id)
            
                current_Player.is_active = current_Player.still_In_Game()
        
                i += 1
                print(i)
         
monopoly = Game().start()