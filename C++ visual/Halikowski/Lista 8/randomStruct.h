#include <iostream>
#include <time.h>
#include <string>
using namespace std;

auto randomName(){
    string name[6] = { "Jan      ", "Olaf     ", "Wieslaw  ", "Maria    " , "Janina   ", "Julia    " };
    return name[rand()%6];
}

auto randomSubName(){
    string subName[6] = {"Kowalski " , "Kiepski  " , "Boczek   " , "Walaszek ", "Bomba    " , "Paleta   "};
    return subName[rand()%6];
}

auto randomPesel(){
    string pesel = to_string(rand()%100000+100);
    return pesel;
}