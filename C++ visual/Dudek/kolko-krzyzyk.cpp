#include <iostream>
#include <time.h>
#include <vector>
#include "bibliotekaKolko.h"

using namespace std;

void menu(bool again){
     system("cls");

    if(again == false) return;

    int choice = 0,n = 3;

    cout << " Gra w kolko i krzyzyk \n 1. gra 2 graczy 3x3\n 2. gra 2 graczy NxN \n"; 
    cout << " 3. gra gracz vs komputer 3x3 \n 4. gra gracz vs komputer NxN\n";

    cin  >> choice;

    switch (choice)
    {
    case 1:
        gamePlay2Players(3);
        menu(czyPonownie());
        break;
    case 2:
        do
        {
            cout << "\n Podaj n: ";
            cin  >> n;
        } while (n <= 2);
        

        gamePlay2Players(n);
        menu(czyPonownie());
        break;
    case 3:
        cout << "work in progress";
        break;
    case 4:
        cout << "work in progress";
        break;
    default:
        break;
    }
}

int main(int argc, char const *argv[])
{   
    menu(true);
}
