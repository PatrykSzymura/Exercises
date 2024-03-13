package Lista2;

abstract class Field{
    protected String Name, Desc;

    public Field(){}

    public void CreateField(String name, String desc){
       this.Name = name;
       this.Desc = desc;
    }

    public void TakeAction() {}

    public abstract void TakeAction(Player CurrentPlayerId);
}

class StartField extends Field{
    @Override
    public void CreateField(String name, String desc) {
        super.CreateField(name, desc);
    }

    @Override
    public void TakeAction(Player CurrentPlayerId) {
        CurrentPlayerId.makeTransaction(1000);
    }
}

class RailsField extends Field{
    protected int Price;
    protected int Owner_Id;
    protected int PriceModifier = 1;


    public void CreateField(String name, String desc, int BasePrice){
        super.CreateField(name, desc);

        this.Price = CalculatePrice(BasePrice);
        this.Owner_Id = 0;
    }

    public int CalculateTax(){return this.Price/10;}

    protected int CalculatePrice(int BasePrice){
        return BasePrice * this.PriceModifier;
    }

    public int CalculateSellPrice(){ return Price * 2; }

    public boolean BuyField(int new_owner_id){
        if (this.Owner_Id == 0) {
            this.Owner_Id = new_owner_id;
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

    @Override
    public void TakeAction(Player CurrentPlayerId) {
        CurrentPlayerId.makeTransaction(this.CalculateTax());
    }
}

class HouseField extends RailsField{
    @Override
    public void CreateField(String name, String desc, int BasePrice) {
        super.CreateField(name, desc, BasePrice);
    }

    public int getPriceModifier(){
        return this.PriceModifier;
    }

    public void updatePriceModifier(){
        this.PriceModifier += 1;
    }

    public int calculateBuildHousePrice(){
        return this.PriceModifier * 100;
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
    protected int BoardSize;
    protected Object[][] BoardFinal;
    protected Board(int boardsize){
        this.BoardSize = boardsize;
        this.BoardFinal = new Object[2][boardsize];

        for (int i = 1; i < boardsize; i++) {
            //replace later buyable for house field or rails field
                BoardFinal[0][i] = new RailsField();
        }

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
    public Monopoly(int BoardSize, int NumOfPlayers){

    }
}
