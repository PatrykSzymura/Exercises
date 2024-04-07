package Lista2;

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
