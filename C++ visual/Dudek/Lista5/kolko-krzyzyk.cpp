#include <iostream>
#include <time.h>
#include <vector>
#include "bibliotekaKolko.h"

using namespace std;



void menu(bool again);

int main(int argc, char const *argv[])
{   
    srand(time(NULL));
    menu(true);
}

void menu(bool again){
     system("cls");

    if(again == false) return;

    int choice = 0,n = 3;
    char przek;

    cout << " Gra w kolko i krzyzyk \n 1. gra 2 graczy 3x3\n 2. gra 2 graczy NxN \n"; 
    cout << " 3. gra gracz vs komputer 3x3 \n 4. gra gracz vs komputer NxN\n";

    cin  >> choice;

    switch (choice)
    {
    case 1:
        cout << "czy chcesz grac z przekatnymi T/N";
        cin  >> przek;
        if(przek == 'T' || przek == 't') gamePlay2Players(n,true);
        else gamePlay2Players(n,false);

        menu(czyPonownie());
        break;
    case 2:
        do
        {
            cout << "\n Podaj n: ";
            cin  >> n;
        } while (n <= 2);

        cout << "czy chcesz grac z przekatnymi T/N";
        cin  >> przek;
        if(przek == 'T' || przek == 't') gamePlay2Players(n,true);
        else gamePlay2Players(n,false);

        menu(czyPonownie());
        break;
    case 3:
        cout << "czy chcesz grac z przekatnymi T/N";
        cin  >> przek;
        if(przek == 'T' || przek == 't') gamePlaySingle(n,true);
        else gamePlaySingle(n,false);
        menu(czyPonownie());
        break;
    case 4:
        do
        {
            cout << "\n Podaj n: ";
            cin  >> n;
        } while (n <= 2);

        cout << "czy chcesz grac z przekatnymi T/N";
        cin  >> przek;
        if(przek == 'T' || przek == 't') gamePlaySingle(n,true);
        else gamePlaySingle(n,false);
        menu(czyPonownie());
        break;
    default:
        break;
    }
}