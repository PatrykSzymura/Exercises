#include <iostream>
#include <time.h>
#include <string>
using namespace std;

auto randomName(){
    string name[13] = { "Jan", "Olaf", "Wieslaw", "Maria" , "Janina", "Julia","Geralt","Wesemir","Yennefer","Kamil","Donald","Lech","Dawid" };
    return name[rand()%13];
}

auto randomSubName(){
    string subName[14] = {"Kowalski" , "Kiepski" , "Boczek" , "Walaszek", "Bomba" , "Paleta","Riv","Smołka","Kaczyński","Trump","Tusk","Pasternak","Szyba","Buczek"};
    return subName[rand()%14];
}

auto randomWorkPosition(){
    string workPosition[4] = {"Grafik","Programista","Tester","Designer"};
    return workPosition[rand()%4];
}

auto randomPesel(){
    string pesel = to_string(rand()%100000+100);
    return pesel;
}