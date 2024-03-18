package Lista2;

import javax.swing.*;
import java.util.*;

import static Library.Outputs.ConsoleOut;

abstract class Field{
    protected String Name, Desc;

    public Field(){}

    public void CreateField(String name, String desc){
       this.Name = name;
       this.Desc = desc;
    }
    public void CreateField(String name, String desc,int BasePrice){
        this.Name = name;
        this.Desc = desc;
    }

    public abstract void TakeAction(Player CurrentPlayerId);

    public abstract int CalculateTax();
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

    @Override
    public int CalculateTax() {
        return 0;
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
        CurrentPlayerId.makeTransaction(-this.CalculateTax());
    }
}

class HouseField extends RailsField{
    @Override
    public void CreateField(String name, String desc, int BasePrice) {
        super.CreateField(name, desc, BasePrice);
    }

    @Override
    public void TakeAction(Player CurrentPlayerId) {
        super.TakeAction(CurrentPlayerId);
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

    public int rollDice(){
        Random rand = new Random();
        return rand.ints(1,7).findFirst().getAsInt();
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
    protected Field[] BoardFinal;

    public Board(int boardsize){
        this.BoardSize = boardsize;
        this.BoardFinal = new Field[boardsize];

        this.BoardFinal[0] = new StartField();
        this.BoardFinal[0].CreateField("START","Start Field");

        for (int i = 1; i < boardsize; i++) {

            if (i % 4 ==  1){
                this.BoardFinal[i] = new RailsField();
                this.BoardFinal[i].CreateField(String.format("Rails %3d",i), "Rails Field", 1000*i);
            } else {
                this.BoardFinal[i] = new HouseField();
                this.BoardFinal[i].CreateField(String.format("House %3d",i), "House Field", 100*i);
            }
        }
    }
    public void ShowBoard(){
        ConsoleOut(String.format("[ %-10s][ %-10s][ %-10s]","Field Name","Buy Price","Tax"));
        for(Field field : this.BoardFinal){
            ConsoleOut(String.format("[ %-10s][ %-10s][ %-10d]",field.Name,"",field.CalculateTax()));
        }
    }
    public void ShowBoardWindow() {
        StringBuilder message = new StringBuilder();

        String  Tax      = "",
                BuyPrice = "";

        message.append(String.format("[ %-10s][ %-10s][ %-10s]","Field Name","Buy Price","Tax")).append("\n");

        for (Field field : this.BoardFinal) {
            if (!(field instanceof StartField))
            {
                if (field instanceof RailsField rails){
                    Tax = STR."\{rails.CalculateTax()}";
                    BuyPrice = STR."\{rails.CalculateSellPrice()}";
                }
                if (field instanceof HouseField house){
                    Tax = STR."\{house.CalculateTax()}";
                    BuyPrice = STR."\{house.CalculateSellPrice()}";
                }
            }
            message.append(String.format("[ %-10s][ %-10s][ %-10s]",field.Name,BuyPrice,Tax)).append("\n");
        }

        JOptionPane.showMessageDialog(null, message.toString(), "Board Contents", JOptionPane.INFORMATION_MESSAGE);
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
    protected Object[][] PlayerList;
    protected Board      board;
    protected int        CurrentPLayerId = 0;

    public Monopoly(int BoardSize, int NumOfPlayers){

        this.board          = new Board(BoardSize);
        this.PlayerList     = new Object[NumOfPlayers][2];

        //Creating Players
        for(int i = 0; i < NumOfPlayers; i++){
            PlayerList[i][0] = new Player(i, STR."Player \{i}",1000);
            PlayerList[i][1] = 0;
        }

        do{
            //display board in window
            board.ShowBoardWindow();

            Player player = (Player) this.PlayerList[CurrentPLayerId % NumOfPlayers][0];

            if (player.isInGame()){
                this.PlayerActionMenu(this.PlayerList[CurrentPLayerId % NumOfPlayers]);
            }

            CurrentPLayerId += 1;
            if (CurrentPLayerId == NumOfPlayers) CurrentPLayerId = 0;
        }while(this.ContinueGame());
    }


    protected boolean PlayerActionMenu(Object[] CurrentPlayer){
        Player currentPlayer = (Player) CurrentPlayer[0];
        int currentPlayerPos = (int)    CurrentPlayer[1];

        int cho = 0;

        StringBuilder message = new StringBuilder();

        message.append(String.format(STR."\{currentPlayer.getName()} Turn")).append("\n");
        message.append(String.format(STR."Current Balance: \{currentPlayer.getAccountBalance()}")).append("\n");
        message.append(String.format(STR."Current Field: \{this.board.BoardFinal[currentPlayerPos].Name}")).append("\n");

        message.append("Description:").append("\n");

        message.append(String.format(STR."  \{this.board.BoardFinal[currentPlayerPos].Desc}")).append("\n");

        String[] Options1 = {
                "Roll Dice"
        };

        String[] Options2 = {
                "Roll Dice",
                "Buy Field"
        };
        //JOptionPane.showOptionDialog(null,message,"Monopoly",0,0,null,Options1,0);

        int moveValue = 0;

        if (!(this.board.BoardFinal[currentPlayerPos] instanceof StartField)){
            cho = JOptionPane.showOptionDialog(null,message,"Monopoly",0,0,null,Options2,0);

            switch (cho){
                case 0:
                    moveValue = currentPlayer.rollDice();
                    JOptionPane.showMessageDialog(null,STR."You rolled: \{moveValue}");
                    ChangePlayerLocation(CurrentPlayer,currentPlayer.rollDice());
                    break;
            };
        } else {
            JOptionPane.showOptionDialog(null,message,"Monopoly",0,0,null,Options1,0);
            moveValue = currentPlayer.rollDice();
            JOptionPane.showMessageDialog(null,STR."You rolled: \{moveValue}");
            ChangePlayerLocation(CurrentPlayer,currentPlayer.rollDice());
        }





        return false;
    }

    protected void ChangePlayerLocation(Object[] CurrentPlayer,int amount){
        int playerPosition = (int) CurrentPlayer[1];
        Player currentPlayer = (Player) CurrentPlayer[0];

        playerPosition = (playerPosition + amount) % this.board.BoardSize;

        if (playerPosition < amount && playerPosition != 0 ){
            this.board.BoardFinal[0].TakeAction(currentPlayer);
        }
        this.board.BoardFinal[playerPosition].TakeAction(currentPlayer);

        this.PlayerList[this.CurrentPLayerId][1] = playerPosition;

    }

    protected boolean ContinueGame(){
        int counter = 0;

        for (Object[] objects : this.PlayerList) {
            Player player = (Player) objects[0];
            if(player.isInGame()) counter += 1;
        }

        return counter == this.PlayerList.length;
    }
}
