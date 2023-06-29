#include <iostream>
#include <time.h>
#include <string>
using namespace std;

auto randomName(){
    string name[6] = { "    Jan", "   Olaf", "Wieslaw", "  Maria" , " Janina", "  Julia" };
    return name[rand()%6];
}

auto randomSubName(){
    string subName[6] = {"Kowalski" , " Kiepski" , "  Boczek" , "Walaszek", "   Bomba" , "  Paleta"};
    return subName[rand()%6];
}

auto randomPesel(){
    string pesel = "00000000000";
    for(int i = 0; i <= 11; i++){
        pesel[i] = (rand()%9)+30;
    }
    return pesel;
}