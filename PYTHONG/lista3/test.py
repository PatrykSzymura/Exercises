import random
import pickle

class Pole:

    def __init__(self,id,nazwa) :

        self.id = id
        self.nazwa = nazwa

    def __str__(self):
        return " id = {} \n nazwa = {}".format(self.id,self.nazwa)

class PoleKupne(Pole):

    def __init__(self, id, nazwa,cenaKupna):
        self.cenaKupna = cenaKupna
        self.owner_id = -1
        self.houses = 1
        self.mnoznik = 1
        super().__init__(id, nazwa)

    def __str__(self):
        return super().__str__()+"\n cena kupna = {}".format(self.cenaKupna)   
    
    def build_house(self):
        if(self.houses < 5):
            self.houses += 1
            print(f"Built a house on {self.nazwa}. Total houses: {self.houses-1}")
        else:
            print("You cannot build more houses. limit is 4 houses")
    
    def ustalOplate(self):
        return self.cenaKupna * self.mnoznik  * self.houses
    

class PoleKolej(PoleKupne):

    def __init__(self, id, nazwa, cenaKupna,mnoznik):
        self.mnoznik = mnoznik
        super().__init__(id, nazwa, cenaKupna)

    def __str__(self):
        return super().__str__()+"\n oplata za postoj = {}".format(str(self.ustalOplate()))
    

class Start(Pole):
    def __init__(self, id, nazwa, bonus_money = 200):
        super().__init__(id, nazwa)
        self.bonus_money = bonus_money

    def give_bonus(self, player):
        player.receive_money(self.bonus_money)

class Tax(Pole):
    def __init__(self, id, nazwa):
        super().__init__(id, nazwa)

    def tax_player(self,temp_player,value_to_tax):
        npt = int(input("give value of your properties:"))
        if npt == value_to_tax:
            value_to_tax = int(value_to_tax/100)
            temp_player.receive_money(-value_to_tax)
        else :
            print("Incorrect amount !!!")
            value_to_tax = int(value_to_tax/100)
            temp_player.receive_money(-value_to_tax)


class Player():
    def __init__(self, id, name,money = 100,position = 0):
        self.name = name
        self.id = id
        self.money = money
        self.position = position

    def __str__(self):
        return self.name
    
    def roll_dice(self):
        return int(random.randrange(1,6))
    
    def transfer_money(self, other_player, amount):
        if self.money >= amount:
            self.money -= amount
            other_player.money += amount
            print(f"{self} transferred {amount} to {other_player}")
        else:
            print(f"{self} does not have enough money to transfer {amount}")

    def receive_money(self, amount):
        self.money += amount
        print(f"{self} received {amount}")

class Board:
    def __init__(self, num_players):
        self.num_players = num_players
        self.fields = self.create_board()
        self.players = [Player(id=i, name=f"Player {i + 1}") for i in range(num_players)]

    def create_board(self):
        start = Start(id=0, nazwa="Start")
        board_fields = [start]

        for i in range(1, 12):
            if i % 2 == 0:
                board_fields.append(PoleKolej(id=i, nazwa=f"Pole Kolej {i}", cenaKupna=i * 10, mnoznik=i))
            else:
                board_fields.append(PoleKupne(id=i, nazwa=f"Pole Kupne {i}", cenaKupna=i * 5))

        return board_fields

    def count_value_properties(self,owner_id):
        value = 0
        for i in self.fields:
            if self.fields[i].owner_id == owner_id:
                value += self.fields[i].ustalOplate()
        return value

    def display_board(self):
        for field in self.fields:
            print("#"*50)
            print(field)

    def display_players(self):
        for player in self.players:
            print(player)

    def total_fields(self):
        return len(self.fields)

    def simplyfied(self):
        print("#"*50)
        for field in self.fields:
            print(field.id,end=" | ")
        print(" ")
        for player in self.players:
            print(f"{player} position:{self.fields[player.position]}")
    
    def buy_property(self,buyer):
        tempfld = self.fields[buyer.position]
        if buyer.id == -1:

            
            if isinstance(tempfld, PoleKupne):
                buyer.recive_money(-tempfld.cenaKupna)
                tempfld.owner_id = buyer.id
                del temp
            else:
                print("Cannot buy this field")
        else:
            print(f"This field belongs to {tempfld.owner_id}")
            #dodanie zapytania do wlasciciela czy chce sprzedac pole

    def move_player(self, player_index):
        player = self.players[player_index]
        dice_result = player.roll_dice()
        player.position = (player.position + dice_result) % self.total_fields()

        #sprawdzenie czy gracz przeszedł przez pole start
        if player.position < dice_result:
            start_field = [field for field in self.fields if isinstance(field, Start)][0]
            start_field.give_bonus(player)
        
        if self.fields[player.position].owner_id != -1:
            self.players[current_player].transfer_money(self.fields[player.position].owner_id,self.fields[player.position].ustalOplate())

class Game:
    def __init__(self, num_players=4):
        self.board = Board(num_players)
        self.current_player_index = 0

    def start_game(self):
        print("Monopoly Game Started!")

    def take_turn(self):
        current_player = self.board.players[self.current_player_index]
        print(f"\n{current_player}'s turn (Position: {current_player.position}):")
        
        
        dice_result = current_player.roll_dice()
        print(f"{current_player} rolled a {dice_result}")
        self.board.move_player(self.current_player_index)

        
        self.board.display_board()
        self.board.display_players()

        
        action = input("Choose an action (buy/build/move): ").lower()
        
        if action == "buy":
            self.buy_pole(current_player)
        elif action == "build":
            self.build_house(current_player)
        elif action == "move":
            pass  
        else:
            print("Invalid action. Please choose buy, build, or move.")

        
        self.current_player_index = (self.current_player_index + 1) % len(self.board.players)

    def buy_pole(self, player):
        
        pass

    def build_house(self, player):
        
        pass

    def play_game(self, num_turns=10):
        self.start_game()

        for turn in range(num_turns):
            print(f"\nTurn {turn + 1}")
            self.take_turn()

        print("\nMonopoly Game Ended!")

    def save_game_state(self):
        filename = input("Enter the filename to save the game state: ")
        with open(filename, 'wb') as file:
            pickle.dump(self, file)
        print(f"Game state saved as {filename}")

   
    def load_game_state(cls, filename):
        with open(filename, 'rb') as file:
            loaded_game = pickle.load(file)
        print(f"Game state loaded from {filename}")
        return loaded_game


x = Board(4)
for i in range(0,x.num_players*5):
    x.simplyfied()
    current_player = i%x.num_players
    print("make decision:\n - move - move by amount rolled by dice \n - buy  - buy property \n - check - check account balance \n - build - build house \n - save - save game progress")

    cho = str(input("").lower())

    if   cho == "move":
        x.move_player(current_player)
    elif cho == "buy" :
        x.buy_property(x.players[current_player])
    elif cho == "check":
        balance = x.players[current_player].money
        print(f"Account balance :{balance}")
    elif cho == "build":
        pass
    elif cho == "save":
        pass
    elif cho == "value":
        print(x.count_value_properties(current_player))
    else:
        print("incorrect choice")




