package Lista2;

class Field{
    private String Name, Desc;
    public Field(){}
    public void CreateField(String name, String desc){
       this.Name = name;
       this.Desc = desc;
    }

    public void TakeAction() {

    }
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
    private int Id;
    private String Name;
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
    public boolean makeTransaction(int moneyAmount){
        if (this.AccountBalance <= moneyAmount) {return [false, ""];}
    }
}
public class Monopoly {
}
