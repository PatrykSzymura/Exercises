#include <iostream>
#include <string>
using namespace std;


class pole{

    public:
        int idPola;
        string  name,
                desctription;
        void virtual displayPole(){};
        void virtual standOnPole(int gracz){};
}; 

class miasto:public pole{
    private:
        int owner;
        friend class player;
    public:
        bool owned;
        int price,
            district,
            tax,houses;

    void displayPole(){
        cout << "jestem polem" << endl;
    }
    void displayHouses(){};
    void setTax(){};
    //int whoOwns(){};    

};

class inne:public pole{
    bool owned;
    int price,
        tax,
        owner;
    void displayPole(){}

};

class start:public pole{
    void prison(int gracz,int kaucja){};
    void standOnPole(int gracz){
        cout << "jestem start" << endl;
    };
    //int szansa(){};
    //void displayPole(){};    
};

class chance:public pole{
    void standOnPole(){
        cout << "szansa" << endl;
    }
    void displayPole(){
        cout << "szansa" << endl;
    }
};

class prison:public pole{
    void displayPole(){
        cout << "prison" << endl;
    }
};

class player{
    private:
        int money,
            idGracza;
        friend class bankier;
    public:
        int name,
            position;
        bool imprisoned;
            
        void buyPole(pole x){};
        void buildHouses(miasto *domek){};
        void sellCity(miasto city){};
        //void drawCard(special karta){};
        void makeMove(int pos){};
        void przydzielId(){};
};

class bankier{
    private:
        int pula;
    public:
        void ustalPule(){};
        void pozyczka(player pozycza){};
        void wydajPieniadze(player komu,int ile){};
        void przekazPieniadze(player kto , player komu,int ile){};
};

