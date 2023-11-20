import random
import pickle

class Pole:

    def __init__(self,id,nazwa) :

        self.id = id
        self.nazwa = nazwa
        self.owner_id = -1

    def __str__(self):
        return " id = {} \n nazwa = {}".format(self.id,self.nazwa)

class PoleKupne(Pole):

    def __init__(self, id, nazwa,cenaKupna):
        self.cenaKupna = cenaKupna
        self.houses = 0
        super().__init__(id, nazwa)

    def __str__(self):
        return super().__str__()+"\n cena kupna = {}".format(self.cenaKupna)   
    
    def build_house(self):
        if(self.houses < 4):
            self.houses += 1
            print(f"Built a house on {self.nazwa}. Total houses: {self.houses}")
        else:
            print("You cannot build more houses. limit is 4 houses")

class PoleKolej(PoleKupne):

    def __init__(self, id, nazwa, cenaKupna,mnoznik):
        self.mnoznik = mnoznik
        super().__init__(id, nazwa, cenaKupna)

    def __str__(self):
        return super().__str__()+"\n oplata za postoj = {}".format(str(self.ustalOplate()))
    
    def ustalOplate(self):
        return self.cenaKupna * self.mnoznik * (2 ** self.houses)

class Start(Pole):
    def __init__(self, id, nazwa, bonus_money = 200):
        super().__init__(id, nazwa)
        self.bonus_money = bonus_money

    def give_bonus(self, player):
        player.receive_money(self.bonus_money)

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
        if self.owner_id == -1:
            temp = Player(-1,"Bank",0)
            
            if isinstance(tempfld, PoleKupne):
                buyer.transfer_money(temp,tempfld.cenaKupna)
                tempfld.owner_id = buyer.id
                del temp
            else:
                print("Cannot buy this field")
        else:
            print(f"This field belongs to {tempfld.owner_id}")

    def move_player(self, player_index):
        player = self.players[player_index]
        dice_result = player.roll_dice()
        player.position = (player.position + dice_result) % self.total_fields()

        #sprawdzenie czy gracz przeszedł przez pole start
        if player.position < dice_result:
            start_field = [field for field in self.fields if isinstance(field, Start)][0]
            start_field.give_bonus(player)

class Game:
    def __init__(self, num_players=4):
        self.board = Board(num_players)
        self.current_player_index = 0

    def start_game(self):
        print("Monopoly Game Started!")

    def take_turn(self):
        current_player = self.board.players[self.current_player_index]
        print(f"\n{current_player}'s turn (Position: {current_player.position}):")
        
        # Roll the dice and move the player
        dice_result = current_player.roll_dice()
        print(f"{current_player} rolled a {dice_result}")
        self.board.move_player(self.current_player_index)

        # Display the updated board and players
        self.board.display_board()
        self.board.display_players()

        # Ask the player about actions to perform
        action = input("Choose an action (buy/build/move): ").lower()
        
        if action == "buy":
            self.buy_pole(current_player)
        elif action == "build":
            self.build_house(current_player)
        elif action == "move":
            pass  # Player already moved, nothing to do
        else:
            print("Invalid action. Please choose buy, build, or move.")

        # Increment the player index for the next turn
        self.current_player_index = (self.current_player_index + 1) % len(self.board.players)

    def buy_pole(self, player):
        # Implement logic for buying a pole (PoleKupne) here
        pass

    def build_house(self, player):
        # Implement logic for building a house on a PoleKupne here
        pass

    def play_game(self, num_turns=10):
        self.start_game()

        for turn in range(num_turns):
            print(f"\nTurn {turn + 1}")
            self.take_turn()

        print("\nMonopoly Game Ended!")


#monopoly_game = Game(num_players=4)
#monopoly_game.play_game(num_turns=5)
x = Board(4)
for i in range(0,x.num_players*5):
    x.simplyfied()
    current_player = i%x.num_players
    print("make decision:\n - move - move by amount rolled by dice \n - buy  - buy property \n - check - check account balance \n - build - build house \n - save - save game progress")

    cho = str(input("").lower())

    if   cho == "move":
        x.move_player(current_player)
    elif cho == "buy" :
        x.buy_property(current_player)
    elif cho == "check":
        pass
    elif cho == "build":
        pass
    elif cho == "save":
        pass
    else:
        print("incorrect choice")




