package Lista2;

class Field{
    private String Name, Desc;

    public Field(){}

    public void CreateField(String name, String desc){
       this.Name = name;
       this.Desc = desc;
    }

    public void TakeAction() {}
}

class Buyable extends Field{
    private int Price;
    private int Owner_Id;

    public void CreateField(String name, String desc, int price){
        super.CreateField(name, desc);
        Price = price;
        Owner_Id = 0;
    }

    public int CalculateSellPrice(){return Price;}
    public boolean BuyField(int new_owner_id){
        if (this.Owner_Id == 0){
           Owner_Id = new_owner_id;
           return true;
        }

        return false;
    }
    public boolean BuyField(int new_owner_id, boolean aproval){
        if (aproval){
            Owner_Id = new_owner_id;
            return true;
        }

        return false;
    }
}

class Player{
    private boolean IsInGame;
    private final int Id;
    private final String Name;
    private int AccountBalance;

    public Player(int id, String name, int accountBalance){
        this.Id = id;
        this.Name = name;
        this.AccountBalance = accountBalance;
        this.IsInGame = true;
    }

    public int getId() {
        return Id;
    }

    public int getAccountBalance() {
        return AccountBalance;
    }

    public String getName() {
        return Name;
    }

    public boolean isInGame() {
        return IsInGame;
    }

    public void PlayerLost() {
        IsInGame = false;
    }

    public Object makeTransaction(int moneyAmount){
        Object[] result = new Object[2];

        if (this.AccountBalance <= moneyAmount) {
            this.AccountBalance += moneyAmount;
            result[0] = false;
            result[1] = "Lack of funds";
        }

        result[0] = true;
        result[1] = "Operation Complete";

        return result;
    }
}

class Board{
    protected Board(int boardSize){

    }
}

class MonopolyBuilder{
    private int BoardSize       = 12;
    private int NumberOfPlayers = 2 ;

    MonopolyBuilder setBoardSize(int size){
        this.BoardSize = size;
        return this;
    }

    MonopolyBuilder setNumberOfPlayers(int number){
        this.NumberOfPlayers = number;
        return this;
    }

    Monopoly buildMonopoly(){
        return new Monopoly( BoardSize, NumberOfPlayers );
    }
}

public class Monopoly {
    public Monopoly(int BoardSize, int NumOfPlayers){}
}
